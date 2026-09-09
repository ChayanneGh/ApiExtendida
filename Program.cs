var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<DataService>();
builder.Services.AddOpenApi();

var app = builder.Build();

// 1. ⚠️ AGREGA ESTAS DOS LÍNEAS JUNTAS EN ESTE ORDEN:
app.UseDefaultFiles(); // Obliga a buscar automáticamente tu archivo 'index.html' en la raíz
app.UseStaticFiles();  // Habilita la lectura de carpetas físicas como 'css/' e 'index.html'

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
