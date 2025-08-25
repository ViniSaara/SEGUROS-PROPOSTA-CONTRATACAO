using DataBase.Api.Entities;

namespace DataBase.Api.Interfaces
{
    public interface IContratacaoRepository
    {
        List<Contratacao> BuscarListaContratacoes();
        Contratacao BuscarContratacao(int id);
        List<Contratacao> BuscarContratacaoPorIdProposta(int idProposta);
        void AdicionarContratacao(Contratacao Contratacao);
        void AlterarNome(Contratacao contratacao);
        void DeletarContratacao(int id);
    }
}