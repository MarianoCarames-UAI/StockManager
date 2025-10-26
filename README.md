# StockManager v2.0

Sistema integral de gestión de stock desarrollado en **C# WinForms (.NET 8)** con base de datos **SQL Server**. Esta aplicación empresarial permite administrar inventarios, controlar productos, realizar seguimiento de movimientos de stock, gestionar ventas y proveedores con una arquitectura robusta basada en patrones de diseño y mejores prácticas.

## 📋 Descripción General

StockManager v2.0 es una solución completa que cubre todos los aspectos de la gestión de inventario para empresas, desde el control de entradas y salidas de productos hasta la administración de ventas, clientes, proveedores y empleados. El sistema implementa seguridad por roles, auditoría completa, multi-idioma y funcionalidades de backup/restore.

## 🏗️ Arquitectura

El proyecto está organizado en una arquitectura en capas con separación de responsabilidades:

### Proyectos de la Solución

- **StockManager.UI** - Interfaz de usuario WinForms (.NET 8)
- **StockManager.Domain** - Entidades del dominio y enumeraciones
- **StockManager.BLL** - Lógica de negocio, validaciones y orquestación
- **StockManager.DAL** - Acceso a datos con SQL Server (Repositorios + UnitOfWork)
- **StockManager.Services** - Servicios de arquitectura base (Bitácora, Seguridad, Backup, Criptografía, i18n)

### Patrones de Diseño Implementados

- **Repository + UnitOfWork** - Abstracción del acceso a datos y transacciones
- **Facade** - Agrupación de servicios de arquitectura base
- **Strategy** - Proveedores intercambiables (encriptación BCrypt/PBKDF2, bitácora archivo/DB)
- **Singleton** - Configuración de aplicación centralizada
- **Factory Method** - Instanciación de diferentes tipos de reportes
- **Composite** - Estructura de menú y navegación jerárquica
- **Adapter** - Bitácora a múltiples destinos
- **DTO + Mappers** - Transferencia de datos entre capas

## 🎯 Características Principales

### Gestión de Clientes
- Alta, modificación y deshabilitación de clientes
- Búsqueda por DNI/CUIT, nombre o razón social
- Validación de documentos duplicados
- Estados activo/inactivo

### Gestión de Productos y Categorías
- ABM completo de productos con categorización
- Control de precios (unitario y costo)
- Gestión de categorías con estados
- Relación productos-categorías

### Control de Stock
- **Entradas de Stock**: registro de compras a proveedores con precio y cantidad
- **Salidas de Stock**: automáticas por ventas o manuales
- **Inventario en tiempo real**: consulta de stock actual por producto
- **Alertas de reorden**: niveles mínimos configurables
- **Auditoría de movimientos**: historial completo de entradas/salidas

### Gestión de Ventas
- **Nueva Venta**: selección de cliente, productos con verificación de stock en tiempo real
- **Cálculo automático** de subtotales y totales
- **Actualización automática** de stock al cerrar venta
- **Modificación de ventas** (solo Administrador)
- **Persistencia transaccional**: Venta + DetalleVenta + actualización de stock

### Proveedores
- Registro completo de proveedores
- Alta, modificación y gestión de estado
- Vinculación con entradas de stock

### Empleados y Roles
- **Roles del sistema**:
  - **Administrador**: acceso total al sistema
  - **Administrador de Ventas**: gestión de ventas y clientes
  - **Administrador de Depósito**: gestión de stock y productos
- **Gestión de empleados**: alta, modificación, asignación de roles
- **Autenticación segura**: hash de contraseñas con BCrypt

### Reportes
- **Ventas diarias**: reporte por fecha específica
- **Ventas por período**: análisis de rango de fechas
- **Stock actual**: inventario completo o filtrado
- **Top productos**: ranking por cantidad vendida
- **Ventas por empleado**: análisis de desempeño
- **Ventas por producto/categoría**: análisis de tendencias
- **Exportación**: CSV y PDF

### Seguridad
- **Sistema de login** con usuario y contraseña
- **Hash de contraseñas** con BCrypt (estrategia intercambiable)
- **Autorización por roles**: restricción de accesos según perfil
- **Sesión de usuario** mantenida en memoria
- **Auditoría de accesos**: registro de logins exitosos y fallidos

### Bitácora y Auditoría
- **Bitácora completa** de todas las operaciones
- **Registro a archivo** (TXT/JSON) con rotación diaria
- **Niveles de severidad**: Alta, Media, Baja
- **Tipos de log**: Usuario, Sistema
- **Gestión de excepciones** centralizada con registro detallado
- **Trazabilidad completa**: quién, qué, cuándo

