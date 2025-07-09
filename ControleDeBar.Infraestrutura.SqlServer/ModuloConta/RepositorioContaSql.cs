using ControleDeBar.Dominio.ModuloConta;
using ControleDeBar.Infraestrutura.SqlServer.Compartilhado;
using System.Data;


namespace ControleDeBar.Infraestrutura.SqlServer.ModuloConta
{
    public class RepositorioContaSql : RepositorioBaseSql<Conta>, IRepositorioConta
    {
        public RepositorioContaSql(IDbConnection conexaoComBanco) : base(conexaoComBanco)
        {
        }

        protected override string SqlInserir => throw new NotImplementedException();

        protected override string SqlEditar => throw new NotImplementedException();

        protected override string SqlExcluir => throw new NotImplementedException();

        protected override string SqlSelecionarPorId => throw new NotImplementedException();

        protected override string SqlSelecionarTodos => throw new NotImplementedException();

        public void CadastrarConta(Conta conta)
        {
            throw new NotImplementedException();
        }

        public List<Conta> SelecionarContas()
        {
            throw new NotImplementedException();
        }

        public List<Conta> SelecionarContasAbertas()
        {
            throw new NotImplementedException();
        }

        public List<Conta> SelecionarContasFechadas()
        {
            throw new NotImplementedException();
        }

        public List<Conta> SelecionarContasPorPeriodo(DateTime data)
        {
            throw new NotImplementedException();
        }

        public Conta SelecionarPorId(Guid idRegistro)
        {
            throw new NotImplementedException();
        }

        protected override void ConfigurarParametrosRegistro(Conta registro, IDbCommand comando)
        {
            throw new NotImplementedException();
        }

        protected override Conta ConverterParaRegistro(IDataReader leitor)
        {
            throw new NotImplementedException();
        }
    }
}
