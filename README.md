Frozensoft Software Alerts is a package that allows you to easily send alerts to users in your ASP.NET Core project. 
You can either use bootstrap or make your own classes for the Alerts.

## These Instructions are only for .NET Core 5.0 and (.NET Core 3.1)

### Installation:

1. install the package from nuget: https://www.nuget.org/packages/FrozensoftSoftware.Alerts/
2. Setup your Startup.cs file:
   Inside of your ConfigureServices add this:
   ```csharp
    services.AddMvc().AddRazorRuntimeCompilation();
    services.Configure<MvcRazorRuntimeCompilationOptions>(options =>
    {
         options.FileProviders.Add(new EmbeddedFileProvider(
             typeof(FrozensoftSoftware.Alerts.ViewComponents.Alerts.AlertsViewComponent).Assembly));
     });
     
     // Registers the Alert Service
     services.AddScoped<IAlertService, AlertService>();
    ```
3. If you have a _ViewImports.cshtml file add this to it:
   ```sh
   @addTagHelper *, FrozensoftSoftware.Alerts
   ```
4. Add the ViewComponent, this can be done where ever you want it, in my instance I have put it inside of the _Layout.cshtml file:
   ```csharp
   <vc:alerts></vc:alerts>
   ```
5. Have fun and Enjoy :)


If you have any questions, suggestions or find any bugs feel free to let me know as I would really appreciate it.
