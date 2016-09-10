$ErrorActionPreference = 'Stop'

Import-Module $PSScriptRoot\Unicorn.psm1

# SYNC ALL CONFIGURATIONS
Sync-Unicorn -ControlPanelUrl 'https://symposiumdemo.eastus.cloudapp.azure.com/unicorn.aspx' -SharedSecret 'thisisthebestsharedsecretevernomatterwhatanyonesays'