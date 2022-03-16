using Microsoft.EntityFrameworkCore;
using PedidoAPI.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>
   (Options => Options.UseMySql(
       "server=localhost;initial catalog=db_delivery;uid=root;pwd=Karollopes@@2022",
        Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.28-mysql")));


// Add services to the container.
builder.Services.AddControllersWithViews();

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
    pattern: "{controller=Api}/{action=orders}/{id?}");

app.Run();
