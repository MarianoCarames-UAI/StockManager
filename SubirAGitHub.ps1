# ========================================
# Script para subir StockManager a GitHub
# ========================================

Write-Host "=================================" -ForegroundColor Cyan
Write-Host "SUBIENDO STOCKMANAGER A GITHUB" -ForegroundColor Cyan
Write-Host "=================================" -ForegroundColor Cyan
Write-Host ""

# 1. Verificar ubicaci�n actual
Write-Host "1. Verificando ubicaci�n..." -ForegroundColor Yellow
$currentLocation = Get-Location
Write-Host "   Ubicaci�n actual: $currentLocation" -ForegroundColor Green
Write-Host ""

# 2. Verificar estado de git
Write-Host "2. Verificando estado de Git..." -ForegroundColor Yellow
try {
    $gitStatus = git status 2>&1
    Write-Host $gitStatus -ForegroundColor White
} catch {
    Write-Host "   Error al ejecutar git status" -ForegroundColor Red
    Write-Host "   Aseg�rate de que Git est� instalado" -ForegroundColor Red
    exit 1
}
Write-Host ""

# 3. Agregar archivos
Write-Host "3. Agregando archivos al staging area..." -ForegroundColor Yellow
try {
    git add .
    Write-Host "   ? Archivos agregados exitosamente" -ForegroundColor Green
} catch {
    Write-Host "   � Error al agregar archivos" -ForegroundColor Red
    exit 1
}
Write-Host ""

# 4. Mostrar archivos a commitear
Write-Host "4. Archivos preparados para commit:" -ForegroundColor Yellow
git status --short
Write-Host ""

# 5. Crear commit
Write-Host "5. Creando commit..." -ForegroundColor Yellow
$commitMessage = @"
feat: Sistema StockManager v2.0 completo

- Arquitectura en capas (UI, BLL, DAL, Services, Domain)
- Multi-idioma (Espa�ol/Ingl�s) con cambio din�mico en tiempo real
- Dise�o profesional y consistente en todos los formularios
- Autenticaci�n con hash BCrypt y sistema de roles
- CRUD completo de Clientes, Productos, Categor�as, Ventas
- Gesti�n de Stock con entradas y salidas
- Reportes din�micos (Ventas, Productos, Clientes)
- Panel de administraci�n (Usuarios, Roles, Sistema)
- Entity Framework Core con SQL Server
- Patr�n Repository + UnitOfWork
- Extension methods para DataGridView
- LocalizationService con evento OnLanguageChanged
- SessionManager para gesti�n de sesiones
- Botones de Cerrar Sesi�n y Salir
- Formularios con estilo consistente (ToolStrip + Panel + DataGridView)
"@

try {
    git commit -m $commitMessage
    Write-Host "   ? Commit creado exitosamente" -ForegroundColor Green
} catch {
    Write-Host "   � Error al crear commit" -ForegroundColor Red
    Write-Host "   Puede que no haya cambios para commitear" -ForegroundColor Yellow
}
Write-Host ""

# 6. Subir a GitHub
Write-Host "6. Subiendo a GitHub..." -ForegroundColor Yellow
Write-Host "   Repositorio: https://github.com/MarianoCarames-UAI/StockManager" -ForegroundColor Cyan

try {
    $pushResult = git push origin main 2>&1
    Write-Host $pushResult -ForegroundColor White
    
    if ($LASTEXITCODE -eq 0) {
        Write-Host ""
        Write-Host "=================================" -ForegroundColor Green
        Write-Host "? SUBIDA EXITOSA A GITHUB" -ForegroundColor Green
        Write-Host "=================================" -ForegroundColor Green
        Write-Host ""
        Write-Host "Tu proyecto est� disponible en:" -ForegroundColor Cyan
        Write-Host "https://github.com/MarianoCarames-UAI/StockManager" -ForegroundColor Cyan
    } else {
        Write-Host ""
        Write-Host "� Error al hacer push" -ForegroundColor Red
        Write-Host "Posibles causas:" -ForegroundColor Yellow
        Write-Host "  - Necesitas hacer 'git pull' primero" -ForegroundColor Yellow
        Write-Host "  - Problema de autenticaci�n" -ForegroundColor Yellow
        Write-Host "  - No tienes permisos en el repositorio" -ForegroundColor Yellow
    }
} catch {
    Write-Host "   � Error al hacer push: $($_.Exception.Message)" -ForegroundColor Red
}

Write-Host ""
Write-Host "Presiona cualquier tecla para continuar..."
$null = $Host.UI.RawUI.ReadKey("NoEcho,IncludeKeyDown")
