var builder = WebApplication.CreateBuilder(args); //cria var para construir app web
var app = builder.Build(); //construir app web

//VERBOS
// GET - obter
// POST - Enviar
// PUT - Atualizar
// DELETE  - Excluir

app.MapGet("/", () => 
{
    return Results.Ok("Hello World");
});

app.MapGet("/{nome}", (string nome) => {

    return Results.Ok($"Hello World {nome}.");
});

app.MapPost("/", (User user) =>
{
    return Results.Ok(user);
});

app.Run(); //roda app web

public class User
{
    public int Id { get; set; }  
    public string? UserName { get; set; }
}

