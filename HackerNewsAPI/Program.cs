using HackerNewsAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Agregar servicios al contenedor
builder.Services.AddHttpClient<HackerNewsService>(); // Registrar servcios
builder.Services.AddControllers(); // Registrar controladores
builder.Services.AddHttpClient(); // Registrar HttpClient para inyecci�n de dependencias
builder.Services.AddEndpointsApiExplorer(); // Para endpoints API
builder.Services.AddSwaggerGen(); // Para documentaci�n OpenAPI

var app = builder.Build();

// Configurar el pipeline de solicitudes HTTP
if (app.Environment.IsDevelopment())
{
    // Mostrar documentaci�n Swagger en desarrollo
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers(); // Mapear autom�ticamente los controladores

app.Run();