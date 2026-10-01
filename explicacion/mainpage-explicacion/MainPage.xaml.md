El archivo **`MainPage.xaml`** es la **interfaz gráfica del panel principal (Dashboard)** de tu aplicación. Es la primera pantalla que observa el usuario al ingresar y funciona como el menú central interactivo desde el cual se accede a los distintos módulos de la app.

A continuación tienes la explicación detallada etiqueta por etiqueta de todo el código para tu documento o exposición:

---

### 1. Encabezado de la Página (`<ContentPage ...>`)

```xml
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             x:Class="PachiTaller.MainPage"
             Title="Pachi Garage"
             BackgroundColor="#F4F6F9">

```

* **`<ContentPage>`**: Es el contenedor básico de pantalla completa en .NET MAUI. Representa una vista o página individual del sistema.
* **`xmlns` y `xmlns:x**`: Importan las librerías necesarias de .NET MAUI para procesar controles XAML (`Label`, `Border`, `Image`, etc.).
* **`x:Class="PachiTaller.MainPage"`**: Vincula este diseño visual con su archivo de lógica C# (`MainPage.xaml.cs`), permitiendo que los eventos de clic funcionen.
* **`Title="PachiGarage"`**: Muestra el título en la barra superior de la app.
* **`BackgroundColor="#F4F6F9"`**: Define un color de fondo gris claro para toda la pantalla.

---

### 2. Desplazamiento y Disposición (`<ScrollView>` y `<VerticalStackLayout>`)

```xml
<ScrollView>
    <VerticalStackLayout Padding="20" Spacing="20" HorizontalOptions="Fill">

```

* **`<ScrollView>`**: Envuelve todo el contenido permitiendo que el usuario pueda hacer desplazamiento vertical (*scroll*) si la pantalla del celular o tablet es muy pequeña.
* **`<VerticalStackLayout>`**: Organiza todos los elementos gráficos de forma secuencial, uno debajo del otro de arriba hacia abajo.
* **`Padding="20"`**: Agrega un margen interno de 20 píxeles alrededor de toda la pantalla para que los botones no queden pegados a los bordes.
* **`Spacing="20"`**: Establece una separación de 20 píxeles entre cada elemento visual.



---

### 3. Título e Identidad del Taller (`<Label>`)

```xml
<!-- este es el titulo grande en la parte superior -->
<Label Text="Pachi Garage"
       FontSize="30"
       FontAttributes="Bold"
       HorizontalOptions="Center"
       TextColor="#1B2A4A" />

<!-- Subtítulo del Taller Mecánico -->
<Label Text="Taller Mecánico &amp; Repuestos"
       FontSize="16"
       HorizontalOptions="Center"
       TextColor="#512BD4"
       Margin="0,-15,0,0" />

```

* **Muestra el nombre comercial e identidad del taller**:
* **`FontSize="30"` y `FontAttributes="Bold"**`: Establecen el texto principal grande y en negrita.
* **`TextColor="#1B2A4A"` / `#512BD4"**`: Aplican la paleta de colores oficial del proyecto (Azul Marino y Violeta).
* **`Margin="0,-15,0,0"`**: Acerca el subtítulo hacia el título principal para lograr una apariencia agrupada.



---

### 4. Tarjeta del Logo Central (`<Border>` e `<Image>`)

```xml
<Border Stroke="#512BD4" 
        StrokeThickness="2" 
        HeightRequest="190" 
        WidthRequest="320" 
        HorizontalOptions="Center" 
        BackgroundColor="#1B2A4A">
    <Border.StrokeShape>
        <RoundRectangle CornerRadius="16" />
    </Border.StrokeShape>
    <Image Source="logopachi.png"
           Aspect="AspectFill"
           HeightRequest="190"
           WidthRequest="320" />
</Border>
<BoxView HeightRequest="1" Color="#D1D5DB" Margin="0,10" />

```

