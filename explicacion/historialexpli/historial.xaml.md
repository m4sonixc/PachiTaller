El archivo **`Historial.xaml`** es la **interfaz gráfica del módulo de consulta de vehículos** de la aplicación. Representa la vista donde el mecánico puede revisar los estados de los trabajos en taller mediante un buscador rápido y tarjetas informativas.

A continuación tienes la explicación detallada etiqueta por etiqueta para tu informe o documento:

---

### 1. Encabezado e Identificación de la Vista (`<ContentPage ...>`)

```xml
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             x:Class="PachiTaller.Historial"
             Title="Historial - Pachi Garage"
             BackgroundColor="#F4F6F9">

```

* **`<ContentPage>`**: Define una pantalla o vista individual en la arquitectura de .NET MAUI.
* **`x:Class="PachiTaller.Historial"`**: Enlaza esta maqueta visual XAML con su clase de lógica C# subyacente (`Historial.xaml.cs`).
* **`Title="Historial - Pachi Garage"`**: Establece el título de la vista que se muestra en la barra de navegación.
* **`BackgroundColor="#F4F6F9"`**: Define el color de fondo gris claro característico del tema unificado de la aplicación.

---

### 2. Estructura de Desplazamiento y Contenedor (`<ScrollView>` y `<VerticalStackLayout>`)

```xml
<ScrollView>
    <VerticalStackLayout Padding="20" Spacing="15">

```

* **`<ScrollView>`**: Permite el desplazamiento vertical cuando la lista de vehículos u opciones excede el tamaño físico de la pantalla.
* **`<VerticalStackLayout>`**: Alinea todos los componentes visuales de forma secuencial de arriba hacia abajo.
* **`Padding="20"`**: Otorga un margen interno de 20 píxeles respecto a los bordes del dispositivo.
* **`Spacing="15"`**: Mantiene un espacio constante de 15 píxeles entre los elementos de la pantalla.



---

### 3. Botón de Navegación de Retorno (`<Button>`)

```xml
<Button Text="← Volver al Inicio"
        Clicked="OnVolverInicioClicked"
        BackgroundColor="Transparent"
        TextColor="#512BD4"
        FontSize="16"
        FontAttributes="Bold"
        HorizontalOptions="Start"
        Margin="0,0,0,5" />

```

* **`Text="← Volver al Inicio"`**: Texto plano que indica la acción de regresar al menú principal.
* **`Clicked="OnVolverInicioClicked"`**: Conecta el botón con el método en C# encargado de realizar la redirección hacia `MainPage`.
* **`BackgroundColor="Transparent"` y `TextColor="#512BD4"**`: Otorga un estilo sobrio en texto violeta sin fondo de relleno.
* **`HorizontalOptions="Start"`**: Ubica el botón alineado a la izquierda de la vista.

---

### 4. Título de la Sección (`<Label>`)

```xml
<Label Text="Historial de Vehículos en Taller"
       FontSize="22"
       FontAttributes="Bold"
       TextColor="#512BD4" />

```

* Encabezado de la pantalla con tamaño destacado (`FontSize="22"`), texto en negrita y color violeta corporativo (`#512BD4`).

---

### 5. Caja del Buscador Rápido (`<Border>` y `<Entry>`)

```xml
<Border Stroke="#512BD4" StrokeThickness="1" BackgroundColor="White" Padding="10,0" HeightRequest="50">
    <Border.StrokeShape>
        <RoundRectangle CornerRadius="8" />
    </Border.StrokeShape>
    <Entry Placeholder="Buscar por patente o dueño..." PlaceholderColor="Gray" TextColor="Black" VerticalOptions="Center" />
</Border>

```

* **`<Border>`**: Contenedor con borde violeta (`#512BD4`), fondo blanco y esquinas redondeadas (`CornerRadius="8"`), con una altura fija de 50 píxeles.
* **`<Entry>`**: Campo de entrada interactivo diseñado para que el mecánico ingrese el número de patente o el nombre del cliente y filtre los registros del historial.

---

### Resumen de su función general

`Historial.xaml` es la **vista de consulta y seguimiento**: incluye un botón de retorno rápido al panel principal, el título principal del módulo y una caja de búsqueda envolvente (`Border`) preparada para filtrar la información de los vehículos ingresados al taller.
