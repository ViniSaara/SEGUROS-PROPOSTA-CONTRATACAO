using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contratacao.Domain.Dto;
using Contratacao.Domain.Ports;
using Contratacao.Domain.Services;

namespace Contratacao.Application.Services
{
    public class ContratacaoService : IContratacaoService
    {
        private const string NOME_FILA_CRIAR_CONTRATACAO = "fila-criar-contratacao";

        private readonly IGerenciamentoFilaService _gerenciamentoFilaService;
        private readonly IContratacaoExternaService _contratacaoExternaService;

        public ContratacaoService(IGerenciamentoFilaService gerenciamentoFilaService, IContratacaoExternaService contratacaoExternaService)
        {
            _gerenciamentoFilaService = gerenciamentoFilaService;
            _contratacaoExternaService = contratacaoExternaService;
        }

        public async Task<IEnumerable<ContratacaoDto>> BuscarListaContratacoesAsync()
        {
            return await _contratacaoExternaService.BuscarListaContratacoesAsync();
        }

        public async Task<ContratacaoDto> BuscarContratacaoAsync(int id)
        {
            var result = await _contratacaoExternaService.BuscarContratacaoAsync(id);
            return result;
        }
        public async Task<bool> AdicionarContratacaoAsync(int idProposta)
        {
            Domain.Dto.PropostaDto propostaDto = _contratacaoExternaService.ConsultarPropostaAsync(idProposta).Result;
            if (propostaDto == null || !propostaDto.Status.Equals("Aprovada"))
                return false;

            Domain.Entities.Contratacao contratacao = new Domain.Entities.Contratacao($"Contratada {propostaDto.Nome}", idProposta);
            _gerenciamentoFilaService.AdicionarNaFila(contratacao, NOME_FILA_CRIAR_CONTRATACAO);

            return true;
        }

        public async Task<ContratacaoDto> AlterarNomeAsync(ContratacaoDto contratacaoDto)
        {
            var result = await _contratacaoExternaService.AlterarNomeAsync(contratacaoDto);
            return result;
        }

        public async void DeletarContratacaoAsync(int id)
        {
            _contratacaoExternaService.DeletarContratacaoAsync(id);
        }
    }
}