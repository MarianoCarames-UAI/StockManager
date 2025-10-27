# ========================================
# Script para subir StockManager a GitHub
# ========================================

Write-Host "=================================" -ForegroundColor Cyan
Write-Host "SUBIENDO STOCKMANAGER A GITHUB" -ForegroundColor Cyan
Write-Host "=================================" -ForegroundColor Cyan
Write-Host ""

# 1. Verificar ubicación actual
Write-Host "1. Verificando ubicación..." -ForegroundColor Yellow
$currentLocation = Get-Location
Write-Host "   Ubicación actual: $currentLocation" -ForegroundColor Green
Write-Host ""

# 2. Verificar estado de git
Write-Host "2. Verificando estado de Git..." -ForegroundColor Yellow
try {
    $gitStatus = git status 2>&1
    Write-Host $gitStatus -ForegroundColor White
} catch {
    Write-Host "   Error al ejecutar git status" -ForegroundColor Red
    Write-Host "   Asegúrate de que Git esté instalado" -ForegroundColor Red
    exit 1
}
Write-Host ""

# 3. Agregar archivos
Write-Host "3. Agregando archivos al staging area..." -ForegroundColor Yellow
try {
    git add .
    Write-Host "   ? Archivos agregados exitosamente" -ForegroundColor Green
} catch {
    Write-Host "   × Error al agregar archivos" -ForegroundColor Red
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
- Multi-idioma (Español/Inglés) con cambio dinámico en tiempo real
- Diseño profesional y consistente en todos los formularios
- Autenticación con hash BCrypt y sistema de roles
- CRUD completo de Clientes, Productos, Categorías, Ventas
- Gestión de Stock con entradas y salidas
- Reportes dinámicos (Ventas, Productos, Clientes)
- Panel de administración (Usuarios, Roles, Sistema)
- Entity Framework Core con SQL Server
- Patrón Repository + UnitOfWork
- Extension methods para DataGridView
- LocalizationService con evento OnLanguageChanged
- SessionManager para gestión de sesiones
- Botones de Cerrar Sesión y Salir
- Formularios con estilo consistente (ToolStrip + Panel + DataGridView)
"@

try {
    git commit -m $commitMessage
    Write-Host "   ? Commit creado exitosamente" -ForegroundColor Green
} catch {
    Write-Host "   × Error al crear commit" -ForegroundColor Red
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
        Write-Host "Tu proyecto está disponible en:" -ForegroundColor Cyan
        Write-Host "https://github.com/MarianoCarames-UAI/StockManager" -ForegroundColor Cyan
    } else {
        Write-Host ""
        Write-Host "× Error al hacer push" -ForegroundColor Red
        Write-Host "Posibles causas:" -ForegroundColor Yellow
        Write-Host "  - Necesitas hacer 'git pull' primero" -ForegroundColor Yellow
        Write-Host "  - Problema de autenticación" -ForegroundColor Yellow
        Write-Host "  - No tienes permisos en el repositorio" -ForegroundColor Yellow
    }
} catch {
    Write-Host "   × Error al hacer push: $($_.Exception.Message)" -ForegroundColor Red
}

Write-Host ""
Write-Host "Presiona cualquier tecla para continuar..."
$null = $Host.UI.RawUI.ReadKey("NoEcho,IncludeKeyDown")
