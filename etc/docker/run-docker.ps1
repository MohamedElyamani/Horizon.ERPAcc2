$currentFolder = $PSScriptRoot

$slnFolder = Join-Path $currentFolder "../"
$certsFolder = Join-Path $currentFolder "certs"

If(!(Test-Path -Path $certsFolder))
{
    New-Item -ItemType Directory -Force -Path $certsFolder
    if(!(Test-Path -Path (Join-Path $certsFolder "localhost.pfx") -PathType Leaf)){
        Set-Location $certsFolder
        dotnet dev-certs https -v -ep localhost.pfx -p 25fcd6d8-5774-4a2b-9459-deb1da395c43 -t        
    }
}

Set-Location $currentFolder
docker-compose up -d