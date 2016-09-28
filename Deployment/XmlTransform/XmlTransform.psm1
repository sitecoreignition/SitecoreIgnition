<#
.SYNOPSIS
    Performs XML Transformations
.DESCRIPTION
    This script transforms XML files using the same libraries that VisualStudio and MSBuild use to perform web.config transformations.
.PARAMETER SourceXml
    The path of the Xml file that is used as the base of the transform
.PARAMETER TargetTransform
    The path of the Xml file that contains the transformations to perform
.PARAMETER DestinationXml
    The path to save the resulting file. If no value is provided, the SourceXml file will be overwritten with the new file
#>
function Merge-Xml{

	param(
		[Parameter(Mandatory=$true)][String] $SourceXml,
		[Parameter(Mandatory=$true)][String] $TargetTransform,
		[Parameter(Mandatory=$false)][String] $DestinationXml
	)	
	Try {
		Add-Type -Path $PsScriptRoot\Microsoft.Web.XmlTransform.dll

		$source = New-Object Microsoft.Web.XmlTransform.XmlTransformableDocument
		$source.PreserveWhitespace = $true
		$source.Load($SourceXml)

		$transform = New-Object Microsoft.Web.XmlTransform.XmlTransformation($TargetTransform)

		if($transform.Apply($source) -eq $false) {
			throw "Transformation failed."
		}

		if([string]::IsNullOrWhiteSpace($DestinationXml)) { $DestinationXml = $SourceXml }	
		$source.Save($DestinationXml)

	}Catch { throw $_}
}

Add-Type -Path $PsScriptRoot\Microsoft.Web.XmlTransform.dll
Export-ModuleMember -Function Merge-Xml