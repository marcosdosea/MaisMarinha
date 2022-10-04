using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;
using Service;

namespace MaisMarinhaWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<MaisMarinhaContext>(
                options => options.UseMySQL("server=localhost;port=3306;user=root;password=123456;database=maismarinha"));
            builder.Services.AddTransient<ICursoService, CursoService>();
            builder.Services.AddTransient<IPessoaService, PessoaService>();
            builder.Services.AddTransient<ICapitaniaService, CapitaniaService>();

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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
        }
    }
}