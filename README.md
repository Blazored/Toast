# Blazored Toast
This is a JavaScript free toast implementation for [Blazor](https://blazor.net) and Razor Components application.

## Getting Setup
You can install the package via the nuget package manager just search for *Blazored.Toast*. You can also install via powershell using the following command.

```
Install-Package Blazored.Toast
```

Or via the dotnet CLI.

```
dotnet add package Blazored.Toast
```

### 1. Register Services
First, you will need to add the following line to your applications `Startup.ConfigureServices` method.

```
public void ConfigureServices(IServiceCollection services)
{
    services.AddBlazoredToast();
}
```

### 2. Add Imports
Second, add the following to your *_ViewImports.cshtml*

```
@using Blazored
@using Blazored.Toast.Services

@addTagHelper *, Blazored.Toast
```

### 3. Register Toasts Component
Third and finally you will need to register the `<Toasts />` component in your applications *MainLayout.cshtml*.

## Usage
In order to show a toast you have to inject the `IToastService` into the component or service you want to trigger a toast. You can then call the `ShowToast` method passing in the toast level you require along with the message to display and an optional heading. 

```
@page "/toastdemo"
@inject IToastService toastService

<h1>Toast Demo</h1>

To show a toast just click one of the buttons below.

<button class="btn btn-info" onclick="@(() => toastService.ShowToast(ToastLevel.Info, "I'm an INFO message"))">Info Toast</button>
<button class="btn btn-success" onclick="@(() => toastService.ShowToast(ToastLevel.Success, "I'm a SUCCESS message with a custom title", "Congratulations!"))">Success Toast</button>
<button class="btn btn-warning" onclick="@(() => toastService.ShowToast(ToastLevel.Warning, "I'm a WARNING message"))">Warning Toast</button>
<button class="btn btn-danger" onclick="@(() => toastService.ShowToast(ToastLevel.Error, "I'm an ERROR message"))">Error Toast</button>
```