### Multi-idioma (i18n)
- **Soporte para múltiples idiomas**: Español (es-AR) e Inglés (en-US)
- **Resources (.resx)** para toda la interfaz
- **Almacenamiento en BD** de traducciones personalizadas
- **Selector de idioma** con actualización en tiempo real
- **Mensajes y etiquetas** completamente traducibles

### Backup y Restore
- **Backup de base de datos** a ruta configurable
- **Restore de backups** con validación
- **Interfaz gráfica** para operaciones de backup/restore
- **Registro en bitácora** de todas las operaciones
- **Exclusivo para Administrador**

### Configuración
- **ApplicationSettings** (Singleton) centralizada
- **appsettings.json** para configuración externa
- Parámetros configurables:
  - Cadena de conexión SQL Server
  - Ruta de bitácora
  - Carpeta de backups
  - Idioma por defecto
  - Parámetros de seguridad

## 💾 Tecnologías

- **Lenguaje**: C# 12 (.NET 8)
- **UI Framework**: Windows Forms (WinForms)
- **Base de Datos**: SQL Server (2019 o superior)
- **ORM**: Entity Framework Core (Code-First)
- **Criptografía**: BCrypt.Net
- **Logging**: Sistema de bitácora personalizado

## 📊 Modelo de Datos

### Entidades Principales

#### Cliente
- Nombre, Apellido
- DNI/CUIT (con tipo de documento)
- Dirección, Teléfono, Email
- Fecha de Alta
- Estado (Activo/Inactivo)

#### Producto
- Código/ID de Producto
- Nombre, Descripción
- Categoría (FK)
- Precio Unitario, Costo Unitario
- Fechas de Alta y Modificación

#### Categoría
- ID de Categoría
- Nombre, Descripción
- Estado
- Fecha de creación

#### Proveedor
- ID de Proveedor
- Nombre, Dirección
- Teléfono, Email
- Estado, Fecha de Alta

#### Stock/StockProducto
- ID de Stock
- ID de Producto (FK)
- Cantidad actual
- Fecha de Ingreso/Modificación
- Cantidad de Reorden (nivel mínimo)

#### EntradaStock
- ID de Entrada
- ID de Producto (FK)
- ID de Proveedor (FK)
- Cantidad, Precio Unitario
- Fecha, Tipo de Entrada

#### Venta
- ID de Venta
- Fecha
- ID de Cliente (FK)
- ID de Vendedor/Empleado (FK)
- Total

#### DetalleVenta
- ID de Detalle
- ID de Venta (FK)
- ID de Producto (FK)
- Cantidad, Precio Unitario
- Subtotal

#### Empleado
- ID de Empleado
- Nombre, Email
- Fecha de Nacimiento
- ID de Rol (FK)
- Password Hash

#### Rol
- ID de Rol
- Descripción
- Permisos asociados

### Servicios de Arquitectura Base

#### Bitácora
- Tipo de Log (Usuario/Sistema)
- Severidad (Alta/Media/Baja)
- Mensaje, Fecha
- Usuario que ejecutó la acción

#### Excepción
- Registro detallado de errores
- Stack trace, mensaje
- Usuario y contexto

#### Traducción
- Idioma, Clave, Valor
- Soporte multi-idioma

## 🚀 Instalación y Configuración

### Requisitos Previos

- .NET 8 SDK o superior
- SQL Server 2019 o superior
- Visual Studio 2022 (recomendado)

### Pasos de Instalación

1. **Clonar el repositorio**
   ```bash
   git clone https://github.com/MarianoCarames-UAI/StockManager.git
   cd StockManager
   ```

2. **Configurar la cadena de conexión**
   - Editar `appsettings.json` en el proyecto StockManager.UI
   - Actualizar la cadena de conexión a SQL Server:
   ```json
   {
     "ConnectionStrings": {
       "StockManagerDB": "Server=localhost;Database=StockManagerDB;Trusted_Connection=True;TrustServerCertificate=True;"
     }
   }
   ```

3. **Crear la base de datos**
   
   **Opción A - Migraciones EF Core:**
   ```bash
   cd StockManager.DAL
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   ```
   
   **Opción B - Script SQL:**
   - Ejecutar el script `DatabaseScript.sql` incluido en la carpeta `/Database`

4. **Compilar la solución**
   ```bash
   dotnet build
   ```

5. **Ejecutar la aplicación**
   ```bash
   cd StockManager.UI
   dotnet run
   ```

### Datos de Acceso Inicial

