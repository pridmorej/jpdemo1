[T4Scaffolding.Scaffolder(Description = "Enter a description of W00tNewAndNice here")][CmdletBinding()]
param(
	[parameter(Mandatory = $true, ValueFromPipelineByPropertyName = $true)][string]$ViewName,
	[parameter(Mandatory = $false, ValueFromPipelineByPropertyName = $true)][string]$Layout,        
    [string]$Project,
	[string]$CodeLanguage,
	[string[]]$TemplateFolders,
	[switch]$Force = $falseS
)

$outputPath = "Views\"+$ViewName  # The filename extension will be added based on the template's <#@ Output Extension="..." #> directive
$namespace = (Get-Project $Project).Properties.Item("DefaultNamespace").Value

Add-ProjectItemViaTemplate $outputPath -Template ViewTemplate `
	-Model @{ Namespace = $namespace; ViewName = $ViewName;  Layout = $Layout; ExampleValue = "Hello, world!" } `
	-SuccessMessage "Added View output at {0}" `
	-TemplateFolders $TemplateFolders -Project $Project -CodeLanguage $CodeLanguage -Force:$Force