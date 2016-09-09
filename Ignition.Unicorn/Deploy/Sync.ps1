$ErrorActionPreference = 'Stop'

$ScriptPath = Split-Path $MyInvocation.MyCommand.Path

Import-Module $ScriptPath\Unicorn.psm1

# SYNC ALL CONFIGURATIONS
Sync-Unicorn -ControlPanelUrl 'https://symposiumdemo.eastus.cloudapp.azure.com/unicorn.aspx' -SharedSecret 'thisisthebestsharedsecretevernomatterwhatanyonesays'