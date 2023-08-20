using Microsoft.Extensions.FileProviders;



var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();



app.UseDefaultFiles();
app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new CompositeFileProvider(
        new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Frontend/Html")),
        new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Frontend/Css"))
    ),
    RequestPath = "/Frontend",
    ServeUnknownFileTypes = true
});



app.Run();