# ??? Configuración de Base de Datos - StockManager v2.0

## ?? Requisitos Previos

- SQL Server 2019 o superior (o LocalDB)
- .NET 8 SDK
- EF Core Tools instaladas

## ?? Opción 1: Crear Base de Datos con Migraciones (RECOMENDADO)

### Paso 1: Verificar Connection String

Abre `StockManager.UI/appsettings.json` y verifica la cadena de conexión:

```json
{
  "ConnectionStrings": {
    "StockManagerDB": "Server=(localdb)\\mssqllocaldb;Database=StockManagerDB;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;"
  }
}
```

**Opciones de Connection String:**

- **LocalDB** (Desarrollo local):
  ```
  Server=(localdb)\\mssqllocaldb;Database=StockManagerDB;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;
  ```

- **SQL Server Express**:
  ```
  Server=.\\SQLEXPRESS;Database=StockManagerDB;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;
  ```

- **SQL Server con autenticación**:
  ```
  Server=localhost;Database=StockManagerDB;User Id=sa;Password=TuPassword;MultipleActiveResultSets=true;TrustServerCertificate=True;
  ```

### Paso 2: Instalar EF Core Tools (si no lo tienes)

```bash
dotnet tool install --global dotnet-ef
```

O actualizar:
```bash
dotnet tool update --global dotnet-ef
```

### Paso 3: Crear la Migración Inicial

Desde la raíz de la solución, ejecuta:

```bash
dotnet ef migrations add InitialCreate --project StockManager.DAL --startup-project StockManager.UI
```

Esto creará la carpeta `Migrations` en `StockManager.DAL` con los archivos de migración.

### Paso 4: Aplicar la Migración (Crear la BD)

```bash
dotnet ef database update --project StockManager.DAL --startup-project StockManager.UI
```

Esto creará:
- ? Base de datos `StockManagerDB`
- ? Todas las tablas
- ? Índices y restricciones
- ? Seed data (Roles, Categorías, Admin)

### Paso 5: Actualizar el Password del Admin

El seed data incluye un hash placeholder. Ejecuta este script SQL o usa el DbInitializer:

**Opción A - Desde SQL Server Management Studio:**

```sql
-- Actualizar con hash BCrypt real
UPDATE Empleados 
SET PasswordHash = '$2a$11$[hash_generado_aqui]'
WHERE Id = 1 AND Email = 'admin@stockmanager.com';
```

**Opción B - Desde código (RECOMENDADO):**

El proyecto incluye `DbInitializer.cs` que actualiza automáticamente el password al iniciar la aplicación.

## ?? Opción 2: Crear Base de Datos con Script SQL

Si prefieres crear la base de datos manualmente:

### Paso 1: Generar el Script SQL

```bash
dotnet ef migrations script --project StockManager.DAL --startup-project StockManager.UI --output Database/DatabaseScript.sql
```

### Paso 2: Ejecutar el Script

Abre SQL Server Management Studio y ejecuta el archivo `Database/DatabaseScript.sql`.

## ?? Verificar la Instalación

### Tablas Creadas

- ? Roles (3 roles predefinidos)
- ? Empleados (1 admin: admin@stockmanager.com)
- ? Categorias (4 categorías predefinidas)
- ? Clientes
- ? Productos
- ? Stocks
- ? Proveedores
- ? EntradasStock
- ? Ventas
- ? DetallesVenta
- ? Bitacoras
- ? Excepciones
- ? Traducciones

### Datos Iniciales (Seed Data)

**Roles:**
1. Administrador (acceso total)
2. Administrador de Ventas (ventas y clientes)
3. Administrador de Depósito (stock y productos)

**Categorías:**
1. General
2. Electrónica
3. Alimentos
4. Ropa

**Usuario Admin:**
- Email: `admin@stockmanager.com`
- Password: `Admin123!`
- Rol: Administrador

## ?? Comandos Útiles de Migraciones

### Ver lista de migraciones
```bash
dotnet ef migrations list --project StockManager.DAL --startup-project StockManager.UI
```

### Agregar nueva migración
```bash
dotnet ef migrations add NombreMigracion --project StockManager.DAL --startup-project StockManager.UI
```

### Revertir última migración
```bash
dotnet ef migrations remove --project StockManager.DAL --startup-project StockManager.UI
```

### Actualizar a una migración específica
```bash
dotnet ef database update NombreMigracion --project StockManager.DAL --startup-project StockManager.UI
```

### Eliminar base de datos
```bash
dotnet ef database drop --project StockManager.DAL --startup-project StockManager.UI
```

## ??? Troubleshooting

### Error: "Cannot open database"
- Verifica que SQL Server esté corriendo
- Verifica la connection string en appsettings.json
- Si usas LocalDB: `sqllocaldb start mssqllocaldb`

### Error: "Login failed for user"
- Verifica las credenciales en la connection string
- Asegúrate de tener permisos en SQL Server

### Error: "Build failed"
- Ejecuta `dotnet build` desde la raíz
- Verifica que todos los proyectos compilen

### Error en migraciones
- Elimina la carpeta `Migrations`
- Ejecuta nuevamente `dotnet ef migrations add InitialCreate`

## ?? Agregar Datos de Prueba

Para agregar productos, clientes y proveedores de prueba:

```csharp
// En Program.cs o al iniciar la aplicación
using var scope = serviceProvider.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<StockManagerContext>();
await DbInitializer.SeedTestDataAsync(context);
```

Esto agregará:
- 4 Productos con stock
- 2 Clientes
- 2 Proveedores

## ? Verificación Final

Ejecuta este query para verificar:

```sql
-- Verificar tablas
SELECT TABLE_NAME 
FROM INFORMATION_SCHEMA.TABLES 
WHERE TABLE_TYPE = 'BASE TABLE'
ORDER BY TABLE_NAME;

-- Verificar seed data
SELECT * FROM Roles;
SELECT * FROM Categorias;
SELECT Id, Email, Nombre, Apellido FROM Empleados;

-- Verificar relaciones
SELECT 
    fk.name AS 'Foreign Key',
    OBJECT_NAME(fk.parent_object_id) AS 'Table',
    COL_NAME(fc.parent_object_id, fc.parent_column_id) AS 'Column',
    OBJECT_NAME(fk.referenced_object_id) AS 'Referenced Table'
FROM sys.foreign_keys AS fk
INNER JOIN sys.foreign_key_columns AS fc 
    ON fk.object_id = fc.constraint_object_id;
```

---

**¡La base de datos está lista para usar!** ??

Próximo paso: Ejecutar la aplicación y hacer login con:
- Email: `admin@stockmanager.com`
- Password: `Admin123!`