- **Usuario Admin**: admin
- **Contraseña**: Admin123!

## 📁 Estructura del Proyecto

```
StockManager/
├── StockManager.UI/                 # Interfaz WinForms
│   ├── Forms/
│   │   ├── Auth/                   # Login, cambio de contraseña
│   │   ├── Clientes/               # ABM Clientes
│   │   ├── Productos/              # ABM Productos y Categorías
│   │   ├── Stock/                  # Gestión de stock
│   │   ├── Ventas/                 # Nueva venta, modificación
│   │   ├── Proveedores/            # ABM Proveedores
│   │   ├── Empleados/              # ABM Empleados
│   │   ├── Reportes/               # Formularios de reportes
│   │   └── Admin/                  # Backup, configuración
│   ├── Resources/                  # Archivos .resx multi-idioma
│   └── appsettings.json
│
├── StockManager.Domain/             # Entidades del dominio
│   ├── Entities/
│   │   ├── Cliente.cs
│   │   ├── Producto.cs
│   │   ├── Categoria.cs
│   │   ├── Proveedor.cs
│   │   ├── Stock.cs
│   │   ├── EntradaStock.cs
│   │   ├── Venta.cs
│   │   ├── DetalleVenta.cs
│   │   ├── Empleado.cs
│   │   └── Rol.cs
│   └── Enums/
│       ├── TipoDocumento.cs
│       ├── EstadoCliente.cs
│       ├── TipoLog.cs
│       └── Severidad.cs
│
├── StockManager.BLL/                # Lógica de negocio
│   ├── Services/
│   │   ├── ClienteService.cs
│   │   ├── ProductoService.cs
│   │   ├── StockService.cs
│   │   ├── VentaService.cs
│   │   ├── ProveedorService.cs
│   │   └── EmpleadoService.cs
│   ├── Validators/
│   └── DTOs/
│
├── StockManager.DAL/                # Acceso a datos
│   ├── Context/
│   │   └── StockManagerContext.cs
│   ├── Repositories/
│   │   ├── IRepository.cs
│   │   ├── ClienteRepository.cs
│   │   ├── ProductoRepository.cs
│   │   ├── VentaRepository.cs
│   │   └── ...
│   ├── UnitOfWork/
│   │   ├── IUnitOfWork.cs
│   │   └── UnitOfWork.cs
│   └── Migrations/
│
├── StockManager.Services/           # Servicios de arquitectura
│   ├── Logging/
│   │   ├── IBitacoraService.cs
│   │   ├── BitacoraFileService.cs
│   │   └── BitacoraDBService.cs
│   ├── Security/
│   │   ├── IEncryptionStrategy.cs
│   │   ├── BCryptStrategy.cs
│   │   └── PBKDF2Strategy.cs
│   ├── Configuration/
│   │   └── ApplicationSettings.cs
│   ├── Backup/
│   │   └── BackupService.cs
│   ├── Localization/
│   │   └── LocalizationService.cs
│   └── Facade/
│       └── ServicesFacade.cs
│
└── Database/
    └── DatabaseScript.sql           # Script de creación inicial
```

## 🔒 Validaciones y Reglas de Negocio

### En BLL (Business Logic Layer)

- **Clientes**: No duplicar por documento (DNI/CUIT)
- **Ventas**: Verificación de stock suficiente antes de confirmar
- **Precios**: Validación de valores positivos (> 0)
- **Cantidades**: Validación de valores enteros positivos
- **Stock**: No permitir stock negativo
- **Proveedores**: Email con formato válido

### En DAL (Data Access Layer)

- **Transacciones**: UnitOfWork para operaciones complejas (Venta + DetalleVenta + Stock)
- **Integridad referencial**: Foreign Keys configuradas
- **Índices**: Optimización de consultas frecuentes
- **Restricciones**: CHECK constraints para reglas de BD

### En UI (User Interface)

- **Campos obligatorios**: ErrorProvider de WinForms
- **Formatos**: Validación de emails, teléfonos, documentos
- **Mensajes traducidos**: Feedback multi-idioma
- **Confirmaciones**: Diálogos para operaciones críticas

## 📈 Casos de Uso Implementados

### CU01: Gestión de Clientes
- Alta de cliente con validación de duplicados
- Modificación de datos del cliente
- Deshabilitación (baja lógica)
- Búsqueda y listado con filtros

### CU02: Gestión de Productos
- Alta de producto con categoría
- Modificación de producto
- Consulta de productos por categoría
- Gestión de categorías

