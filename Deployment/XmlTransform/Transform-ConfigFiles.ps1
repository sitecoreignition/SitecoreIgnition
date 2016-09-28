param(
    [Parameter(Mandatory=$true)][String] $RootPath,
    [Parameter(Mandatory=$true)][String] $TransformsPath,
    [Parameter(Mandatory=$true)][String] $Configuration
)
Import-Module $PsScriptRoot\XmlTransform.psm1
try {
    $configTransformPaths = Get-ChildItem -Path $TransformsPath -File -Recurse

    foreach ($configTransformPath in $configTransformPaths)
    {
        $sourceConfigPath = $configTransformPath.FullName.Replace($TransformsPath, $RootPath).Replace("." + $Configuration + ".config", ".config")
        Merge-Xml -SourceXml $sourceConfigPath -TargetTransform $configTransformPath.FullName
    }
}
catch { throw $_ }