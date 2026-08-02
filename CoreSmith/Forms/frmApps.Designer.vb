<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmApps
   Inherits System.Windows.Forms.Form

   'Form overrides dispose to clean up the component list.
   <System.Diagnostics.DebuggerNonUserCode()>
   Protected Overrides Sub Dispose(disposing As Boolean)
      Try
         If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
         End If
      Finally
         MyBase.Dispose(disposing)
      End Try
   End Sub

   'Required by the Windows Form Designer
   Private components As System.ComponentModel.IContainer

   'NOTE: The following procedure is required by the Windows Form Designer
   'It can be modified using the Windows Form Designer.
   'Do not modify it using the code editor.
   <System.Diagnostics.DebuggerStepThrough()>
   Private Sub InitializeComponent()
      components = New ComponentModel.Container()
      lvWinget = New ListView()
      mnuWinget = New ContextMenuStrip(components)
      mnuWingetExport = New ToolStripMenuItem()
      mnuWingetImport = New ToolStripMenuItem()
      pnlDescription = New Panel()
      pnlOptions = New Panel()
      lblDescription = New Label()
      mnuWinget.SuspendLayout()
      pnlDescription.SuspendLayout()
      SuspendLayout()
      ' 
      ' lvWinget
      ' 
      lvWinget.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
      lvWinget.ContextMenuStrip = mnuWinget
      lvWinget.Location = New Point(2, 2)
      lvWinget.Name = "lvWinget"
      lvWinget.Size = New Size(932, 408)
      lvWinget.TabIndex = 0
      lvWinget.UseCompatibleStateImageBehavior = False
      ' 
      ' mnuWinget
      ' 
      mnuWinget.Items.AddRange(New ToolStripItem() {mnuWingetExport, mnuWingetImport})
      mnuWinget.Name = "ContextMenuStrip1"
      mnuWinget.Size = New Size(111, 48)
      ' 
      ' mnuWingetExport
      ' 
      mnuWingetExport.Name = "mnuWingetExport"
      mnuWingetExport.Size = New Size(110, 22)
      mnuWingetExport.Text = "Export"
      ' 
      ' mnuWingetImport
      ' 
      mnuWingetImport.Name = "mnuWingetImport"
      mnuWingetImport.Size = New Size(110, 22)
      mnuWingetImport.Text = "Import"
      ' 
      ' pnlDescription
      ' 
      pnlDescription.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
      pnlDescription.BorderStyle = BorderStyle.FixedSingle
      pnlDescription.Controls.Add(lblDescription)
      pnlDescription.Location = New Point(2, 416)
      pnlDescription.Name = "pnlDescription"
      pnlDescription.Size = New Size(932, 30)
      pnlDescription.TabIndex = 1
      ' 
      ' pnlOptions
      ' 
      pnlOptions.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Right
      pnlOptions.BorderStyle = BorderStyle.FixedSingle
      pnlOptions.Location = New Point(940, 2)
      pnlOptions.Name = "pnlOptions"
      pnlOptions.Size = New Size(236, 444)
      pnlOptions.TabIndex = 2
      ' 
      ' lblDescription
      ' 
      lblDescription.Dock = DockStyle.Fill
      lblDescription.Location = New Point(0, 0)
      lblDescription.Name = "lblDescription"
      lblDescription.Size = New Size(930, 28)
      lblDescription.TabIndex = 0
      ' 
      ' frmApps
      ' 
      AutoScaleDimensions = New SizeF(7F, 15F)
      AutoScaleMode = AutoScaleMode.Font
      ClientSize = New Size(1177, 450)
      Controls.Add(pnlOptions)
      Controls.Add(pnlDescription)
      Controls.Add(lvWinget)
      Name = "frmApps"
      Text = "Form1"
      mnuWinget.ResumeLayout(False)
      pnlDescription.ResumeLayout(False)
      ResumeLayout(False)
   End Sub

   Friend WithEvents lvWinget As ListView
   Friend WithEvents mnuWinget As ContextMenuStrip
   Friend WithEvents mnuWingetExport As ToolStripMenuItem
   Friend WithEvents mnuWingetImport As ToolStripMenuItem
   Friend WithEvents pnlDescription As Panel
   Friend WithEvents pnlOptions As Panel
   Friend WithEvents lblDescription As Label

End Class
