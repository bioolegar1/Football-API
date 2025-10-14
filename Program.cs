using FutebolApi;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options => options.
    UseSqlite("Data Source=futebol.db"));

var app = builder.Build();

//GET all
app.MapGet("/times", async (AppDbContext db) =>
{
    return await db.Times.ToListAsync();
});

//GET by id
app.MapGet("/times/{id}", async (int id, AppDbContext db) =>
{
    var time = await db.Times.FindAsync(id);
    return time is not null ? Results.Ok(time) : Results.NotFound("Time não Encontrado");
});

//POST
app.MapPost("/times", async  (AppDbContext db, Time novoTime) =>
{
    await db.Times.AddAsync(novoTime);
    await db.SaveChangesAsync();
    return Results.Created($"O time {novoTime.Nome} foi adicionado com sucesso", novoTime);
});


app.Run();