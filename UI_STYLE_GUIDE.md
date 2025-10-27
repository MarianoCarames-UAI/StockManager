# ?? GU�A DE ESTILOS UI - STOCKMANAGER V2.0

## ?? EST�NDAR DE DISE�O

### Paleta de Colores

```csharp
// Colores Principales
Color.FromArgb(0, 120, 215)      // Azul primario (botones principales)
Color.FromArgb(240, 240, 240)    // Gris claro (paneles de fondo)
Color.White                       // Blanco (fondo de controles)
Color.FromArgb(255, 140, 0)      // Naranja (acciones de advertencia)
Color.FromArgb(220, 53, 69)      // Rojo (acciones de eliminaci�n)
Color.FromArgb(40, 167, 69)      // Verde (acciones de confirmaci�n)
```

### Tipograf�a

```csharp
// Fuentes est�ndar
new Font("Segoe UI", 10F)              // Texto normal
new Font("Segoe UI", 10F, FontStyle.Bold)  // T�tulos de secci�n
new Font("Segoe UI", 12F, FontStyle.Bold)  // T�tulos principales
```

### Espaciado

```csharp
// Padding est�ndar
new Padding(10)        // Panel peque�o
new Padding(15)        // Panel mediano
new Padding(20)        // Panel grande

// Tama�os de botones
new Size(100, 30)      // Bot�n peque�o
new Size(150, 35)      // Bot�n mediano
new Size(200, 40)      // Bot�n grande
```

---

## ?? ESTRUCTURA DE FORMULARIOS LISTA

### Patr�n de dise�o:

```
???????????????????????????????????????????
? ToolStrip (Nuevo, Editar, Eliminar)    ? ? Barra de herramientas
???????????????????????????????????????????
? Panel de b�squeda/filtros               ? ? Panel blanco con Padding(10)
? [Label] [TextBox] [Bot�n Buscar]       ?
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

2. **Panel B�squeda** (Dock.Top):
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

### Patr�n de dise�o:

```
???????????????????????????????????????????
? [Tab 1] [Tab 2] [Tab 3]                 ? ? TabControl
???????????????????????????????????????????
? Panel de acciones                        ? ? Panel gris con botones
? [Bot�n 1] [Bot�n 2] [Bot�n 3]          ?
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

## ?? EJEMPLOS DE C�DIGO

### Bot�n Principal
```csharp
btnPrincipal.BackColor = Color.FromArgb(0, 120, 215);
btnPrincipal.FlatStyle = FlatStyle.Flat;
btnPrincipal.ForeColor = Color.White;
btnPrincipal.Size = new Size(150, 35);
btnPrincipal.Font = new Font("Segoe UI", 10F);
```

### Panel de B�squeda
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

## ? CHECKLIST DE DISE�O

### Para cada formulario:

- [ ] Usa fuente Segoe UI, 10F
- [ ] Botones principales con color azul #0078D7
- [ ] Paneles con BackColor gris claro #F0F0F0 o blanco
- [ ] DataGridView con fondo blanco
- [ ] Padding consistente (10, 15, 20)
- [ ] Tama�os de botones est�ndar
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

Lograr una interfaz consistente, profesional y moderna en todos los formularios del sistema, siguiendo las mejores pr�cticas de dise�o de aplicaciones Windows Forms.

