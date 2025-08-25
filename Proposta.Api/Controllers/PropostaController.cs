using Microsoft.AspNetCore.Mvc;
using Proposta.Application.Services;
using Proposta.Domain.Dto;
using Proposta.Domain.Services;

namespace Proposta.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PropostaController : ControllerBase
    {
        private readonly IPropostaService _propostaService;

        public PropostaController(IPropostaService propostaService)
        {
            _propostaService = propostaService;
        }

        [Route("BuscarListaPropostas")]
        [HttpGet]
        public async Task<IActionResult> BuscarListaPropostas()
        {
            var listaPropostas = await _propostaService.BuscarListaPropostasAsync();
            return Ok(listaPropostas);
        }

        [Route("BuscarProposta")]
        [HttpGet]
        public async Task<IActionResult> BuscarProposta(int id)
        {
            var proposta = await _propostaService.BuscarPropostaAsync(id);
            return Ok(proposta);
        }

        [Route("AdicionarProposta")]
        [HttpPost]
        public async Task<IActionResult> AdicionarProposta(PropostaDto propostaDto)
        {
            _propostaService.AdicionarPropostaAsync(propostaDto);
            return Ok();
        }

        [Route("AlterarNome")]
        [HttpPatch]
        public async Task<IActionResult> AlterarNome(PropostaDto propostaDto)
        {
            var result = await _propostaService.AlterarNomeAsync(propostaDto);
            return Ok(result);
        }

        [Route("AlterarStatus")]
        [HttpPatch]
        public async Task<IActionResult> AlterarStatus(PropostaDto propostaDto)
        {
            var result = await _propostaService.AlterarStatusAsync(propostaDto);
            return Ok(result);
        }

        [Route("DeletarProposta")]
        [HttpDelete]
        public async Task<IActionResult> DeletarProposta(int id)
        {
            _propostaService.DeletarPropostaAsync(id);
            return Ok(true);
        }
    }
}