using DataBase.Api.ViewModel;

namespace DataBase.Api.Interfaces
{
    public interface IPropostaService
    {
        List<PropostaViewModel> BuscarListaPropostas();
        PropostaViewModel BuscarProposta(int id);
        PropostaViewModel AdicionarProposta(PropostaViewModel propostaViewModel);
        PropostaViewModel AlterarNome(PropostaViewModel propostaViewModel);
        PropostaViewModel AlterarStatus(PropostaViewModel propostaViewModel);
        bool DeletarProposta(int id);
    }
}