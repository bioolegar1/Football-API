using FutebolApi;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options => options.
    UseSqlite("Data Source=futebol.db"));

var app = builder.Build();

//GET all - READ
app.MapGet("/times", async (AppDbContext db) =>
{
    return await db.Times.ToListAsync();
});

//GET by id - READ
app.MapGet("/times/{id}", async (int id, AppDbContext db) =>
{
    var time = await db.Times.FindAsync(id);
    return time is not null ? Results.Ok(time) : Results.NotFound("Time não Encontrado");
});

//POST - CREATE
app.MapPost("/times", async  (AppDbContext db, Time novoTime) =>
{
    await db.Times.AddAsync(novoTime);
    await db.SaveChangesAsync();
    return Results.Created($"O time {novoTime.Nome} foi adicionado com sucesso", novoTime);
});

//PUT -  UPDATE
app.MapPut("/times/{id}", async (int id, AppDbContext db, Time timeAtualizado) =>
{
    var time = await db.Times.FindAsync(id);
    if (time is null) return Results.NotFound("Time não encontrado");

    time.Nome = timeAtualizado.Nome;
    time.Cidade = timeAtualizado.Cidade;
    time.TitulosBrasileiros = timeAtualizado.TitulosBrasileiros;
    time.TitulosMundiais = timeAtualizado.TitulosMundiais;
    
    await db.SaveChangesAsync();
    return Results.Ok($"{time.Nome} Teve as informações atualizadas com sucesso");
});

//DELETE - VAI DE ARRASTA
app.MapDelete("/times/{id}", async (int id, AppDbContext db) =>
{
    var time = await db.Times.FindAsync(id);
    if (time is null) return Results.NotFound("Time não encontrado");
    
    db.Times.Remove(time);
    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.Run();