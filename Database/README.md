# ??? Configuraci�n de Base de Datos - StockManager v2.0

## ?? Requisitos Previos

- SQL Server 2019 o superior (o LocalDB)
- .NET 8 SDK
- EF Core Tools instaladas

## ?? Opci�n 1: Crear Base de Datos con Migraciones (RECOMENDADO)

### Paso 1: Verificar Connection String

Abre `StockManager.UI/appsettings.json` y verifica la cadena de conexi�n:

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

- **SQL Server con autenticaci�n**:
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

### Paso 3: Crear la Migraci�n Inicial

Desde la ra�z de la soluci�n, ejecuta:

```bash
dotnet ef migrations add InitialCreate --project StockManager.DAL --startup-project StockManager.UI
```

Esto crear� la carpeta `Migrations` en `StockManager.DAL` con los archivos de migraci�n.

### Paso 4: Aplicar la Migraci�n (Crear la BD)

```bash
dotnet ef database update --project StockManager.DAL --startup-project StockManager.UI
```

Esto crear�:
- ? Base de datos `StockManagerDB`
- ? Todas las tablas
- ? �ndices y restricciones
- ? Seed data (Roles, Categor�as, Admin)

### Paso 5: Actualizar el Password del Admin

El seed data incluye un hash placeholder. Ejecuta este script SQL o usa el DbInitializer:

**Opci�n A - Desde SQL Server Management Studio:**

```sql
-- Actualizar con hash BCrypt real
UPDATE Empleados 
SET PasswordHash = '$2a$11$[hash_generado_aqui]'
WHERE Id = 1 AND Email = 'admin@stockmanager.com';
```

**Opci�n B - Desde c�digo (RECOMENDADO):**

El proyecto incluye `DbInitializer.cs` que actualiza autom�ticamente el password al iniciar la aplicaci�n.

## ?? Opci�n 2: Crear Base de Datos con Script SQL

Si prefieres crear la base de datos manualmente:

### Paso 1: Generar el Script SQL

```bash
dotnet ef migrations script --project StockManager.DAL --startup-project StockManager.UI --output Database/DatabaseScript.sql
```

### Paso 2: Ejecutar el Script

Abre SQL Server Management Studio y ejecuta el archivo `Database/DatabaseScript.sql`.

## ?? Verificar la Instalaci�n

### Tablas Creadas

- ? Roles (3 roles predefinidos)
- ? Empleados (1 admin: admin@stockmanager.com)
- ? Categorias (4 categor�as predefinidas)
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
3. Administrador de Dep�sito (stock y productos)

**Categor�as:**
1. General
2. Electr�nica
3. Alimentos
4. Ropa

**Usuario Admin:**
- Email: `admin@stockmanager.com`
- Password: `Admin123!`
- Rol: Administrador

## ?? Comandos �tiles de Migraciones

### Ver lista de migraciones
```bash
dotnet ef migrations list --project StockManager.DAL --startup-project StockManager.UI
```

### Agregar nueva migraci�n
```bash
dotnet ef migrations add NombreMigracion --project StockManager.DAL --startup-project StockManager.UI
```

### Revertir �ltima migraci�n
```bash
dotnet ef migrations remove --project StockManager.DAL --startup-project StockManager.UI
```

### Actualizar a una migraci�n espec�fica
```bash
dotnet ef database update NombreMigracion --project StockManager.DAL --startup-project StockManager.UI
```

### Eliminar base de datos
```bash
dotnet ef database drop --project StockManager.DAL --startup-project StockManager.UI
```

## ??? Troubleshooting

### Error: "Cannot open database"
- Verifica que SQL Server est� corriendo
- Verifica la connection string en appsettings.json
- Si usas LocalDB: `sqllocaldb start mssqllocaldb`

### Error: "Login failed for user"
- Verifica las credenciales en la connection string
- Aseg�rate de tener permisos en SQL Server

### Error: "Build failed"
- Ejecuta `dotnet build` desde la ra�z
- Verifica que todos los proyectos compilen

### Error en migraciones
- Elimina la carpeta `Migrations`
- Ejecuta nuevamente `dotnet ef migrations add InitialCreate`

## ?? Agregar Datos de Prueba

Para agregar productos, clientes y proveedores de prueba:

```csharp
// En Program.cs o al iniciar la aplicaci�n
using var scope = serviceProvider.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<StockManagerContext>();
await DbInitializer.SeedTestDataAsync(context);
```

Esto agregar�:
- 4 Productos con stock
- 2 Clientes
- 2 Proveedores

## ? Verificaci�n Final

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

**�La base de datos est� lista para usar!** ??

Pr�ximo paso: Ejecutar la aplicaci�n y hacer login con:
- Email: `admin@stockmanager.com`
- Password: `Admin123!`
