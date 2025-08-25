using AutoMapper;
using DataBase.Api.Repositories;
using DataBase.Api.ViewModel;

namespace DataBase.Api.Interfaces
{
    public interface IContratacaoService
    {
        List<ContratacaoViewModel> BuscarListaContratacoes();

        ContratacaoViewModel BuscarContratacao(int id);

        List<ContratacaoViewModel> BuscarContratacaoPorIdProposta(int idProposta);

        ContratacaoViewModel AdicionarContratacao(ContratacaoViewModel contratacaoViewModel);

        ContratacaoViewModel AlterarNome(ContratacaoViewModel contratacaoViewModel);

        bool DeletarContratacao(int id);
    }
}