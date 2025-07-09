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
using static System.Runtime.InteropServices.JavaScript.JSType;

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
                const string connnectionString = "Server=tcp:controle-de-bar-2025.database.windows.net,1433;Initial Catalog=ControleDeBarDb;Persist Security Info=False;User ID=filipe;Password={Teste123};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

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
