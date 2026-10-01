El archivo **`AppShell.xaml.cs`** es el código C# subyacente (*code-behind*) asociado al archivo de diseño **`AppShell.xaml`**. Su función principal es **inicializar la estructura de navegación Shell** cuando se instancia la ventana principal de la aplicación.

A continuación tienes la explicación detallada línea por línea para tu documento o informe:

---

### 1. Espacio de Nombres (`namespace PachiTaller`)

```csharp
namespace PachiTaller

```

* **`namespace PachiTaller`**: Agrupa esta clase dentro del mismo espacio de nombres del proyecto, permitiendo que `App.xaml.cs` pueda encontrarla e instanciarla directamente mediante `new AppShell()`.

---

### 2. Declaración de la Clase (`AppShell`)

```csharp
public partial class AppShell : Shell

```

* **`public partial class AppShell`**: Declara la clase `AppShell`. El modificador `partial` indica que esta clase se complementa con el código generado automáticamente a partir del archivo visual `AppShell.xaml`.
* **`: Shell`**: Hereda de la clase base `Shell` de .NET MAUI, lo que le otorga la capacidad de gestionar la jerarquía de páginas, el enrutamiento (*URI routing*) y el comportamiento del contenedor de navegación principal.

---

### 3. Constructor de la Clase (`AppShell()`)

```csharp
public AppShell()
{
    InitializeComponent();
}

```

* **`public AppShell()`**: Es el método constructor que se ejecuta cuando la aplicación crea la ventana principal (`new Window(new AppShell())`).
* **`InitializeComponent();`**: **Línea fundamental.** Procesa y construye todos los elementos declarados en `AppShell.xaml`. Al ejecutarse, lee la configuración de las rutas (`Route="Inicio"`, `Route="Turnos"`, `Route="Historial"`, `Route="Repuestos"`), oculta la barra de pestañas (`Shell.TabBarIsVisible="False"`) y prepara las vistas para que la aplicación pueda navegar entre ellas.

---

### Resumen de su función general

El archivo `AppShell.xaml.cs` es el **controlador de inicio de la navegación**: se encarga de ejecutar la carga del archivo XAML asociado (`AppShell.xaml`), dejando registradas y listas todas las rutas de la aplicación para que las vistas puedan intercambiarse de forma asíncrona desde los botones del menú de inicio.
