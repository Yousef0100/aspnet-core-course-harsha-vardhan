using Microsoft.Extensions.FileProviders;

namespace S7_ModelBinding_Validations;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();

        var app = builder.Build();

        app.MapControllers();

        //app.MapGet("/", () => "Hello World!");

        #region The Right Order of Middleware in ASP.NET Core
        //app.UseExceptionHandler();                      // Exception handling
        //app.UseHsts();                                  // HSTS
        //app.UseHttpsRedirection();                      // HTTPS redirection
        //app.UseStaticFiles();                           // Static files
        //app.UseRouting();                               // Routing
        //app.UseCors();                                  // CORS
        //app.UseAuthentication();                        // Authentication
        //app.UseAuthorization();                         // Authorization
        //app.UseSession();                               // Session state
        //app.MapControllers();                           // MVC controllers
        //// custom middlewares                           // (app.UseMiddleware<YourCustomMiddleware>();)
        //// endpoints                                    // (Run, Use, UseWhen, Map, MapWhen, MapGet, MapPost, ...)
        #endregion

        app.Run();
    }
}
