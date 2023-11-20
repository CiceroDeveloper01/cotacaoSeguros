using CotacaoSeguroPipelineService;
using CotacacoSeguroService;
using CotacacoSeguroRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var stringConnection = builder.Configuration.GetConnectionString("Default");

builder.Services.AddControllers();
builder.Services.AddPipeline();
builder.Services.AddService();
builder.Services.AddRepository(stringConnection);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
