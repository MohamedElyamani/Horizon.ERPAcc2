param ($version='latest')

$currentFolder = $PSScriptRoot
$slnFolder = Join-Path $currentFolder "../../"

Write-Host "********* BUILDING DbMigrator *********" -ForegroundColor Green
$dbMigratorFolder = Join-Path $slnFolder "src/Horizon.ERPAcc2.DbMigrator"
Set-Location $dbMigratorFolder
dotnet publish -c Release
docker build -f Dockerfile.local -t horizon/erpacc2-db-migrator:$version .

Write-Host "********* BUILDING Web Application *********" -ForegroundColor Green
$webFolder = Join-Path $slnFolder "src/Horizon.ERPAcc2.Web"
Set-Location $webFolder
dotnet publish -c Release
docker build -f Dockerfile.local -t horizon/erpacc2-web:$version .


### ALL COMPLETED
Write-Host "COMPLETED" -ForegroundColor Green
Set-Location $currentFolder