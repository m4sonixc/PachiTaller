El archivo **`Turnos.xaml.cs`** es el código C# subyacente (*code-behind*) asociado a la vista de registro de recepción y turnos (`Turnos.xaml`). Su función principal es procesar la inicialización de todos los elementos gráficos del formulario y administrar el evento de navegación que permite regresar al panel principal.

A continuación tienes la explicación detallada de cada bloque de código para tu documento o informe:

---

### 1. Espacio de Nombres y Declaración de Clase

```csharp
namespace PachiTaller;

public partial class Turnos : ContentPage

```

* **`namespace PachiTaller;`**: Utiliza la sintaxis moderna de .NET (*file-scoped namespace*) para agrupar esta clase dentro del espacio de nombres principal del proyecto.
* **`public partial class Turnos : ContentPage`**: Declara la clase `Turnos`. La palabra clave `partial` indica que se enlaza automáticamente con los componentes visuales definidos en la plantilla `Turnos.xaml` (los campos `Entry`, `Picker`, `DatePicker` y los botones). Hereda de `ContentPage` al tratarse de una pantalla individual de la aplicación.

---

### 2. Constructor (`Turnos()`)

```csharp
public Turnos()
{
    InitializeComponent();
}

```

* **`public Turnos()`**: Método constructor que se ejecuta tan pronto como el sistema instancia la vista de registrar nuevo turno.
* **`InitializeComponent();`**: **Línea fundamental.** Lee y dibuja en memoria los componentes de la interfaz XAML, dejando listos los campos de entrada de datos del cliente, del vehículo, los selectores de fechas y el botón de navegación.

---

### 3. Evento de Navegación de Retorno (`OnVolverInicioClicked`)

```csharp
private async void OnVolverInicioClicked(object sender, EventArgs e)
{
    await Shell.Current.GoToAsync("//Inicio");
}

```

* **`private async void OnVolverInicioClicked(...)`**: Método controlador que responde al evento de clic (`Clicked`) del botón **`← Volver al Inicio`** en el formulario de turnos.
* **`await Shell.Current.GoToAsync("//Inicio");`**: Ordena al motor de navegación de Shell que realice una transición asíncrona limpia hacia la ruta `//Inicio`, regresando al mecánico al menú o panel principal (`MainPage`).

---

### Resumen de su función general

El archivo `Turnos.xaml.cs` actúa como el **controlador de la vista de registro de turnos**: carga el formulario de captura de datos definido en XAML y proporciona una salida de navegación limpia y segura mediante el método `OnVolverInicioClicked`, permitiendo al usuario retornar al menú principal con un solo toque.
