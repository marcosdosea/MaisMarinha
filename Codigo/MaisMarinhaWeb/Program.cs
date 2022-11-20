using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;
using Service;
using Microsoft.AspNetCore.Identity;
using MaisMarinhaWeb.Areas.Identity.Data;

namespace MaisMarinhaWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
                        //var connectionString = builder.Configuration.GetConnectionString("MaisMarinhaConnection") ?? throw new InvalidOperationException("Connection string 'MaisMarinhaConnection' not found.");

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<MaisMarinhaContext>(
                options => options.UseMySQL("server=localhost;port=3306;user=root;password=123456;database=maismarinha"));
                

            /* 
            builder.Services.AddDefaultIdentity<UsuarioIdentity>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<IdentityContext>();
            */
            builder.Services.AddTransient<ICursoService, CursoService>();
            builder.Services.AddTransient<IPessoaService, PessoaService>();
            builder.Services.AddTransient<IConcursoService, ConcursoService>();
            builder.Services.AddTransient<ICapitaniaService, CapitaniaService>();
            builder.Services.AddTransient<IInscricaoCursoService, InscricaoCursoService>();

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
            
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}