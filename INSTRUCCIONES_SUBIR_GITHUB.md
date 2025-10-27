# ?? SUBIR STOCKMANAGER A GITHUB - INSTRUCCIONES ESPEC�FICAS

## ?? TU SITUACI�N ACTUAL

- **Ubicaci�n del proyecto**: `C:\Users\maria\source\repos`
- **Repositorio GitHub**: `https://github.com/MarianoCarames-UAI/StockManager`
- **Rama**: `main`

---

## ? PASOS PARA SUBIR TU PROYECTO

### 1?? Abrir Git Bash o PowerShell

#### Opci�n A: Git Bash (Recomendado)
1. Click derecho en la carpeta `C:\Users\maria\source\repos`
2. Selecciona "Git Bash Here"
3. Se abrir� una terminal

#### Opci�n B: PowerShell
1. En el Explorador de archivos, ve a `C:\Users\maria\source\repos`
2. Mant�n presionada la tecla `Shift`
3. Click derecho en un espacio vac�o
4. Selecciona "Abrir PowerShell aqu�" o "Abrir ventana de comandos aqu�"

---

### 2?? Ejecutar los Comandos

Copia y pega estos comandos **UNO POR UNO**:

```bash
# Verificar estado
git status

# Agregar todos los archivos
git add .

# Ver qu� se agreg�
git status

# Crear commit
git commit -m "feat: Sistema StockManager v2.0 completo - Multi-idioma y dise�o profesional"

# Subir a GitHub
git push origin main
```

---

### 3?? Si Git Pide Autenticaci�n

Si aparece un popup pidiendo autenticaci�n:

1. **Usuario**: Tu nombre de usuario de GitHub
2. **Contrase�a**: Debes usar un **Personal Access Token**, NO tu contrase�a de GitHub

#### �C�mo obtener un Personal Access Token?

1. Ve a: https://github.com/settings/tokens
2. Click en "Generate new token" ? "Generate new token (classic)"
3. Dale un nombre: `StockManager Upload`
4. Marca el checkbox: `repo` (acceso completo a repositorios)
5. Click "Generate token"
6. **COPIA EL TOKEN** (solo se muestra una vez)
7. Usa ese token como contrase�a cuando git lo pida

---

### 4?? Si Aparece Error "Updates were rejected"

Significa que hay cambios en GitHub que no tienes localmente. Ejecuta:

```bash
# Descargar cambios remotos
git pull origin main --rebase

# Subir tus cambios
git push origin main
```

---

## ?? M�TODO ALTERNATIVO: Visual Studio

### Si usas Visual Studio 2022:

1. Abre la soluci�n en Visual Studio
2. Ve al men� "Git" ? "Commit or Stash"
3. Escribe el mensaje del commit:
   ```
   feat: Sistema StockManager v2.0 completo - Multi-idioma y dise�o profesional
   ```
4. Click en "Commit All"
5. Click en "Push"

---

## ?? VERIFICAR QUE SE SUBI�

1. Abre tu navegador
2. Ve a: https://github.com/MarianoCarames-UAI/StockManager
3. Deber�as ver todos tus archivos
4. Verifica que el �ltimo commit tenga la fecha de hoy

---

## ?? SI NADA FUNCIONA

### M�todo de Emergencia - GitHub Desktop:

1. Descarga **GitHub Desktop**: https://desktop.github.com/
2. Inst�lalo y �brelo
3. Click "File" ? "Add Local Repository"
4. Selecciona la carpeta: `C:\Users\maria\source\repos`
5. Escribe el mensaje del commit
6. Click "Commit to main"
7. Click "Push origin"

---

## ?? ARCHIVOS QUE YA EST�N LISTOS

He creado estos archivos para ayudarte:

- ? `.gitignore` - Excluye archivos innecesarios
- ? `appsettings.example.json` - Plantilla sin credenciales
- ? `SubirAGitHub.ps1` - Script de PowerShell
- ? `SubirAGitHub.bat` - Script de CMD
- ? `GUIA_SUBIR_A_GITHUB.md` - Gu�a detallada

---

## ?? COMANDOS R�PIDOS

### Ver qu� cambios hay:
```bash
git status
```

### Ver el historial de commits:
```bash
git log --oneline
```

### Ver las diferencias:
```bash
git diff
```

### Ver remotos configurados:
```bash
git remote -v
```

---

## ? RESUMEN EJECUTIVO

**En Git Bash o PowerShell, ejecuta:**

```bash
git add .
git commit -m "feat: Sistema StockManager v2.0 completo"
git push origin main
```

**�Y listo!** Tu proyecto estar� en GitHub en https://github.com/MarianoCarames-UAI/StockManager

---

**Fecha de creaci�n**: $(Get-Date)
**Estado**: ? ESPERANDO SUBIDA
