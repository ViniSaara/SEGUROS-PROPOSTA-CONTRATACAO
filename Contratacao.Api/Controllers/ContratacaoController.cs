using Contratacao.Domain.Dto;
using Contratacao.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Contratacao.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContratacaoController : ControllerBase
    {
        private readonly IContratacaoService _contratacaoService;

        public ContratacaoController(IContratacaoService contratacaoService)
        {
            _contratacaoService = contratacaoService;
        }

        [Route("BuscarListaContratacoes")]
        [HttpGet]
        public async Task<IActionResult> BuscarListaContratacaos()
        {
            var listaContratacaos = await _contratacaoService.BuscarListaContratacoesAsync();
            return Ok(listaContratacaos);
        }

        [Route("BuscarContratacao")]
        [HttpGet]
        public async Task<IActionResult> BuscarContratacao(int id)
        {
            var contratacao = await _contratacaoService.BuscarContratacaoAsync(id);
            if (contratacao == null)
                return NotFound();

            return Ok(contratacao);
        }

        [Route("AdicionarContratacao")]
        [HttpPost]
        public async Task<IActionResult> AdicionarContratacao(int idProposta)
        {
            bool result = await _contratacaoService.AdicionarContratacaoAsync(idProposta);
            return Ok(result);
        }

        [Route("AlterarNome")]
        [HttpPatch]
        public async Task<IActionResult> AlterarNome(ContratacaoDto contratacaoDto)
        {
            var result = await _contratacaoService.AlterarNomeAsync(contratacaoDto);
            return Ok(result);
        }

        [Route("DeletarContratacao")]
        [HttpDelete]
        public async Task<IActionResult> DeletarContratacao(int id)
        {
            _contratacaoService.DeletarContratacaoAsync(id);
            return Ok(true);
        }
    }
}