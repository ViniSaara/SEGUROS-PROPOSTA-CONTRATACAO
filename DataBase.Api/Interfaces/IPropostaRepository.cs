using DataBase.Api.Entities;

namespace DataBase.Api.Interfaces
{
    public interface IPropostaRepository
    {
        List<Proposta> BuscarListaPropostas();
        Proposta BuscarProposta(int id);
        void AdicionarProposta(Proposta proposta);
        void AlterarNome(Proposta proposta);
        void AlterarStatus(Proposta proposta);
        void DeletarProposta(int id);
    }
}