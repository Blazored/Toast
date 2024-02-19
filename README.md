# Blazored Toast
This is a JavaScript free toast implementation for [Blazor](https://blazor.net) and Razor Components applications. It supports icons that are either specified by class name (such as fontawesome) or by a specified element (Material Design).

[![Nuget version](https://img.shields.io/nuget/v/Blazored.Toast.svg?logo=nuget)](https://www.nuget.org/packages/Blazored.Toast/)
[![Nuget downloads](https://img.shields.io/nuget/dt/Blazored.Toast?logo=nuget)](https://www.nuget.org/packages/Blazored.Toast/)
![Build & Test Main](https://github.com/Blazored/Toast/workflows/Build%20&%20Test%20Main/badge.svg)

![Screenshot of component in action](screenshot.png)

## Installing

To install the package add the following line to you csproj file replacing x.x.x with the latest version number (found at the top of this file):

```
<PackageReference Include="Blazored.Toast" Version="x.x.x" />
```

You can also install via the .NET CLI with the following command:

```
dotnet add package Blazored.Toast
```

If you're using Visual Studio or JetBrains Rider you can also install via the built in NuGet package manager.

## Setup

You will need to register the Blazored Toast service with the service collection in your _Program.cs_ file.

```c#
builder.Services.AddBlazoredToast();
```

### Add Imports
Add the following to your *_Imports.razor*

```razor
@using Blazored.Toast
@using Blazored.Toast.Services
```

### Add reference to style sheet(s)
Blazored Toast uses CSS isolation. If your application is already using CSS isolation then the styles for Toast will be included automatically and you can skip this step. However, if your application isn't using isolated CSS, you will need to add a reference to the CSS bundle. You can checkout the [Microsoft Docs](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/css-isolation?view=aspnetcore-6.0#css-isolation-bundling) for additional details.

```razor
<link href="{YOUR APP ASSEMBLY NAME}.styles.css" rel="stylesheet">
```

Presumably, if you want to use the Material Icons your project already includes some form of the icons. If not see [Material Design Icons](https://dev.materialdesignicons.com/getting-started/webfont) for the available alternatives.

### Register and Configure Toasts Component
Add the `<BlazoredToasts />` tag into your applications *MainLayout.razor*.

Toasts are configured using parameters on the `<BlazoredToasts />` component. The following options are available.

- IconType (Default: `IconType.Blazored`)
- InfoClass
- InfoIcon
- SuccessClass
- SuccessIcon
- WarningClass
- WarningIcon
- ErrorClass
- ErrorIcon
- Position (Default: `ToastPosition.TopRight`)
- Timeout (Default: 5)
- MaxToastCount (Default: `int.MaxValue`)
- RemoveToastsOnNavigation
- ShowProgressBar
- CloseButtonContent (provide custom close button)
- ShowCloseButton (Default: `true`)
- DisableTimeout
- PauseProgressOnHover (Default: `false`)
- ExtendedTimeout

By default, you don't need to provide any settings everything will just work. But if you want to add icons to toasts or override the default styling then you can use the options above to do that. 

For example, to add an icon from Font Awesome to all success toasts you can do the following:

```razor
<BlazoredToasts IconType="IconType.FontAwesome" SuccessIcon="fa fa-thumbs-up"/>
```

Setting the position also requires a reference to `Blazored.Toast.Configuration`, for example:

```razor
@using Blazored.Toast.Configuration

<BlazoredToasts Position="ToastPosition.BottomRight"
                Timeout="10"
                IconType="IconType.FontAwesome"
                SuccessClass="success-toast-override"
                SuccessIcon="fa fa-thumbs-up"
                ErrorIcon="fa fa-bug" />
```

If you want to have your own custom close button, that can be configured via the `CloseButtonContent` parameter:
```razor
<BlazoredToasts Position="ToastPosition.BottomRight"
                Timeout="10">
    <CloseButtonContent>
        <div>
            <span>&times;</span>
        </div>
    </CloseButtonContent>
</BlazoredToasts>
```

## Usage
In order to show a toast you have to inject the `IToastService` into the component or service you want to trigger a toast. You can then call one of the following methods depending on what kind of toast you want to display, passing in a message and an optional heading.

- `ShowInfo`
- `ShowSuccess`
- `ShowWarning`
- `ShowError`


```razor
@page "/toastdemo"
@inject IToastService toastService

<h1>Toast Demo</h1>

To show a toast just click one of the buttons below.

<button class="btn btn-info" @onclick="@(() => toastService.ShowInfo("I'm an INFO message"))">Info Toast</button>
<button class="btn btn-success" @onclick="@(() => toastService.ShowSuccess("I'm a SUCCESS message with a custom title"))">Success Toast</button>
<button class="btn btn-warning" @onclick="@(() => toastService.ShowWarning("I'm a WARNING message"))">Warning Toast</button>
<button class="btn btn-danger" @onclick="@(() => toastService.ShowError("I'm an ERROR message"))">Error Toast</button>
```

### Show Progress Bar
You can display a progress bar which gives a visual indicator of the time remaining before the toast will disappear. In order to show the progress bar set the `ShowProgressBar` parameter to true.

```razor
<BlazoredToasts Position="ToastPosition.BottomRight"
                Timeout="10"
                ShowProgressBar="true" />
```

### Remove Toasts When Navigating
If you wish to clear any visible toasts when the user navigates to a new page you can enable the `RemoveToastsOnNavigation` parameter. Setting this to true will remove any visible toasts whenever the `LocationChanged` event fires.

### Limiting number of toasts shown at once
If you want to limit the number of toasts displayed at any given time, you can set the `MaxToastCount` parameter. For example, if the value is set to *3* only three toast instances will be displayed. Any additional toasts that are triggered will be held in a queue and will be displayed as older toasts time out.

### Custom Component
You can call the `ShowToast` method passing the type of component you want the toast to display.

For example if I have a component called `MyToast` which I want to display in the toast and I want to call it from the `Index` component on a button click.

```razor
@page "/toastdemo"
@inject IToastService toastService

<h1>Custom Toast Demo</h1>

<button class="btn btn-primary" @onclick="@(() => toastService.ShowToast<MyToast>())">Custom Toast</button>
```

### Passing Parameters
If you want to pass values to the component you're displaying in the toast, then you can use the `ToastParameters` object. The name you provide must match the name of a parameter defined on the component being displayed.

```razor
@page "/toastdemo"
@inject IToastService toastService

<h1>Custom Toast Demo</h1>

<button class="btn btn-primary" @onclick="@(() => toastService.ShowToast<MyToast>(_toastParameters))">Custom Toast with parameters</button>

@code
{
    private ToastParameters _toastParameters;

    protected override void OnInitialized()
    {
        _toastParameters = new ToastParameters();
        _toastParameters.Add(nameof(MyToast.Heading), "MyToast heading");
        _toastParameters.Add(nameof(MyToast.Message), "MyToast message");
    }
}
```
### Custom Component Options
Custom toast components can be customized. These settings can be set globally or changed programatically on a per toast basis. This is achieved using the `ToastInstanceSettings` class.
The following settings are available.
- `Timeout`
- `ShowProgressBar`

For Example if you want to change the duration of the timeout and disable the progress bar.

```razor
@page "/toastdemo"
@inject IToastService toastService

<h1>Custom Toast Demo</h1>

<button class="btn btn-primary" @onclick="@(() => toastService.ShowToast<MyToast>(new ToastInstanceSettings(5, false)))">Custom Toast</button>
```

Full examples for Blazor WebAssembly and Blazor Interactive Server are included in the [samples](https://github.com/Blazored/Toast/tree/main/samples).