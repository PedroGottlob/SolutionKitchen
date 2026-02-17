# Script PowerShell para iniciar Microserviços do SolutionKitchen

$ErrorActionPreference = "Stop"

function Show-Menu {
    Clear-Host
    Write-Host "===================================="
    Write-Host "SolutionKitchen - Microservices"
    Write-Host "===================================="
    Write-Host ""
    Write-Host "Escolha uma opcao:"
    Write-Host "1. Iniciar com Docker Compose"
    Write-Host "2. Iniciar localmente (requer 3 terminais)"
    Write-Host "3. Build dos projetos"
    Write-Host "4. Parar containers"
    Write-Host "5. Verificar status"
    Write-Host "6. Sair"
    Write-Host ""
}

function Start-DockerCompose {
    Write-Host "Iniciando Docker Compose..." -ForegroundColor Green
    docker-compose up -d
    
    Write-Host "Aguardando inicializacao..." -ForegroundColor Yellow
    Start-Sleep -Seconds 10
    
    Write-Host ""
    Write-Host "Servicos iniciados:" -ForegroundColor Green
    Write-Host "- API Gateway: http://localhost:5000"
    Write-Host "- ChefService: http://localhost:5001"
    Write-Host "- GarcomService: http://localhost:5002"
    Write-Host ""
    
    docker-compose ps
}

function Start-LocalServices {
    Write-Host "Para iniciar localmente, abra 3 terminais PowerShell separados:" -ForegroundColor Yellow
    Write-Host ""
    Write-Host "Terminal 1 - API Gateway:" -ForegroundColor Cyan
    Write-Host "cd MicroServices\ApiGateway`ndotnet run" -ForegroundColor Gray
    Write-Host ""
    Write-Host "Terminal 2 - ChefService:" -ForegroundColor Cyan
    Write-Host "cd MicroServices\ChefService`ndotnet run" -ForegroundColor Gray
    Write-Host ""
    Write-Host "Terminal 3 - GarcomService:" -ForegroundColor Cyan
    Write-Host "cd MicroServices\GarcomService`ndotnet run" -ForegroundColor Gray
    Write-Host ""
    Read-Host "Pressione ENTER para continuar"
}

function Build-Projects {
    Write-Host "Fazendo build dos projetos..." -ForegroundColor Green
    Write-Host ""
    
    $projects = @(
        "MicroServices\ApiGateway",
        "MicroServices\ChefService",
        "MicroServices\GarcomService"
    )
    
    foreach ($project in $projects) {
        Write-Host "Build do $project..." -ForegroundColor Yellow
        Set-Location $project
        dotnet build
        Set-Location ../..
        Write-Host ""
    }
    
    Write-Host "Build completo!" -ForegroundColor Green
}

function Stop-Containers {
    Write-Host "Parando containers..." -ForegroundColor Yellow
    docker-compose down -v
    Write-Host "Containers parados!" -ForegroundColor Green
}

function Check-Status {
    Write-Host "Status dos containers:" -ForegroundColor Green
    docker-compose ps
    Write-Host ""
    Write-Host "Health Checks:" -ForegroundColor Yellow
    
    try {
        $gatewayHealth = Invoke-RestMethod -Uri "http://localhost:5000/health" -ErrorAction SilentlyContinue
        Write-Host "API Gateway: OK ($($gatewayHealth.status))" -ForegroundColor Green
    } catch {
        Write-Host "API Gateway: ERRO" -ForegroundColor Red
    }
    
    Write-Host ""
    Read-Host "Pressione ENTER para continuar"
}

# Loop principal
do {
    Show-Menu
    $choice = Read-Host "Digite sua escolha (1-6)"
    
    switch ($choice) {
        "1" { Start-DockerCompose }
        "2" { Start-LocalServices }
        "3" { Build-Projects }
        "4" { Stop-Containers }
        "5" { Check-Status }
        "6" { exit }
        default { Write-Host "Opcao invalida!" -ForegroundColor Red }
    }
    
    if ($choice -ne "6") {
        Read-Host "Pressione ENTER para continuar"
    }
} while ($choice -ne "6")
