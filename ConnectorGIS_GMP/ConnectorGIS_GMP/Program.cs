using ConnectorGIS_GMP.ApiClient;
using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddHttpClient<GisGmpClient>(client =>
{
    client.BaseAddress = new Uri("https://elpas.ru/api109731.php");
    client.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
    //client.DefaultRequestHeaders.TryAddWithoutValidation(new MediaTypeHeaderValue("application/json")
    //{
    //    CharSet = Encoding.UTF8.WebName
    //});
});

var app = builder.Build();

// Configure the HTTP request pipeline.
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
