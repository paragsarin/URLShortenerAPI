using Microsoft.AspNetCore.Mvc;
using URLShortenerAPI.Util;
using URLShortnerAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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



app.MapPost("/snip.ly/shorten", ([FromBody] ShortenURLRequest request) =>
{
    string shortURL = URLShortener.ShortenURL(request.LongURL);
    return Results.Ok(new ShortenURLResponse { ShortURL = shortURL });
});

app.MapGet("/snip.ly/{idx}", (string idx) =>
{
    return Results.Redirect(URLShortener.GetLongURL(idx));
});

app.Run();

