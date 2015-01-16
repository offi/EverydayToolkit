SET version="0.1.1"
SET msBuildDir=%WINDIR%\Microsoft.NET\Framework\v4.0.30319

call %msBuildDir%\msbuild /p:Configuration=Release EverydayToolkit\EverydayToolkit.csproj
MKDIR nuget\lib\net45
COPY EverydayToolkit\bin\Release\EverydayToolkit.dll nuget\lib\net45\

COPY EverydayToolkit.nuspec nuget\

Tools\NuGet.exe pack nuget\EverydayToolkit.nuspec -Version %version%

RMDIR nuget /S /Q