using ApiExtendida.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Esta línea fuerza al entorno a usar la raíz de la app en lugar de buscar la carpeta 'wwwroot'
builder.Environment.WebRootPath = AppContext.BaseDirectory;

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<Somee_DataService>();
builder.Services.AddScoped<Azure_DataService>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseCors("AllowFrontend");

app.UseAuthorization();

app.MapControllers();

app.Run();
