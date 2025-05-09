using PTQ.Models;
using PTQ.Repositories;

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

string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (string.IsNullOrEmpty(connectionString))
{
    Console.WriteLine("No connection string found.");
    return;
}
DatabaseController controller = new(connectionString);

app.MapGet("/api/quizzes", () =>
{
    List<GetAllTestResponseBody> result = controller.GetAllTests();
    return Results.Ok(result);
});
app.MapGet("/api/quizzes/{id}", (int id) =>
{
    Quiz requestedQuiz = controller.GetTestById(id);
    return Results.Ok(requestedQuiz);
});

/*app.MapPost("/api/quizzes", () =>
{

});*/

app.Run();