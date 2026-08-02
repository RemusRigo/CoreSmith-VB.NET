Imports Microsoft.VisualBasic.FileIO
Imports System.Text.Json

Public Class frmApps

   Public Class CheckedItemRecord
      Public Property GroupName As String
      Public Property ItemText As String
   End Class

   Public Sub SaveCheckedItemsToJson(lv As ListView, filePath As String)
      Dim checkedItems As New List(Of CheckedItemRecord)

      For Each item As ListViewItem In lv.Items
         If item.Checked Then
            Dim groupName As String = If(item.Group IsNot Nothing, item.Group.Header, String.Empty)
            checkedItems.Add(New CheckedItemRecord With {
                .groupName = groupName,
                .ItemText = item.Text
            })
         End If
      Next

      Dim options As New JsonSerializerOptions With {.WriteIndented = True}
      Dim json As String = JsonSerializer.Serialize(checkedItems, options)
      IO.File.WriteAllText(filePath, json)
   End Sub

   Public Sub LoadCheckedItemsFromJson(lv As ListView, filePath As String)
      If Not IO.File.Exists(filePath) Then Return

      Dim json As String = IO.File.ReadAllText(filePath)
      Dim checkedItems As List(Of CheckedItemRecord) =
        JsonSerializer.Deserialize(Of List(Of CheckedItemRecord))(json)

      ' Uncheck everything first (optional, keeps state clean)
      For Each item As ListViewItem In lv.Items
         item.Checked = False
      Next

      For Each record In checkedItems
         For Each item As ListViewItem In lv.Items
            Dim groupName As String = If(item.Group IsNot Nothing, item.Group.Header, String.Empty)
            If groupName = record.GroupName AndAlso item.Text = record.ItemText Then
               item.Checked = True
               Exit For
            End If
         Next
      Next
   End Sub

   Public Sub LoadFromCSV(lv As ListView, csvPath As String, Optional hasHeader As Boolean = True)
      If Not IO.File.Exists(csvPath) Then Return

      lv.Items.Clear()

      Using parser As New TextFieldParser(csvPath)
         parser.TextFieldType = FieldType.Delimited
         parser.SetDelimiters(",")
         parser.HasFieldsEnclosedInQuotes = True

         Dim isFirstLine As Boolean = True

         While Not parser.EndOfData
            Dim fields As String() = parser.ReadFields()

            If isFirstLine AndAlso hasHeader Then
               isFirstLine = False
               Continue While
            End If
            isFirstLine = False

            If fields.Length < 4 Then Continue While ' skip malformed rows

            Dim name As String = fields(0)
            Dim description As String = fields(1)
            Dim id As String = fields(2)
            Dim category As String = fields(3)

            Dim item As New ListViewItem(name)
            item.SubItems.Add(description)
            item.SubItems.Add(id)
            item.SubItems.Add(category)

            lv.Items.Add(item)
         End While
      End Using
   End Sub

   Public Sub LoadFromCSVWithGroups(lv As ListView, csvPath As String, Optional hasHeader As Boolean = True)
      If Not IO.File.Exists(csvPath) Then Return

      lv.Items.Clear()
      lv.Groups.Clear()

      Dim groupLookup As New Dictionary(Of String, ListViewGroup)(StringComparer.OrdinalIgnoreCase)
      Dim rows As New List(Of String())

      Using parser As New TextFieldParser(csvPath)
         parser.TextFieldType = FieldType.Delimited
         parser.SetDelimiters(",")
         parser.HasFieldsEnclosedInQuotes = True

         Dim isFirstLine As Boolean = True

         While Not parser.EndOfData
            Dim fields As String() = parser.ReadFields()

            If isFirstLine AndAlso hasHeader Then
               isFirstLine = False
               Continue While
            End If
            isFirstLine = False

            If fields.Length < 4 Then Continue While

            rows.Add(fields)
         End While
      End Using

      Dim sortedCategories = rows.Select(Function(f) f(3)).Distinct(StringComparer.OrdinalIgnoreCase).OrderBy(Function(c) c, StringComparer.OrdinalIgnoreCase)

      For Each category In sortedCategories
         Dim grp As New ListViewGroup(category, category)
         lv.Groups.Add(grp)
         groupLookup(category) = grp
      Next

      ' Now populate items into their already-sorted groups
      lv.BeginUpdate()
      For Each fields In rows
         Dim name As String = fields(0)
         Dim description As String = fields(1)
         Dim id As String = fields(2)
         Dim category As String = fields(3)

         Dim item As New ListViewItem(name)
         item.SubItems.Add(description)
         item.SubItems.Add(id)
         item.SubItems.Add(category)
         item.Group = groupLookup(category)

         lv.Items.Add(item)
      Next
      lv.EndUpdate()
   End Sub

   Private Sub frmApps_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      lvWinget.View = View.Details
      lvWinget.FullRowSelect = True
      lvWinget.CheckBoxes = True
      lvWinget.Columns.Add("Name", 200)
      lvWinget.Columns.Add("Description", 0) ' hidden column
      lvWinget.Columns.Add("Id", 200)
      lvWinget.Columns.Add("Category", 0) ' hidden column

      'LoadFromCSV(lvWinget, "WingetDB.csv", True)
      LoadFromCSVWithGroups(lvWinget, "WingetDB.csv", True)
   End Sub

   Private Sub mnuWingetExport_Click(sender As Object, e As EventArgs) Handles mnuWingetExport.Click
      SaveCheckedItemsToJson(lvWinget, "test.json")
   End Sub

   Private Sub mnuWingetImport_Click(sender As Object, e As EventArgs) Handles mnuWingetImport.Click
      LoadCheckedItemsFromJson(lvWinget, "test.json")
   End Sub

   Private Sub lvWinget_Click(sender As Object, e As EventArgs) Handles lvWinget.Click
      If lvWinget.SelectedItems.Count = 0 Then Return

      lblDescription.Text = lvWinget.SelectedItems(0).SubItems(1).Text
   End Sub
End Class
