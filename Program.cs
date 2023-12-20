using System.Net.Http.Headers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using MovieApi;
using MovieApi.Data;
using MovieApi.Models;
using MovieApi.Repository;
using MovieApi.Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Set secrets
var tmbdToken = builder.Configuration.GetSection("ApiKey").GetValue<string>("TMBD");

// Add services to the container.
builder.Services.AddControllers()
                .AddNewtonsoftJson();

// builder.Services.Configure<ApiKey>(builder.Configuration.GetSection("ApiKey"));
// builder.Services.AddSingleton<IMovieRepository, MovieRepository>();
builder.Services.AddHttpClient("Tmbd", (httpClient) =>
{
    httpClient.BaseAddress = 
        new Uri ("https://api.themoviedb.org/3/");

    httpClient.DefaultRequestHeaders.Add(
        HeaderNames.Accept, "application/json");

    httpClient.DefaultRequestHeaders.Authorization =
        new AuthenticationHeaderValue("Bearer", tmbdToken);
    
});

builder.Services.AddSqlServer<DataContext>(builder.Configuration.GetConnectionString("MovieDb"),
                                        options => options.EnableRetryOnFailure());

// builder.Services.AddDbContext<DataContext>(options =>
//     options.UseSqlServer(builder.Configuration.GetConnectionString("MovieDb")));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IMovieRepository, MovieRepository>();

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
