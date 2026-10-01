El archivo **`App.xaml.cs`** es el **código de lógica C# principal de la aplicación** (el archivo *code-behind* asociado a `App.xaml`). Su función central es ser el **punto de entrada en tiempo de ejecución**, encargándose de iniciar los componentes gráficos globales y definir cuál será la ventana principal del sistema.

A continuación tienes la explicación detallada de cada línea para que puedas incluirla en tu informe o exposición:

---

### 1. Inclusión de Librerías y Namespace

```csharp
using Microsoft.Extensions.DependencyInjection;
namespace PachiTaller

```

* **`using Microsoft.Extensions.DependencyInjection;`**: Importa las librerías de .NET para el manejo de inyección de dependencias (útil para registrar servicios y datos en aplicaciones .NET MAUI).
* **`namespace PachiTaller`**: Define el espacio de nombres del proyecto, agrupando esta clase con el resto de componentes de la aplicación.

---

### 2. Declaración de la Clase `App`

```csharp
public partial class App : Application

```

* **`public partial class App : Application`**: Declara la clase principal `App` que hereda de `Application` (la clase base de .NET MAUI que representa la aplicación en ejecución). Al ser `partial`, se complementa directamente con la estructura de recursos definida en `App.xaml`.

---

### 3. Constructor de la Aplicación (`App()`)

```csharp
public App()
{
    InitializeComponent();
}

```

* **`public App()`**: Es el constructor que se ejecuta tan pronto como la aplicación se enciende en el dispositivo.
* **`InitializeComponent();`**: **Línea fundamental.** Lee y carga todo el contenido del archivo visual `App.xaml`, procesando los diccionarios de recursos, fuentes y estilos globales (`Colors.xaml` y `Styles.xaml`).

---

### 4. Creación de la Ventana Principal (`CreateWindow`)

```csharp
protected override Window CreateWindow(IActivationState? activationState)
{
    return new Window(new AppShell());
}

```

* **`protected override Window CreateWindow(...)`**: En .NET MAUI (a partir de las versiones recientes en .NET 8, 9 y 10), este método se encarga de instanciar y construir la ventana física en la que se renderizará la interfaz del usuario.
* **`return new Window(new AppShell());`**: Define que el contenido dentro de la ventana de la aplicación será el contenedor de navegación **`AppShell`** (el cual registra las rutas y pantallas `MainPage`, `Turnos`, `Historial` y `Repuestos`).

---

### Resumen de su función general

El archivo `App.xaml.cs` actúa como el **arrancador de la aplicación**: inicializa los estilos globales de `App.xaml` y le indica a .NET MAUI que abra una ventana nueva cargando la estructura de navegación de `AppShell`.
