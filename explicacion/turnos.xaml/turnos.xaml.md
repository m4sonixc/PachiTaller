El archivo **`Turnos.xaml`** es la **interfaz gráfica del formulario de recepción y registro de turnos** del taller. Está diseñado como un formulario directo donde el mecánico puede ingresar en un solo paso los datos del cliente, del vehículo y los detalles de la orden de servicio.

A continuación tienes la explicación detallada etiqueta por etiqueta para tu informe o documento:

---

### 1. Encabezado e Identificación de la Vista (`<ContentPage ...>`)

```xml
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             x:Class="PachiTaller.Turnos"
             Title="Turnos - Pachi Garage"
             BackgroundColor="White">

```

* **`<ContentPage>`**: Define una pantalla individual en .NET MAUI.
* **`x:Class="PachiTaller.Turnos"`**: Vincula esta interfaz visual XAML con su correspondiente archivo de lógica C# (`Turnos.xaml.cs`).
* **`Title="Turnos - Pachi Garage"`**: Asigna el título que aparece en la barra superior.
* **`BackgroundColor="White"`**: Establece un fondo blanco limpio para resaltar las cajas del formulario.

---

### 2. Estructura de Desplazamiento y Disposición (`<ScrollView>` y `<VerticalStackLayout>`)

```xml
<ScrollView>
    <VerticalStackLayout Padding="20" Spacing="15">

```

* **`<ScrollView>`**: Permite desplazarse verticalmente por todo el formulario, asegurando que todos los campos sean accesibles incluso en pantallas pequeñas.
* **`<VerticalStackLayout>`**: Ordena las secciones del formulario una debajo de otra en secuencia vertical, aplicando un margen interno de 20 píxeles (`Padding="20"`) y un espacio de 15 píxeles entre campos (`Spacing="15"`).

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

* **`Text="← Volver al Inicio"`**: Ofrece una opción visual clara de retorno.
* **`Clicked="OnVolverInicioClicked"`**: Conecta el botón con el método en C# que ejecuta la navegación de regreso al panel principal (`MainPage`).
* **`BackgroundColor="Transparent"` y `TextColor="#512BD4"**`: Aplica un estilo limpio con texto en color violeta sin recargar el diseño.

---

### 4. Sección 1: Datos del Cliente (`Entry` enmarcados)

```xml
<Label Text="Datos del Cliente" FontAttributes="Bold" TextColor="Black" Margin="0,5,0,0" />

<Border Stroke="#1B2A4A" StrokeThickness="1" BackgroundColor="White" Padding="10,0" HeightRequest="50">
    <Border.StrokeShape>
        <RoundRectangle CornerRadius="8" />
    </Border.StrokeShape>
    <Entry Placeholder="Nombre y Apellido del Dueño" PlaceholderColor="Gray" TextColor="Black" VerticalOptions="Center" />
</Border>

<Border Stroke="#1B2A4A" StrokeThickness="1" BackgroundColor="White" Padding="10,0" HeightRequest="50">
    <Border.StrokeShape>
        <RoundRectangle CornerRadius="8" />
    </Border.StrokeShape>
    <Entry Placeholder="Número de Teléfono" Keyboard="Telephone" PlaceholderColor="Gray" TextColor="Black" VerticalOptions="Center" />
</Border>

```

* **Contenedores `Border**`: Envuelven cada campo de texto dentro de una caja con borde Azul Marino (`#1B2A4A`), bordes redondeados (`CornerRadius="8"`) y una altura fija de 50 píxeles.
* **`<Entry>`**: Campos de entrada de texto directo:
* El primer campo captura el nombre completo del dueño.
* El segundo campo incluye `Keyboard="Telephone"`, lo que despliega automáticamente el teclado numérico en celulares para facilitar la carga del teléfono del cliente.



---

### 5. Sección 2: Datos del Vehículo (`Picker` y `Entry`)

