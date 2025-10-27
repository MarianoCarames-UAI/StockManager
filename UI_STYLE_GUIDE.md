# ?? GUÍA DE ESTILOS UI - STOCKMANAGER V2.0

## ?? ESTÁNDAR DE DISEÑO

### Paleta de Colores

```csharp
// Colores Principales
Color.FromArgb(0, 120, 215)      // Azul primario (botones principales)
Color.FromArgb(240, 240, 240)    // Gris claro (paneles de fondo)
Color.White                       // Blanco (fondo de controles)
Color.FromArgb(255, 140, 0)      // Naranja (acciones de advertencia)
Color.FromArgb(220, 53, 69)      // Rojo (acciones de eliminación)
Color.FromArgb(40, 167, 69)      // Verde (acciones de confirmación)
```

### Tipografía

```csharp
// Fuentes estándar
new Font("Segoe UI", 10F)              // Texto normal
new Font("Segoe UI", 10F, FontStyle.Bold)  // Títulos de sección
new Font("Segoe UI", 12F, FontStyle.Bold)  // Títulos principales
```

### Espaciado

```csharp
// Padding estándar
new Padding(10)        // Panel pequeño
new Padding(15)        // Panel mediano
new Padding(20)        // Panel grande

// Tamaños de botones
new Size(100, 30)      // Botón pequeño
new Size(150, 35)      // Botón mediano
new Size(200, 40)      // Botón grande
```

---

## ?? ESTRUCTURA DE FORMULARIOS LISTA

### Patrón de diseño:

```
???????????????????????????????????????????
? ToolStrip (Nuevo, Editar, Eliminar)    ? ? Barra de herramientas
???????????????????????????????????????????
? Panel de búsqueda/filtros               ? ? Panel blanco con Padding(10)
? [Label] [TextBox] [Botón Buscar]       ?
???????????????????????????????????????????
?                                          ?
?         DataGridView                     ? ? Dock.Fill, fondo blanco
?                                          ?
?                                          ?
???????????????????????????????????????????
```

### Componentes:

1. **ToolStrip** (Dock.Top):
   - Botones: Nuevo, Editar, Eliminar, Separador, Refrescar
   - ImageScalingSize: 20x20

2. **Panel Búsqueda** (Dock.Top):
   - BackColor: White
   - Padding: 10
   - Height: 60
   - Controles: Label, TextBox, Button

3. **DataGridView** (Dock.Fill):
   - AllowUserToAddRows: false
   - AllowUserToDeleteRows: false
   - ReadOnly: true
   - SelectionMode: FullRowSelect
   - AutoSizeColumnsMode: Fill
   - BackgroundColor: White

---

## ?? ESTRUCTURA DE FORMULARIOS CON TABS

### Patrón de diseño:

```
???????????????????????????????????????????
? [Tab 1] [Tab 2] [Tab 3]                 ? ? TabControl
???????????????????????????????????????????
? Panel de acciones                        ? ? Panel gris con botones
? [Botón 1] [Botón 2] [Botón 3]          ?
???????????????????????????????????????????
?                                          ?
?         DataGridView                     ? ? Grilla de datos
?                                          ?
?                                          ?
???????????????????????????????????????????
```

### Componentes:

1. **TabControl** (Dock.Fill):
   - Font: Segoe UI, 10F
   - Padding: 3

2. **Panel Acciones** (Dock.Top en cada Tab):
   - BackColor: Color.FromArgb(240, 240, 240)
   - Padding: 10
   - Height: 60

3. **Botones**:
   - Principal: BackColor Azul (#0078D7), ForeColor White
   - Secundario: BackColor Default, FlatStyle Flat
   - Advertencia: BackColor Naranja (#FF8C00)
   - Peligro: BackColor Rojo (#DC3545)

---

## ?? EJEMPLOS DE CÓDIGO

### Botón Principal
```csharp
btnPrincipal.BackColor = Color.FromArgb(0, 120, 215);
btnPrincipal.FlatStyle = FlatStyle.Flat;
btnPrincipal.ForeColor = Color.White;
btnPrincipal.Size = new Size(150, 35);
btnPrincipal.Font = new Font("Segoe UI", 10F);
```

### Panel de Búsqueda
```csharp
panelBusqueda.BackColor = Color.White;
panelBusqueda.Dock = DockStyle.Top;
panelBusqueda.Padding = new Padding(10);
panelBusqueda.Height = 60;
```

### DataGridView
```csharp
dgv.AllowUserToAddRows = false;
dgv.AllowUserToDeleteRows = false;
dgv.ReadOnly = true;
dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
dgv.BackgroundColor = Color.White;
dgv.Dock = DockStyle.Fill;
```

### TabControl
```csharp
tabControl.Dock = DockStyle.Fill;
tabControl.Font = new Font("Segoe UI", 10F);
tabControl.Padding = new Padding(3);
```

---

## ? CHECKLIST DE DISEÑO

### Para cada formulario:

- [ ] Usa fuente Segoe UI, 10F
- [ ] Botones principales con color azul #0078D7
- [ ] Paneles con BackColor gris claro #F0F0F0 o blanco
- [ ] DataGridView con fondo blanco
- [ ] Padding consistente (10, 15, 20)
- [ ] Tamaños de botones estándar
- [ ] FlatStyle.Flat en botones personalizados
- [ ] SelectionMode.FullRowSelect en grillas
- [ ] AutoSizeColumnsMode.Fill en grillas
- [ ] Labels con fuente Segoe UI 10F

---

## ?? FORMULARIOS A ESTANDARIZAR

### ? Ya estandarizados:
- [x] ClientesListForm
- [x] ProductosListForm
- [x] VentasListForm
- [x] StockForm

### ?? Por estandarizar:
- [ ] AdminForm
- [ ] ReportesForm

---

## ?? OBJETIVO

Lograr una interfaz consistente, profesional y moderna en todos los formularios del sistema, siguiendo las mejores prácticas de diseño de aplicaciones Windows Forms.

