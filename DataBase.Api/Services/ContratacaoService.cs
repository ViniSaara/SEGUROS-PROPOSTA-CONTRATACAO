using AutoMapper;
using DataBase.Api.Entities;
using DataBase.Api.Interfaces;
using DataBase.Api.Repositories;
using DataBase.Api.ViewModel;

namespace DataBase.Api.Services
{
    public class ContratacaoService : IContratacaoService
    {
        private readonly ContratacaoRepository _contratacaoRepository;
        private readonly IMapper _mapper;

        public ContratacaoService(ContratacaoRepository contratacaoRepository, IMapper mapper)
        {
            _contratacaoRepository = contratacaoRepository;
            _mapper = mapper;
        }

        public List<ContratacaoViewModel> BuscarListaContratacoes()
        {
            var result = _mapper.Map<List<ContratacaoViewModel>>(_contratacaoRepository.BuscarListaContratacoes());
            return result;
        }

        public ContratacaoViewModel BuscarContratacao(int id)
        {
            var result = _mapper.Map<ContratacaoViewModel>(_contratacaoRepository.BuscarContratacao(id));
            return result;
        }
        public List<ContratacaoViewModel> BuscarContratacaoPorIdProposta(int idProposta)
        {
            var result = _mapper.Map<List<ContratacaoViewModel>>(_contratacaoRepository.BuscarContratacaoPorIdProposta(idProposta));
            return result;
        }

        public ContratacaoViewModel AdicionarContratacao(ContratacaoViewModel contratacaoViewModel)
        {
            Contratacao contratacao = _mapper.Map<Contratacao>(contratacaoViewModel);

            _contratacaoRepository.AdicionarContratacao(contratacao);

            return BuscarContratacao(contratacaoViewModel.Id);
        }

        public ContratacaoViewModel? AlterarNome(ContratacaoViewModel contratacaoViewModel)
        {
            var contratacaoDb = _contratacaoRepository.BuscarContratacao(contratacaoViewModel.Id);
            if (contratacaoDb == null)
                return null;

            contratacaoDb.Nome = contratacaoViewModel.Nome;
            _contratacaoRepository.AlterarNome(contratacaoDb);

            return BuscarContratacao(contratacaoViewModel.Id);
        }

        public bool DeletarContratacao(int id)
        {
            var contratacaoDb = _contratacaoRepository.BuscarContratacao(id);
            if (contratacaoDb == null)
                return false;

            _contratacaoRepository.DeletarContratacao(id);
            return true;
        }
    }
}