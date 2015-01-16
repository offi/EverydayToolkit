$root = Join-Path (split-path -parent $MyInvocation.MyCommand.Definition) '\..'
$version = [System.Reflection.Assembly]::LoadFile("$root\EverydayToolkit\bin\Release\EverydayToolkit.dll").GetName().Version
$versionStr = "{0}.{1}.{2}" -f ($version.Major, $version.Minor, $version.Build)

Write-Host "Setting .nuspec version tag to $versionStr" -ForegroundColor Green
$content = Get-Content $root\NuGet\EverydayToolkit.nuspec 
$content = $content -replace '\$version\$',$versionStr
$content | Out-File $root\nuget\EverydayToolkit.compiled.nuspec -Force

& $root\NuGet\NuGet.exe pack $root\nuget\EverydayToolkit.compiled.nuspec
