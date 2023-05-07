
using OpenAI.Exploration.Services;
using OpenAI.GPT3.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("./secrets.json", false);

// Add services to the container.
builder.Services.AddOpenAIService(settings =>
{
    settings.ApiKey = builder.Configuration.GetSection("OpenAI:ApiKey").Value!;
    settings.Organization = builder.Configuration.GetSection("OpenAI:Organization").Value!;
});

builder.Services.AddScoped<OpenAiClient>();
builder.Services.AddControllers();
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