* **`<Border>`**: Crea un marco contenedor estilizado de 320x190 píxeles con borde violeta (`#512BD4`) de 2 píxeles de grosor y fondo azul marino.
* **`<RoundRectangle CornerRadius="16"/>`**: Le otorga bordes redondeados al marco con un radio de 16 píxeles.
* **`<Image Aspect="AspectFill" Source="logopachi.png"/>`**: Carga el logo oficial del taller desde los recursos e indica que la imagen debe adaptarse rellenando el marco proporcionalmente.
* **`<BoxView>`**: Dibuja una línea divisoria gris delgada (`#D1D5DB`) de 1 píxel de alto para separar el encabezado del menú de opciones.

---

### 5. Botones y Accesos Directos del Menú (`<Border>` interactivos)

Cada opción del menú se creó envolviendo etiquetas en un contenedor `Border` con detector de gestos táctiles (`TapGestureRecognizer`):

#### **A. Opción: Turnos**

```xml
<Border Stroke="#1B2A4A" StrokeThickness="1" BackgroundColor="#1B2A4A" Padding="15">
    <Border.StrokeShape>
        <RoundRectangle CornerRadius="12" />
    </Border.StrokeShape>
    <Border.GestureRecognizers>
        <TapGestureRecognizer Tapped="OnTurnosClicked" />
    </Border.GestureRecognizers>
    <VerticalStackLayout Spacing="3">
        <Label Text="Turnos" FontSize="20" FontAttributes="Bold" TextColor="White" />
        <Label Text="Agendar nuevos turnos de ingreso al taller" FontSize="13" TextColor="#D1D5DB" />
    </VerticalStackLayout>
</Border>

```

* **Contenedor**: Tarjeta de fondo Azul Marino (`#1B2A4A`) con bordes redondeados (`CornerRadius="12"`).
* **`TapGestureRecognizer Tapped="OnTurnosClicked"`**: Transforma la tarjeta visual en un botón interactivo. Cuando el mecánico la toca, dispara el método `OnTurnosClicked` en el código C# para abrir la pantalla de turnos.
* **Texto e Indicación**: Muestra el título "Turnos" y una breve descripción explicativa.

#### **B. Opción: Historial de Vehículos**

```xml
<Border Stroke="#512BD4" StrokeThickness="1" BackgroundColor="#512BD4" Padding="15">
    <Border.StrokeShape>
        <RoundRectangle CornerRadius="12" />
    </Border.StrokeShape>
    <Border.GestureRecognizers>
        <TapGestureRecognizer Tapped="OnHistorialClicked" />
    </Border.GestureRecognizers>
    <VerticalStackLayout Spacing="3">
        <Label Text="Historial de Vehículos" FontSize="20" FontAttributes="Bold" TextColor="White" />
        <Label Text="Consultar registros y estados de vehículos" FontSize="13" TextColor="#D1D5DB" />
    </VerticalStackLayout>
</Border>

```

* **Misma estructura que la anterior**, con fondo Violeta (`#512BD4`) para resaltar visualmente. Dispara el evento `OnHistorialClicked` para navegar a la sección de consulta de trabajos en taller.

#### **C. Opción: Repuestos**

```xml
<Border Stroke="#1B2A4A" StrokeThickness="1" BackgroundColor="#1B2A4A" Padding="15">
    <Border.StrokeShape>
        <RoundRectangle CornerRadius="12" />
    </Border.StrokeShape>
    <Border.GestureRecognizers>
        <TapGestureRecognizer Tapped="OnRepuestosClicked" />
    </Border.GestureRecognizers>
    <VerticalStackLayout Spacing="3">
        <Label Text="Repuestos" FontSize="20" FontAttributes="Bold" TextColor="White" />
        <Label Text="Catálogo de repuestos e insumos disponibles" FontSize="13" TextColor="#D1D5DB" />
    </VerticalStackLayout>
</Border>

```

* Tarjeta interactiva que llama al evento `OnRepuestosClicked` para dirigir al usuario hacia el catálogo de insumos y repuestos del taller.

---

### Resumen de su función general

`MainPage.xaml` es el **panel principal de usuario**: presenta la marca e imagen corporativa del taller **Pachi Garage** mediante un contenedor redondeado con la imagen `logopachi.png` y ofrece accesos directos interactivos a través de tarjetas táctiles que conectan directamente con los módulos de **Turnos**, **Historial** y **Repuestos**.
