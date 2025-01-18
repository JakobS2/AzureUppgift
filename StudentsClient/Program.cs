using Azure.Security.KeyVault.Secrets;
using StudentsClient.Components;
using StudentsClient.Services;

var builder = WebApplication.CreateBuilder(args);




builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://studentapi-app-20250118105237.orangedesert-fea0bf8d.northeurope.azurecontainerapps.io/") });
builder.Services.AddScoped<ApiService>();

// Add services to the container.
builder.Services.AddRazorComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>();

app.Run();
