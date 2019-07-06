# Blazored Toast
This is a JavaScript free toast implementation for [Blazor](https://blazor.net) and Razor Components applications.

[![Build Status](https://dev.azure.com/blazored/Toast/_apis/build/status/Blazored.Toast?branchName=master)](https://dev.azure.com/blazored/Toast/_build/latest?definitionId=3&branchName=master)

![Nuget](https://img.shields.io/nuget/v/blazored.toast.svg)

## Important Notice For Blazor server-side Apps
There is currently an issue with [Blazor server-side apps](https://devblogs.microsoft.com/aspnet/aspnet-core-3-preview-2/#sharing-component-libraries) (not Blazor). They are unable to import static assets from component libraries such as this one. 

You can still use this package, however, you will need to manually add the CSS to your apps `wwwroot` folder. You will then need to add a reference to it in the `head` tag of your apps `index.html` page.

Alternatively, there is a great package by [Mister Magoo](https://github.com/SQL-MisterMagoo/BlazorEmbedLibrary) which offers a solution to this problem without having to manually copy files.

## Getting Setup
You can install the package via the nuget package manager just search for *Blazored.Toast*. You can also install via powershell using the following command.

```powershell
Install-Package Blazored.Toast
```

Or via the dotnet CLI.

```bash
dotnet add package Blazored.Toast
```

### 1. Register Services
First, you will need to register the Blazored Toast service in your applications `Startup.ConfigureServices` method.

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddBlazoredToast();
}
```

### 2. Add Imports
Second, add the following to your *_Imports.razor*

```csharp
@using Blazored
@using Blazored.Toast.Services
```

### 3. Register and Configure Toasts Component
Third and finally you will need to register the `<BlazoredToasts />` component in your applications *MainLayout.razor*.

With version 2 configuration of toasts is now done using parameters on the `<BlazoredToasts />` component. The following options are available.

- InfoClass
- InfoIconClass
- SuccessClass
- SuccessIconClass
- WarningClass
- WarningIconClass
- ErrorClass
- ErrorIconClass
- Position (Default: ToastPosition.TopRight)
- Timeout (Default: 5)

By default, you don't need to provide any settings everything will just work. But if you want to add icons to toasts or override the default styling then you can use the options above to do that. 

For example, to add a icon from Font Awesome to all success toasts you can do the following.

```html
<BlazoredToasts SuccessIconClass="fa fa-thumbs-up"/>
```

## Usage
In order to show a toast you have to inject the `IToastService` into the component or service you want to trigger a toast. You can then call one of the following methods depending on what kind of toast you want to display, passing in a message and an optional heading.

- `ShowInfo`
- `ShowSuccess`
- `ShowWarning`
- `ShowError`


```html
@page "/toastdemo"
@inject IToastService toastService

<h1>Toast Demo</h1>

To show a toast just click one of the buttons below.

<button class="btn btn-info" @onclick="@(() => toastService.ShowInfo("I'm an INFO message"))">Info Toast</button>
<button class="btn btn-success" @onclick="@(() => toastService.ShowSuccess("I'm a SUCCESS message with a custom title", "Congratulations!"))">Success Toast</button>
<button class="btn btn-warning" @onclick="@(() => toastService.ShowWarning("I'm a WARNING message"))">Warning Toast</button>
<button class="btn btn-danger" @onclick="@(() => toastService.ShowError("I'm an ERROR message"))">Error Toast</button>
```
