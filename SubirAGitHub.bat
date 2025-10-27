@echo off
echo =========================================
echo SUBIENDO STOCKMANAGER A GITHUB
echo =========================================
echo.

echo 1. Verificando estado...
git status
echo.

echo 2. Agregando archivos...
git add .
echo.

echo 3. Creando commit...
git commit -m "feat: Sistema StockManager v2.0 completo - Multi-idioma - Diseno profesional"
echo.

echo 4. Subiendo a GitHub...
git push origin main
echo.

if %ERRORLEVEL% EQU 0 (
    echo =========================================
    echo SUBIDA EXITOSA A GITHUB
    echo =========================================
    echo.
    echo Tu proyecto esta disponible en:
    echo https://github.com/MarianoCarames-UAI/StockManager
) else (
    echo =========================================
    echo ERROR AL SUBIR A GITHUB
    echo =========================================
    echo.
    echo Intenta ejecutar manualmente:
    echo   git pull origin main
    echo   git push origin main
)

echo.
pause
