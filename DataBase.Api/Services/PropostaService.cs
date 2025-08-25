using AutoMapper;
using DataBase.Api.Entities;
using DataBase.Api.Interfaces;
using DataBase.Api.Repositories;
using DataBase.Api.ViewModel;

namespace DataBase.Api.Services
{
    public class PropostaService : IPropostaService
    {
        private readonly PropostaRepository _propostaRepository;
        private readonly IMapper _mapper;

        public PropostaService(PropostaRepository propostaRepository, IMapper mapper)
        {
            _propostaRepository = propostaRepository;
            _mapper = mapper;
        }

        public List<PropostaViewModel> BuscarListaPropostas()
        {
            var result = _mapper.Map<List<PropostaViewModel>>(_propostaRepository.BuscarListaPropostas());
            return result;
        }

        public PropostaViewModel BuscarProposta(int id)
        {
            var result = _mapper.Map<PropostaViewModel>(_propostaRepository.BuscarProposta(id));
            return result;
        }

        public PropostaViewModel AdicionarProposta(PropostaViewModel propostaViewModel)
        {
            Proposta proposta = _mapper.Map<Proposta>(propostaViewModel);

            _propostaRepository.AdicionarProposta(proposta);

            return BuscarProposta(propostaViewModel.Id);
        }

        public PropostaViewModel AlterarNome(PropostaViewModel propostaViewModel)
        {
            var propostaDb = _propostaRepository.BuscarProposta(propostaViewModel.Id);
            if (propostaDb == null)
                return null;

            propostaDb.Nome = propostaViewModel.Nome;
            _propostaRepository.AlterarNome(propostaDb);

            return BuscarProposta(propostaViewModel.Id);
        }

        public PropostaViewModel AlterarStatus(PropostaViewModel propostaViewModel)
        {
            var propostaDb = _propostaRepository.BuscarProposta(propostaViewModel.Id);
            if (propostaDb == null)
                return null;

            propostaDb.Status = propostaViewModel.Status;
            _propostaRepository.AlterarStatus(propostaDb);

            return BuscarProposta(propostaViewModel.Id);
        }

        public bool DeletarProposta(int id)
        {
            var propostaDb = _propostaRepository.BuscarProposta(id);
            if (propostaDb == null)
                return false;

            _propostaRepository.DeletarProposta(id);
            return true;
        }
    }
}