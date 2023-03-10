using ConnectorGIS_GMP.ApiClient;
using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddHttpClient<GisGmpClient>(client =>
{
    client.BaseAddress = new Uri("https://elpas.ru/api109731.php");
    client.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseEndpoints
(
    endpoints => endpoints.MapControllers()
);

app.Run();
