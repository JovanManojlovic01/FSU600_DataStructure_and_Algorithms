using Microsoft.EntityFrameworkCore;
using Travel_Agency.Components;
using TravelAgency;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContextFactory<TravelAgencyDB>(
    options => options.UseSqlite("Data Source = TravelAgency_DB.db"));

builder.Services.AddScoped<TravelAgency_Repository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
