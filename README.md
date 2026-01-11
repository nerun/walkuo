# WalkUO

WalkUO is a fork of RunUO, an Ultima Online server, focused on long-term maintenance and gradual evolution.

> _RunUO is no longer officially supported by a core team._
>
> _If you wish to find support in a wider UO development community, visit [ServUO - Ultima Online Emulation](http://www.servuo.com)._

## Build

Inside the WalkUO folder, run the following command:

#### Windows

```console
C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc /optimize /unsafe /t:exe /out:WalkUO.exe /win32icon:Server\walkuo.ico /d:NEWTIMERS /d:NEWPARENT /recurse:Server\\*.cs
```

#### Linux (MONO)

```console
$ mcs -optimize+ -unsafe -t:exe -out:WalkUO.exe -win32icon:Server/walkuo.ico -nowarn:219,414 -d:NEWTIMERS -d:NEWPARENT -d:MONO -reference:System.Drawing -recurse:'Server/*.cs'
```
