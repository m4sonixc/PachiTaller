El archivo **`Repuestos.xaml`** es la **interfaz gráfica del catálogo de insumos y repuestos** de la aplicación. Representa un módulo diseñado para mostrar los productos organizados mediante una grilla adaptativa, incluyendo un botón de retorno al panel principal.

A continuación tienes la explicación detallada de cada bloque de código para tu documento o informe:

---

### 1. Encabezado e Identificación de la Vista (`<ContentPage ...>`)

```xml
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             x:Class="PachiTaller.Repuestos"
             Title="Repuestos"
             BackgroundColor="White">

```

* **`<ContentPage>`**: Define una pantalla o vista individual dentro del sistema de .NET MAUI.
* **`x:Class="PachiTaller.Repuestos"`**: Vincula este archivo de maquetación XAML con su clase de lógica C# subyacente (`Repuestos.xaml.cs`).
* **`Title="Repuestos"`**: Asigna el nombre de la sección que se visualiza en la barra de navegación superior.
* **`BackgroundColor="White"`**: Establece un fondo blanco limpio para la pantalla.

---

### 2. Estructura de Desplazamiento y Disposición (`<ScrollView>` y `<VerticalStackLayout>`)

```xml
<ScrollView>
    <VerticalStackLayout Padding="20" Spacing="15">

```

* **`<ScrollView>`**: Permite el desplazamiento vertical de la pantalla en dispositivos con resoluciones pequeñas.
* **`<VerticalStackLayout>`**: Ordena los elementos en secuencia vertical de arriba hacia abajo.
* **`Padding="20"`**: Aplica un margen interno de 20 píxeles respecto a las bordes del dispositivo.
* **`Spacing="15"`**: Genera un espacio uniforme de 15 píxeles entre cada componente.



---

### 3. Botón de Retorno (`<Button>`)

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

* **`Text="← Volver al Inicio"`**: Texto claro indicando la acción de retorno al menú principal.
* **`Clicked="OnVolverInicioClicked"`**: Conecta el botón con el método en C# que ejecuta la navegación de regreso a `MainPage`.
* **`BackgroundColor="Transparent"` y `TextColor="#512BD4"**`: Otorga un estilo plano sin fondo con texto en color violeta para no recargar la interfaz.
* **`HorizontalOptions="Start"`**: Alinea el botón a la izquierda de la pantalla.

---

### 4. Encabezado de la Sección (`<Label>`)

```xml
<Label Text="Catálogo de Repuestos e Insumos (PROXIMAMENTE)...."
       FontSize="22"
       FontAttributes="Bold"
       TextColor="#1B2A4A" />

```

* Muestra el título de la vista utilizando el tono Azul Marino (`#1B2A4A`) característico del taller, indicando el estado o propósito del módulo.

---

### 5. Estructura en Grilla para Productos (`<Grid>`)

```xml
<Grid RowDefinitions="Auto,Auto" ColumnDefinitions="*,*" ColumnSpacing="10" RowSpacing="10">
</Grid>

```

* **`<Grid>`**: Define un contenedor en formato de tabla para organizar los repuestos en filas y columnas.
* **`RowDefinitions="Auto,Auto"`**: Prepara dos filas cuya altura se adapta automáticamente al contenido.
* **`ColumnDefinitions="*,*"`**: Define dos columnas de igual ancho relativo (`*`), permitiendo una distribución en tarjetas de dos en dos.
* **`ColumnSpacing="10"` y `RowSpacing="10"**`: Añade 10 píxeles de separación entre filas y columnas para evitar la superposición de elementos.

---

### Resumen de su función general

`Repuestos.xaml` es la **vista del catálogo de insumos**: proporciona una navegación clara mediante el botón **`← Volver al Inicio`**, un título descriptivo y una estructura en grilla responsiva (`Grid`) preparada para desplegar las tarjetas de repuestos disponibles de forma organizada.
