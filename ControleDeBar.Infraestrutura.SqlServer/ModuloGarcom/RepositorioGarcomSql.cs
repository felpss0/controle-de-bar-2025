using ControleDeBar.Dominio.ModuloGarcom;
using ControleDeBar.Infraestrutura.SqlServer.Compartilhado;
using System.Data;

namespace ControleDeBar.Infraestrutura.SqlServer.ModuloGarcom
{
    public class RepositorioGarcomSql : RepositorioBaseSql<Garcom>, IRepositorioGarcom
    {
        public RepositorioGarcomSql(IDbConnection conexaoComBanco) : base(conexaoComBanco)
        {
        }

        protected override string SqlInserir => @"
            INSERT INTO [TBGARCOM]
                (
                    [ID],
                    [NOME],
                    [CPF]
                )
                VALUES
                (
                    @ID,
                    @NOME,
                    @CPF
                );";

        protected override string SqlEditar => @"
            UPDATE [TBGARCOM]
            SET
                [NOME] = @NOME,
                [CPF] = @CPF
            WHERE
                [ID] = @ID";

        protected override string SqlExcluir => @"
            DELETE FROM [TBGARCOM]
            WHERE [ID] = @ID";

        protected override string SqlSelecionarPorId => @"
            SELECT
                [ID],
                [NOME],
                [CPF]
            FROM
                [TBGARCOM]
            WHERE 
                [ID] = @ID";

        protected override string SqlSelecionarTodos => @"
            SELECT 
                [ID],
                [NOME],
                [CPF]
            [TBGARCOM]";

        protected override void ConfigurarParametrosRegistro(Garcom registro, IDbCommand comando)
        {
            comando.AdicionarParametro("ID", registro.Id);
            comando.AdicionarParametro("NOME", registro.Nome);
            comando.AdicionarParametro("CPF", registro.Cpf);
        }

        protected override Garcom ConverterParaRegistro(IDataReader leitor)
        {
            var garcom = new Garcom()
            {
                Id = Guid.Parse(leitor["ID"].ToString()!),
                Nome = Convert.ToString(leitor["NOME"])!,
                Cpf = Convert.ToString(leitor["CPF"])!,
            };

            return garcom;
        }
    }
}
