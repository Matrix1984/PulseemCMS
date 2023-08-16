

using PulseemCMS.Domain.AppSettings;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddWebServices();

builder.Services.Configure<DatabaseOptions>(
    builder.Configuration.GetSection("ConnectionStrings"));

 
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
}
else
{ 
    app.UseHsts();
}

//https://localhost:5001/swagger/index.html
app.UseSwaggerUi3();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}"); 

app.UseExceptionHandler(options => { });

if (app.Environment.IsDevelopment()) 
    app.Map("/", () => Results.Redirect("/swagger"));   

app.Run();

public partial class Program { }
