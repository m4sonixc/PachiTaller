El archivo **`MainPage.xaml.cs`** es el código de lógica C# (*code-behind*) de la pantalla principal. Su función exclusiva es **escuchar los toques del usuario en las tarjetas del menú** y ejecutar la navegación asíncrona hacia las pantallas correspondientes utilizando la infraestructura de rutas de Shell.

A continuación tienes la explicación detallada de cada bloque para tu informe o documento:

---

### 1. Espacio de Nombres y Declaración de Clase

```csharp
namespace PachiTaller
{
    public partial class MainPage : ContentPage

```

* **`namespace PachiTaller`**: Define la pertenencia del archivo al espacio de nombres global del proyecto.
* **`public partial class MainPage : ContentPage`**: Declara la clase `MainPage`. El modificador `partial` la enlaza automáticamente con los elementos definidos en el diseño gráfico de `MainPage.xaml`. Hereda de `ContentPage` por representar una pantalla de contenido individual.

---

### 2. Constructor (`MainPage()`)

```csharp
public MainPage()
{
    InitializeComponent();
}

```

* **`public MainPage()`**: Método constructor que se ejecuta cuando el sistema instancia la vista de la pantalla principal.
* **`InitializeComponent();`**: Procesa el archivo `MainPage.xaml`, construyendo en memoria los controles visuales (títulos, logo `logopachi.png`, tarjetas y detectores de gestos) para dejarlos listos en pantalla.

---

### 3. Evento de Navegación a Turnos (`OnTurnosClicked`)

```csharp
private async void OnTurnosClicked(object sender, EventArgs e)
{
    await Shell.Current.GoToAsync("//Turnos");
}

```

* **`private async void OnTurnosClicked(...)`**: Método controlador que responde al evento de toque (`Tapped`) de la primera tarjeta del menú ("Turnos").
* **`await Shell.Current.GoToAsync("//Turnos");`**: **Línea de navegación principal.** Consulta el mapa de rutas registrado en `AppShell.xaml` y realiza una transición asíncrona limpia hacia la vista de recepción y registro de turnos (`Turnos`).



---

### 4. Evento de Navegación a Historial (`OnHistorialClicked`)

```csharp
private async void OnHistorialClicked(object sender, EventArgs e)
{
    await Shell.Current.GoToAsync("//Historial");
}

```

* **Responde al evento de toque de la tarjeta "Historial de Vehículos"**.
* **`await Shell.Current.GoToAsync("//Historial");`**: Solicita al navegador de Shell trasladar al usuario hacia la vista `Historial`, donde se visualiza el estado actual de los vehículos en taller.



---

### 5. Evento de Navegación a Repuestos (`OnRepuestosClicked`)

```csharp
private async void OnRepuestosClicked(object sender, EventArgs e)
{
    // Navega de forma segura utilizando la ruta registrada en AppShell
    await Shell.Current.GoToAsync("//Repuestos");
}

```

* **Responde al evento de toque de la tarjeta "Repuestos"**.
* **`await Shell.Current.GoToAsync("//Repuestos");`**: Ejecuta la redirección asíncrona hacia la vista del catálogo de repuestos e insumos (`Repuestos`).



---

### Resumen de su función general

El archivo `MainPage.xaml.cs` actúa como el **controlador de eventos de la pantalla de inicio**: captura la interacción táctil del usuario en cada tarjeta de `MainPage.xaml` y le ordena al contenedor `Shell` que cambie de vista navegando de forma segura mediante las rutas internas (`//Turnos`, `//Historial` y `//Repuestos`).
