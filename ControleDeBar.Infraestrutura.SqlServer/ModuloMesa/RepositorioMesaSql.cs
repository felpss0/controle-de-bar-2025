using ControleDeBar.Dominio.ModuloMesa;
using ControleDeBar.Infraestrutura.SqlServer.Compartilhado;
using System.Data;

namespace ControleDeBar.Infraestrutura.SqlServer.ModuloMesa
{
    public class RepositorioMesaSql : RepositorioBaseSql<Mesa>, IRepositorioMesa
    {
        public RepositorioMesaSql(IDbConnection conexaoComBanco) : base(conexaoComBanco)
        {
        }

        protected override string SqlInserir => @"
            INSERT INTO [TBMESA]
                (
                    [ID],
                    [NUMERO],
                    [CAPACIDADE],
                    [ESTAOCUPADA]
                )
                VALUES
                (
                    @ID,
                    @NUMERO,
                    @CAPACIDADE,
                    @ESTAOCUPADA
                );";

        protected override string SqlEditar => @"
                UPDATE [TBMESA]
                SET
                    [NUMERO] = @NUMERO,
                    [CAPACIDADE] = @CAPACIDADE,
                    [ESTAOCUPADA] = @ESTAOCUPADA
                WHERE
                    [ID] = @ID";

        protected override string SqlExcluir => @"
                DELETE FROM [TBMESA]
                WHERE [ID] = @ID";

        protected override string SqlSelecionarPorId => @"
                SELECT
                    [ID],
                    [NUMERO],
                    [CAPACIDADE],
                    [ESTAOCUPADA],
                FROM
                    [TBMESA]
                WHERE
                    [ID] = @ID";

        protected override string SqlSelecionarTodos => @"
                SELECT
                    [ID],
                    [NUMERO],
                    [CAPACIDADE],
                    [ESTAOCUPADA]
                FROM
                    [TBMESA]";

        protected override void ConfigurarParametrosRegistro(Mesa registro, IDbCommand comando)
        {
            comando.AdicionarParametro("ID", registro.Id);
            comando.AdicionarParametro("NUMERO", registro.Numero);
            comando.AdicionarParametro("CAPACIDADE", registro.Capacidade);
            comando.AdicionarParametro("ESTAOCUPADA", registro.EstaOcupada);
        }

        protected override Mesa ConverterParaRegistro(IDataReader leitor)
        {
            var mesa = new Mesa
            {
                Id = Guid.Parse(leitor["ID"].ToString()!),
                Numero = Convert.ToInt32(leitor["NUMERO"].ToString()!),
                Capacidade = Convert.ToInt32(leitor["CAPACIDADE"].ToString()!),
                EstaOcupada = Convert.ToBoolean(leitor["ESTAOCUPADA"].ToString()!)
            };
            return mesa;
        }
    }
}