```xml
<Label Text="Datos del Vehículo" FontAttributes="Bold" TextColor="Black" Margin="0,5,0,0" />

<Border Stroke="#1B2A4A" StrokeThickness="1" BackgroundColor="White" Padding="10,0" HeightRequest="50">
    <Border.StrokeShape>
        <RoundRectangle CornerRadius="8" />
    </Border.StrokeShape>
    <Picker Title="Seleccione tipo de vehículo" TitleColor="Black" TextColor="Black" VerticalOptions="Center">
        <Picker.Items>
            <x:String>Auto</x:String>
            <x:String>Moto</x:String>
        </Picker.Items>
    </Picker>
</Border>

<Border Stroke="#1B2A4A" StrokeThickness="1" BackgroundColor="White" Padding="10,0" HeightRequest="50">
    <Border.StrokeShape>
        <RoundRectangle CornerRadius="8" />
    </Border.StrokeShape>
    <Entry Placeholder="Marca y Modelo " PlaceholderColor="Gray" TextColor="Black" VerticalOptions="Center" />
</Border>

<Border Stroke="#1B2A4A" StrokeThickness="1" BackgroundColor="White" Padding="10,0" HeightRequest="50">
    <Border.StrokeShape>
        <RoundRectangle CornerRadius="8" />
    </Border.StrokeShape>
    <Entry Placeholder="Patente / Dominio" PlaceholderColor="Gray" TextColor="Black" VerticalOptions="Center" />
</Border>

```

* **`<Picker>`**: Selector desplegable que permite elegir entre opciones predefinidas (`Auto` o `Moto`).
* **`<Entry>`**: Dos cajas de entrada adicionales para registrar la Marca/Modelo y la Patente (Dominio) del vehículo.

---

### 6. Sección 3: Detalles del Turno (`Picker` y `DatePicker`)

```xml
<Label Text="Detalle del Turno" FontAttributes="Bold" TextColor="Black" Margin="0,5,0,0" />

<Border Stroke="#1B2A4A" StrokeThickness="1" BackgroundColor="White" Padding="10,0" HeightRequest="50">
    <Border.StrokeShape>
        <RoundRectangle CornerRadius="8" />
    </Border.StrokeShape>
    <Picker Title="Seleccione motivo del servicio" TitleColor="Black" TextColor="Black" VerticalOptions="Center">
        <Picker.Items>
            <x:String>Mantenimiento</x:String>
            <x:String>Diagnóstico</x:String>
            <x:String>Reparación</x:String>
        </Picker.Items>
    </Picker>
</Border>

<Label Text="Fecha de Ingreso:" TextColor="Black" />
<Border Stroke="#1B2A4A" StrokeThickness="1" BackgroundColor="White" Padding="10,0" HeightRequest="50">
    <Border.StrokeShape>
        <RoundRectangle CornerRadius="8" />
    </Border.StrokeShape>
    <DatePicker TextColor="Black" VerticalOptions="Center" />
</Border>

<Label Text="Fecha Estimada de Finalización:" TextColor="Black" />
<Border Stroke="#1B2A4A" StrokeThickness="1" BackgroundColor="White" Padding="10,0" HeightRequest="50">
    <Border.StrokeShape>
        <RoundRectangle CornerRadius="8" />
    </Border.StrokeShape>
    <DatePicker TextColor="Black" VerticalOptions="Center" />
</Border>

```

* **`<Picker>` de Motivo**: Permite seleccionar rápidamente el tipo de trabajo a realizar (*Mantenimiento*, *Diagnóstico* o *Reparación*).
* **`<DatePicker>`**: Componentes nativos de selección de fecha que permiten indicar con un calendario interactivo la fecha de recepción del vehículo y la fecha estimada de entrega.

---

### 7. Botón de Guardar Turno (`<Button>`)

```xml
<Button Text="Guardar Turno"
        BackgroundColor="#1B2A4A"
        TextColor="White"
        CornerRadius="10"
        HeightRequest="50"
        Margin="0,10,0,10" />

```

* **`Button` destacado**: Botón principal de acción con fondo Azul Marino (`#1B2A4A`), texto blanco en negrita y bordes redondeados (`CornerRadius="10"`), encargado de confirmar la registración del turno en el sistema.

---

### Resumen de su función general

`Turnos.xaml` es el **módulo de recepción y agendamiento**: organiza de manera clara e intuitiva todos los controles del formulario (`Entry`, `Picker`, `DatePicker`) envueltos en cajas estilizadas `Border`, garantizando que el mecánico pueda registrar un vehículo en pocos segundos y regresar al menú mediante el botón de retorno.
