using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TaxCalculator.Application;
using TaxCalculator.Infrastructure;
using TaxCalculator.Infrastructure.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddValidatorsFromAssembly(typeof(ConfigureApplicationServices).Assembly);
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

var app = builder.Build();

// Initialise and seed database
using (var scope = app.Services.CreateScope())
{
    //var initialiser = scope.ServiceProvider.GetRequiredService<AppDbContextInitialiser>();
    //initialiser.Initialise();
    //initialiser.Seed();

    var c = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    c.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
