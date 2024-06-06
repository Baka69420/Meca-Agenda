using MecaAgenda.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// *** DEPENDENCY INJECTION ***
// Repository

// Services

// AutoMapper

// SQL DB Connection
builder.Services.AddDbContext<MecaAgendaContext>(options =>
{
    // Read from appsettings.json
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerDataBase"));

    // Enable sensitive datalogging if in dev
    if(builder.Environment.IsDevelopment()) options.EnableSensitiveDataLogging();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
