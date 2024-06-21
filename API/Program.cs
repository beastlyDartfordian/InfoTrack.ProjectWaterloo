using API.Models;
using API.Services;

var allowLocalhost4200 = "allowLocalhost4200";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: allowLocalhost4200,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200",
                                                "https://localhost:4200")
                                .WithMethods("GET");
                      });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ISerpApiService, SerpApiService>();
builder.Services.AddSingleton<IPageRankingService, PageRankingService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(allowLocalhost4200);

app.UseAuthorization();

app.MapControllers();

app.Run();
