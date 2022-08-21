using MusicStore.Entities;// Importacion de las Clases de la entidades

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

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

//app.MapControllers();
//Obtiene los datos
// Creacion del CRUD

var list = new List<Genre>();
list.Add(new Genre { Id = 1, Name="Rock" });
list.Add(new Genre { Id = 2, Name="Jazz" });
list.Add(new Genre { Id = 3, Name="Metal" });

app.MapGet("/api/Genres", () =>
{
    return list;
});
//Polimorfismo 
app.MapGet("api/Genres/{id:int}", (int id) =>
{
    var data = list.Find(g => g.Id == id);

    if (data != null)
        return Results.Ok(data);

    return Results.NotFound();
}); // Obtener 1
app.MapPost("api/Genres", (Genre genre) =>
{
    list.Add(genre);
    genre.Id = list.Count;
    return Results.Ok(genre.Id);
}); // Crear Registro
app.MapPut("api/Genres/{id:int}", (int id, Genre genre) =>
{
    var data = list.Find(g => g.Id == id);
    if (data != null)
    {
        data.Name = genre.Name;
        data.Status = genre.Status;
        return Results.Ok(data);
    }
    return Results.NotFound();
});// Actualizar 1
app.MapDelete("api/Genres/{id:int}", (int id) =>
{
    var data = list.Find(g => g.Id == id);
    if (data != null)
    {
        list.Remove(data);
        return Results.Ok();
    }
    return Results.NotFound();
});

app.Run();