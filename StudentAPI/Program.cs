using Microsoft.EntityFrameworkCore;
using StudentAPI;
using StudentAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<KeyVaultService>();

string keyVaultUri = "https://jakobskeyvault2.vault.azure.net/";
string secretName = "DefaultConnectionString";

var keyVaultService = new KeyVaultService(keyVaultUri);
var connectionString = keyVaultService.GetConnectionString(secretName);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(connectionString));

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("/students", async (ApplicationDbContext db) =>
{
   return await db.Students.ToListAsync();
});

app.Run();

