

using ControleDeBar.Dominio.ModuloProduto;
using ControleDeBar.Infraestrutura.SqlServer.Compartilhado;
using System.Data;

namespace ControleDeBar.Infraestrutura.SqlServer.ModuloProduto
{
    internal class RepositorioProdutoSql : RepositorioBaseSql<Produto>, IRepositorioProduto
    {
        public RepositorioProdutoSql(IDbConnection conexaoComBanco) : base(conexaoComBanco)
        {
        }

        protected override string SqlInserir => @"
                INSERT INTO [TBPRODUTO]
                (
                    [ID],
                    [NOME],
                    [PRECO]
                )
                VALUES
                (
                    @ID,
                    @NOME,
                    @PRECO
                )";

        protected override string SqlEditar => @"
                UPDATE [TBPRODUTO]
                SET
                    [NOME] = @NOME,
                    [PRECO] = @PRECO
                WHERE
                    [ID] = @ID";

        protected override string SqlExcluir => @"
                DELETE FROM [TBPRODUTO]
                WHERE [ID] = @ID";

        protected override string SqlSelecionarPorId => @"
                SELECT
                    [ID],
                    [NOME],
                    [PRECO]
                FROM
                    [TBPRODUTO]
                WHERE
                    [ID] = @ID";
                            
        protected override string SqlSelecionarTodos => @"
                SELECT
                    [ID],
                    [NOME],
                    [PRECO]
                FROM
                    [TBPRODUTO]";

        protected override void ConfigurarParametrosRegistro(Produto registro, IDbCommand comando)
        {
            comando.AdicionarParametro("ID", registro.Id);
            comando.AdicionarParametro("NOME", registro.Nome);
            comando.AdicionarParametro("PRECO", registro.Preco);
        }

        protected override Produto ConverterParaRegistro(IDataReader leitor)
        {
            var produto = new Produto
            {
                Id = Guid.Parse(leitor["ID"].ToString()!),
                Nome = Convert.ToString(leitor["NOME"])!,
                Preco = Convert.ToDecimal(leitor["PRECO"])
            };
            return produto;
        }
    }
}
