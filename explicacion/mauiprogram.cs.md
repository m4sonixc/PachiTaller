El archivo **`MauiProgram.cs`** es la **clase de arranque y configuración inicial de la aplicación** en .NET MAUI. Es el primer fragmento de código C# que ejecuta el dispositivo al abrir la app (equivalente al método `Main` en aplicaciones tradicionales de .NET). Su función es construir y compilar el objeto `MauiApp` preparando las fuentes, los servicios y los componentes gráficos necesarios.

A continuación tienes la explicación detallada parte por parte para tu informe o documento:

---

### 1. Inclusión de Librerías y Namespace

```csharp
using Microsoft.Extensions.Logging;
namespace PachiTaller

```

* **`using Microsoft.Extensions.Logging;`**: Importa la librería de registro de eventos y logs de .NET, utilizada para depurar errores durante la etapa de desarrollo.
* **`namespace PachiTaller`**: Agrupa esta clase dentro del espacio de nombres principal del proyecto.

---

### 2. Declaración de la Clase Estática (`MauiProgram`)

```csharp
public static class MauiProgram

```

* **`public static class MauiProgram`**: Se declara como una clase estática porque no necesita ser instanciada explícitamente (`new MauiProgram()`), sino que el motor de ejecución de .NET la llama directamente al iniciar la aplicación en Android, iOS o Windows.

---

### 3. Método de Creación de la App (`CreateMauiApp()`)

```csharp
public static MauiApp CreateMauiApp()
{
    var builder = MauiApp.CreateBuilder();

```

* **`public static MauiApp CreateMauiApp()`**: Es el método de punto de entrada donde se configura la aplicación.
* **`var builder = MauiApp.CreateBuilder();`**: Instancia un patrón de diseño tipo *Builder* (constructor) que permite ir registrando paso a paso todas las configuraciones, tipografías y servicios de la app.

---

### 4. Configuración de la Clase Principal y Tipografías (`UseMauiApp` y `ConfigureFonts`)

```csharp
builder
    .UseMauiApp<App>()
    .ConfigureFonts(fonts =>
    {
        fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
        fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
    });

```

* **`.UseMauiApp<App>()`**: Le indica al framework que la clase `App` (ubicada en `App.xaml.cs`) será la raíz que gestione los recursos globales y la ventana principal del sistema.
* **`.ConfigureFonts(...)`**: Registra e instala en memoria las fuentes o tipografías personalizadas almacenadas en la carpeta `Resources/Fonts/` (en este caso, *OpenSans Regular* y *OpenSans Semibold*) asignándoles un alias para que puedan usarse desde el código XAML.

---

### 5. Configuración de Depuración (`#if DEBUG`)

```csharp
#if DEBUG
    builder.Logging.AddDebug();
#endif

```

* **Directiva de compilación condicional**: Le indica a .NET que **únicamente durante la etapa de desarrollo y pruebas (modo Debug)** active la herramienta de logs (`Logging.AddDebug()`). Esto permite ver los mensajes de estado y posibles errores en la consola de depuración de Visual Studio.

---

### 6. Compilación y Retorno del Objeto (`builder.Build()`)

```csharp
return builder.Build();

```

* **`return builder.Build();`**: Finaliza el ensamblado de todas las configuraciones registradas y retorna el objeto `MauiApp` ya construido para que el sistema operativo renderice la aplicación.

---

### Resumen de su función general

El archivo `MauiProgram.cs` es el **punto de arranque del sistema**: se encarga de instanciar el motor de .NET MAUI, enlazar la clase `App`, cargar las fuentes tipográficas globales y habilitar las herramientas de depuración antes de mostrar la interfaz en pantalla.
