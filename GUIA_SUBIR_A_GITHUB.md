# ?? GUÍA PARA SUBIR A GITHUB

## ? OPCIÓN 1: Script Automático (Recomendado)

### Usando PowerShell:
1. Abre **PowerShell** en la carpeta del proyecto
2. Ejecuta el script:
   ```powershell
   .\SubirAGitHub.ps1
   ```

### Usando CMD (Command Prompt):
1. Abre **CMD** en la carpeta del proyecto
2. Ejecuta el script:
   ```cmd
   SubirAGitHub.bat
   ```

---

## ? OPCIÓN 2: Comandos Manuales

### En PowerShell o CMD:

```powershell
# 1. Verificar estado
git status

# 2. Agregar todos los archivos
git add .

# 3. Crear commit
git commit -m "feat: Sistema StockManager v2.0 completo con multi-idioma"

# 4. Subir a GitHub
git push origin main
```

---

## ?? SI HAY CONFLICTOS

Si aparece un error de que necesitas hacer pull primero:

```powershell
# 1. Descargar cambios remotos
git pull origin main --rebase

# 2. Resolver conflictos si hay (VS Code te ayudará)

# 3. Continuar el rebase
git rebase --continue

# 4. Subir los cambios
git push origin main
```

---

## ?? SI PIDE AUTENTICACIÓN

### GitHub ya no permite contraseñas, necesitas un **Personal Access Token**:

1. Ve a GitHub ? Settings ? Developer settings ? Personal access tokens
2. Click "Generate new token (classic)"
3. Dale permisos de "repo"
4. Copia el token generado
5. Cuando git pida contraseña, pega el token

**O configura SSH:**

```powershell
# Generar clave SSH
ssh-keygen -t ed25519 -C "tu@email.com"

# Copiar la clave pública
cat ~/.ssh/id_ed25519.pub

# Agregar a GitHub ? Settings ? SSH and GPG keys ? New SSH key
```

---

## ?? VERIFICAR QUE SE SUBIÓ

1. Ve a: https://github.com/MarianoCarames-UAI/StockManager
2. Verifica que veas todos los archivos
3. Verifica la fecha del último commit
4. Lee el README.md para confirmar

---

## ?? LO QUE SE VA A SUBIR

### Archivos incluidos:
? Código fuente de todos los proyectos
? Configuraciones de Entity Framework
? Formularios de la UI
? Servicios y lógica de negocio
? README.md y documentación
? .gitignore (excluye archivos innecesarios)
? appsettings.example.json (sin credenciales)

### Archivos EXCLUIDOS (por .gitignore):
? Archivos bin/ y obj/
? Archivos .vs/
? Archivos de usuario (.suo, .user)
? Packages de NuGet
? Logs
? Bases de datos (.mdf, .ldf)

---

## ?? SOLUCIÓN DE PROBLEMAS

### Error: "fatal: not a git repository"
```powershell
# Inicializar repositorio
git init
git remote add origin https://github.com/MarianoCarames-UAI/StockManager.git
```

### Error: "fatal: refusing to merge unrelated histories"
```powershell
git pull origin main --allow-unrelated-histories
```

### Error: "Updates were rejected"
```powershell
# Forzar push (¡CUIDADO! Solo si estás seguro)
git push origin main --force
```

### Ver historial de commits
```powershell
git log --oneline
```

### Ver archivos que se van a subir
```powershell
git status
git diff --staged
```

---

## ?? COMANDOS ÚTILES

```powershell
# Ver configuración de git
git config --list

# Configurar usuario (si no está configurado)
git config --global user.name "Tu Nombre"
git config --global user.email "tu@email.com"

# Ver remotos configurados
git remote -v

# Ver ramas
git branch -a

# Deshacer el último commit (sin perder cambios)
git reset --soft HEAD~1

# Ver qué archivos están trackeados
git ls-files
```

---

## ?? DESPUÉS DE SUBIR

1. **Verificar en GitHub** que todo se vea bien
2. **Actualizar el README** si es necesario
3. **Agregar un .gitattributes** para normalizar line endings (opcional)
4. **Configurar GitHub Actions** para CI/CD (opcional)
5. **Crear releases** para versiones importantes

---

## ?? TIPS FINALES

- ? Hacer commits frecuentes con mensajes descriptivos
- ? Usar el formato de commits: `tipo: descripción`
  - `feat:` nueva funcionalidad
  - `fix:` corrección de bug
  - `docs:` cambios en documentación
  - `style:` formateo de código
  - `refactor:` refactorización
- ? Hacer pull antes de push
- ? Revisar cambios antes de commitear
- ? No subir información sensible (contraseñas, tokens)

---

**¿Necesitas ayuda?** Revisa la [documentación de Git](https://git-scm.com/doc) o pregúntame.
