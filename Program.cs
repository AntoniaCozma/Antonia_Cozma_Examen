using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Antonia_Cozma_Examen.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages(options => { options.Conventions.AuthorizeFolder("/Autoturisme"); });
builder.Services.AddDbContext<Antonia_Cozma_ExamenContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Antonia_Cozma_ExamenContext") ?? throw new InvalidOperationException("Connection string 'Antonia_Cozma_ExamenContext' not found.")));

var app = builder.Build();

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

app.UseAuthorization();

app.MapRazorPages();

app.Run();
