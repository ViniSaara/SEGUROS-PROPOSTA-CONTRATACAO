using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proposta.Domain.Dto;
using Proposta.Domain.Ports;
using Proposta.Domain.Services;
using Proposta.Infra.Services;

namespace Proposta.Application.Services
{
    public class PropostaService : IPropostaService
    {
        private const string NOME_FILA_CRIAR_PROPOSTA = "fila-criar-proposta";

        private readonly IGerenciamentoFilaService _gerenciamentoFilaService;
        private readonly IPropostaExternaService _propostaExternaService;

        public PropostaService(IGerenciamentoFilaService gerenciamentoFilaService, IPropostaExternaService propostaExternaService)
        {
            _gerenciamentoFilaService = gerenciamentoFilaService;
            _propostaExternaService = propostaExternaService;
        }

        public async Task<IEnumerable<PropostaDto>> BuscarListaPropostasAsync()
        {
            return await _propostaExternaService.BuscarListaPropostasAsync();
        }

        public async Task<PropostaDto> BuscarPropostaAsync(int id)
        {
            var result = await _propostaExternaService.BuscarPropostaAsync(id);
            return result;
        }

        public void AdicionarPropostaAsync(PropostaDto propostaDto)
        {
            Domain.Entities.Proposta proposta = new Domain.Entities.Proposta(propostaDto.Nome);
            _gerenciamentoFilaService.AdicionarNaFila(proposta, NOME_FILA_CRIAR_PROPOSTA);
        }

        public async Task<PropostaDto> AlterarNomeAsync(PropostaDto propostaDto)
        {
            var result = await _propostaExternaService.AlterarNomeAsync(propostaDto);
            return result;
        }

        public async Task<PropostaDto> AlterarStatusAsync(PropostaDto propostaDto)
        {
            var result = await _propostaExternaService.AlterarStatusAsync(propostaDto);
            return result;
        }

        public async void DeletarPropostaAsync(int id)
        {
            _propostaExternaService.DeletarPropostaAsync(id);
        }
    }
}