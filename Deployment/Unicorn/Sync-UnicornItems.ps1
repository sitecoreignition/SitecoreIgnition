param(
    [Parameter(Mandatory=$true)][String] $SerializationZipPath,
    [Parameter(Mandatory=$true)][String] $SerializationTargetPath,
    [Parameter(Mandatory=$true)][String] $SiteUrl,
    [Parameter(Mandatory=$true)][String] $SharedSecret
)
$ErrorActionPreference = 'Stop'

Add-Type -AssemblyName System.IO.Compression.FileSystem

try {
    #Get-ChildItem -Path ($SerializationTargetPath + '\Unicorn') -Recurse | Remove-Item -Force -Recurse
    Remove-Item -Path ($SerializationTargetPath + '\Unicorn') -Recurse -Force    
}
catch {
    
}

[System.IO.Compression.ZipFile]::ExtractToDirectory($SerializationZipPath, $SerializationTargetPath)

Import-Module $PSScriptRoot\Unicorn.psm1

# SYNC ALL CONFIGURATIONS
Sync-Unicorn -ControlPanelUrl ($SiteUrl + '/unicorn.aspx') -SharedSecret $SharedSecret