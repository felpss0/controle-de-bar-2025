using ControleDeBar.Dominio.ModuloConta;
using ControleDeBar.Dominio.ModuloGarcom;
using ControleDeBar.Dominio.ModuloMesa;
using ControleDeBar.Dominio.ModuloProduto;
using ControleDeBar.Infraestrutura.SqlServer.ModuloConta;
using ControleDeBar.Infraestrutura.SqlServer.ModuloGarcom;
using ControleDeBar.Infraestrutura.SqlServer.ModuloMesa;
using ControleDeBar.Infraestrutura.SqlServer.ModuloProduto;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ControleDeBar.WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IDbConnection>(provider =>
            {
                var connnectionString = builder.Configuration["SQL_CONNECTION_STRING"];

                return new SqlConnection(connnectionString);
            });

            builder.Services.AddScoped<IRepositorioConta, RepositorioContaSql>();
            builder.Services.AddScoped<IRepositorioGarcom, RepositorioGarcomSql>();
            builder.Services.AddScoped<IRepositorioMesa, RepositorioMesaSql>();
            builder.Services.AddScoped<IRepositorioProduto, RepositorioProdutoSql>();


            var app = builder.Build();

            app.UseAntiforgery();
            app.UseStaticFiles();
            app.UseRouting();
            app.MapDefaultControllerRoute();

            app.Run();
        }
    }
}
