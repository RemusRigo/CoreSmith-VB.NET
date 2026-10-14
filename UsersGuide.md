# CoreSmith: User's Guide

> CoreSmith is **in progress**: you can browse and select apps, but installing and uninstalling is not implemented yet.



## Downloads & Runtimes

Download the latest release from the [Releases page](https://github.com/RemusRigo/CoreSmith-VB.NET/releases).

|Folder|Target Framework|Architecture|Required Runtime|
|-|-|-|-|
|`net10.0-windows`|.NET 10.0|Any CPU|[.NET 10.0 Desktop Runtime](https://dotnet.microsoft.com/download/dotnet/10.0)|

> The plain ".NET Runtime" is not enough; CoreSmith needs the **Desktop** Runtime.
> To check which runtimes are installed, run `dotnet --list-runtimes` and look for a `Microsoft.WindowsDesktop.App 10.x` line.



## Install

CoreSmith is portable: there is no installer.

1. Download and extract the release to a folder where you have write access, for example `D:\My Apps\CoreSmith\`.
2. Make sure `WingetDB.csv` is in the same folder as `CoreSmith.exe`.
3. Double-click `CoreSmith.exe`.

> If Windows blocks the file ("Windows protected your PC"), right-click `CoreSmith.exe` →
> **Properties** → check **Unblock** → **OK**, then try again.



## Usage

The list shows the apps from `WingetDB.csv`, grouped by category, with their name and winget ID.

* Check the apps you want.
* Click an app to see its description below the list.
* **Export** saves the checked apps to `test.json`; **Import** checks the apps saved in `test.json` again.



## The app list: WingetDB.csv

You can add your own apps to `WingetDB.csv`; it has 4 columns:

```
Name,Description,ID,Category
7-ZIP,File archiver,7zip.7zip,Archiver
```

The **ID** is the winget package ID; find it with `winget search <name>`.



## Uninstall

Delete the folder you created in step 1 of *Install*.
