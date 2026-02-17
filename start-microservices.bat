@echo off
REM Script para iniciar todos os microserviços no Windows

echo ====================================
echo SolutionKitchen - Microservices
echo ====================================
echo.

echo Escolha uma opcao:
echo 1. Iniciar com Docker Compose
echo 2. Iniciar localmente (requer 3 terminais)
echo 3. Build dos projetos
echo 4. Limpar containers
echo.

set /p choice=Digite sua escolha (1-4):

if "%choice%"=="1" (
    echo.
    echo Iniciando Docker Compose...
    docker-compose up -d
    echo.
    echo Aguardando inicializacao...
    timeout /t 10 /nobreak
    echo.
    echo Servicos iniciados:
    echo - API Gateway: http://localhost:5000
    echo - ChefService: http://localhost:5001
    echo - GarcomService: http://localhost:5002
    echo.
    docker-compose ps
) else if "%choice%"=="2" (
    echo.
    echo Para iniciar localmente, abra 3 terminais separados:
    echo.
    echo Terminal 1 - API Gateway:
    echo cd MicroServices\ApiGateway
    echo dotnet run
    echo.
    echo Terminal 2 - ChefService:
    echo cd MicroServices\ChefService
    echo dotnet run
    echo.
    echo Terminal 3 - GarcomService:
    echo cd MicroServices\GarcomService
    echo dotnet run
    echo.
    pause
) else if "%choice%"=="3" (
    echo.
    echo Fazendo build dos projetos...
    echo.
    
    echo Build do ApiGateway...
    cd MicroServices\ApiGateway
    dotnet build
    
    echo.
    echo Build do ChefService...
    cd ..\ChefService
    dotnet build
    
    echo.
    echo Build do GarcomService...
    cd ..\GarcomService
    dotnet build
    
    echo.
    echo Build completo!
    pause
) else if "%choice%"=="4" (
    echo.
    echo Limpando containers...
    docker-compose down -v
    echo Containers removidos!
) else (
    echo Opcao invalida!
)

pause
