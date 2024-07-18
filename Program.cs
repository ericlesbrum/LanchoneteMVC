using LanchoneteMVC.Context;
using LanchoneteMVC.Repositories;
using LanchoneteMVC.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        //Connection
        builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection")));

        //DI
        builder.Services.AddTransient<ILancheRepository, LancheRepository>();
        builder.Services.AddTransient<ICategoriaRepository, CategoriaRepository>();
        builder.Services.AddTransient<IPedidoRepository, PedidoRepository>();
        
        builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        //trabalha em nivel de request
        builder.Services.AddScoped<ICarrinhoCompraRepository, CarrinhoCompraRepository>(sp => CarrinhoCompraRepository.GetCarrinho(sp));

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        builder.Services.AddDistributedMemoryCache();

        builder.Services.AddSession(options =>
        {
            options.IdleTimeout = TimeSpan.FromMinutes(20);
            options.Cookie.HttpOnly = true;
            options.Cookie.IsEssential = true;
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change th is for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseSession();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "categoriaFiltro",
            pattern: "Lanche/{action}/{categoria?}",
            defaults: new { Controller = "Lanche", Action = "List" });

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}