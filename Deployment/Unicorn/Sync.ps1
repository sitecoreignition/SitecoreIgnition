$ErrorActionPreference = 'Stop'

Add-Type -AssemblyName System.IO.Compression.FileSystem

$output = 'C:\Builds\Serialization'

Get-ChildItem -Path $output -Recurse | Remove-Item -Force -Recurse

[System.IO.Compression.ZipFile]::ExtractToDirectory('C:\Builds\Artifacts\Ignition.Unicorn.Items.zip', $output)

Import-Module $PSScriptRoot\Unicorn.psm1

# SYNC ALL CONFIGURATIONS
Sync-Unicorn -ControlPanelUrl 'http://symposiumdemo.eastus.cloudapp.azure.com/unicorn.aspx' -SharedSecret 'thisisthebestsharedsecretevernomatterwhatanyonesays'