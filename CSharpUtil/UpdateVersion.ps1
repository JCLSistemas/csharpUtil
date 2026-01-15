# Script para atualização manual de versão quando necessário
# Uso: .\UpdateVersion.ps1 -Major 1 -Minor 0 -Build 0
# Ou simplesmente: .\UpdateVersion.ps1 para incrementar a revisão

param(
    [int]$Major = -1,
    [int]$Minor = -1,
    [int]$Build = -1,
    [switch]$IncrementMinor,
    [switch]$IncrementMajor
)

$assemblyInfoPath = Join-Path $PSScriptRoot "Properties\AssemblyInfo.cs"

if (-not (Test-Path $assemblyInfoPath)) {
    Write-Error "Arquivo AssemblyInfo.cs não encontrado em: $assemblyInfoPath"
    exit 1
}

$content = Get-Content $assemblyInfoPath -Raw

# Extrai versão atual (formato: X.X.* ou X.X.X.X)
if ($content -match 'AssemblyVersion\("(\d+)\.(\d+)\.?\*?\.?(\d*)"') {
    $currentMajor = [int]$Matches[1]
    $currentMinor = [int]$Matches[2]
    
    Write-Host "Versão atual: $currentMajor.$currentMinor.*" -ForegroundColor Cyan
    
    # Aplica incrementos se solicitado
    if ($IncrementMajor) {
        $currentMajor++
        $currentMinor = 0
        Write-Host "Incrementando Major version..." -ForegroundColor Yellow
    }
    elseif ($IncrementMinor) {
        $currentMinor++
        Write-Host "Incrementando Minor version..." -ForegroundColor Yellow
    }
    
    # Aplica valores específicos se fornecidos
    if ($Major -ge 0) { $currentMajor = $Major }
    if ($Minor -ge 0) { $currentMinor = $Minor }
    
    $newVersion = "$currentMajor.$currentMinor.*"
    
    # Atualiza o arquivo
    $content = $content -replace 'AssemblyVersion\("[^"]+"\)', "AssemblyVersion(`"$newVersion`")"
    
    Set-Content $assemblyInfoPath $content -NoNewline -Encoding UTF8
    
    Write-Host "Nova versão: $newVersion" -ForegroundColor Green
    Write-Host "Build e Revision serão gerados automaticamente na compilação." -ForegroundColor Gray
}
else {
    Write-Error "Não foi possível encontrar AssemblyVersion no arquivo."
    exit 1
}