### CU03: Entrada de Stock
- Registrar entrada desde proveedor
- Actualizar stock automáticamente
- Registrar precio y cantidad
- Auditoría de movimiento

### CU04: Nueva Venta
- Seleccionar/crear cliente
- Agregar productos con verificación de stock
- Cálculo automático de totales
- Confirmación y actualización de stock
- Generación de comprobante

### CU05: Modificación de Venta (Admin)
- Ajuste de detalles de venta existente
- Reversión/ajuste de stock
- Auditoría de cambios

### CU06: Reportes
- Generación de reportes por criterios
- Filtros por fecha, producto, categoría
- Exportación a CSV/PDF
- Visualización en grilla

### CU07: Backup y Restore
- Backup manual de base de datos
- Restore desde archivo de backup
- Validación de operaciones
- Solo para Administrador

## 🌐 Multi-idioma

El sistema soporta múltiples idiomas con cambio dinámico:

- **Español (Argentina)** - es-AR (por defecto)
- **English (US)** - en-US

### Agregar un Nuevo Idioma

1. Crear archivos `.resx` en `StockManager.UI/Resources/`
2. Agregar traducciones en la base de datos (tabla `Traduccion`)
3. Actualizar el selector de idioma

## 🛡️ Seguridad

- **Autenticación**: Login con usuario y contraseña hasheada
- **Autorización**: Control de acceso basado en roles
- **Encriptación**: BCrypt para contraseñas (configurable)
- **Sesión**: Gestión de sesión de usuario activo
- **Auditoría**: Registro de todos los accesos y operaciones

## 📝 Bitácora

Todas las operaciones se registran en:

- **Archivo de texto/JSON**: Rotación diaria en carpeta configurada
- **Base de datos** (opcional): Tabla Bitacora

### Eventos Registrados

- Logins exitosos y fallidos
- ABM de todas las entidades
- Movimientos de stock
- Ventas y modificaciones
- Generación de reportes
- Backups y restores
- Excepciones y errores

## 🔧 Configuración Avanzada

### appsettings.json

```json
{
  "ConnectionStrings": {
    "StockManagerDB": "Server=localhost;Database=StockManagerDB;Trusted_Connection=True;TrustServerCertificate=True;"
  },
  "Logging": {
    "LogPath": "C:\\Logs\\StockManager",
    "RotationDays": 30
  },
  "Backup": {
    "BackupPath": "C:\\Backups\\StockManager"
  },
  "Security": {
    "EncryptionProvider": "BCrypt",
    "PasswordMinLength": 8
  },
  "Localization": {
    "DefaultLanguage": "es-AR"
  }
}
```

## 👥 Roles y Permisos

| Funcionalidad | Admin | Adm. Ventas | Adm. Depósito |
|--------------|-------|-------------|---------------|
| Gestión de Clientes | ✅ | ✅ | ❌ |
| Gestión de Productos | ✅ | ❌ | ✅ |
| Gestión de Stock | ✅ | ❌ | ✅ |
| Nueva Venta | ✅ | ✅ | ❌ |
| Modificar Venta | ✅ | ❌ | ❌ |
| Gestión de Proveedores | ✅ | ❌ | ✅ |
| Gestión de Empleados | ✅ | ❌ | ❌ |
| Reportes | ✅ | ✅ | ✅ |
| Backup/Restore | ✅ | ❌ | ❌ |
| Configuración | ✅ | ❌ | ❌ |

## 📚 Documentación Adicional

- **Diagramas UML**: Disponibles en `/Docs/Diagrams`
- **Manual de Usuario**: `/Docs/UserManual.pdf`
- **Manual Técnico**: `/Docs/TechnicalManual.pdf`
- **XML Documentation**: Generada en código con `<summary>`

## 🤝 Contribución

Este es un proyecto académico/empresarial. Para contribuir:

1. Fork del repositorio
2. Crear rama feature (`git checkout -b feature/NuevaFuncionalidad`)
3. Commit de cambios (`git commit -m 'Agregar nueva funcionalidad'`)
4. Push a la rama (`git push origin feature/NuevaFuncionalidad`)
5. Crear Pull Request

## 📄 Licencia

Este proyecto es de uso académico/privado. Todos los derechos reservados.

## 📧 Contacto

**Mariano Carames**
- GitHub: [@MarianoCarames-UAI](https://github.com/MarianoCarames-UAI)
- Proyecto: [StockManager](https://github.com/MarianoCarames-UAI/StockManager)

---

**StockManager v2.0** - Sistema Integral de Gestión de Stock
Desarrollado con C# WinForms (.NET 8) y SQL Server
