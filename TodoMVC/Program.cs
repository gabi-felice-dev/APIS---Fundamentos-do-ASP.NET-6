using TodoMVC.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(); //Adciona um service, disp em todo proj

var app = builder.Build();

app.MapControllers();

app.Run();
