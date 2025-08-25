using AutoMapper;
using DataBase.Api.Entities;
using DataBase.Api.Services;
using DataBase.Api.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace DataBase.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContratacaoController : ControllerBase
    {
        private readonly ContratacaoService _contratacaoService;

        public ContratacaoController(ContratacaoService contratacaoService)
        {
            _contratacaoService = contratacaoService;
        }

        [Route("BuscarListaContratacoes")]
        [HttpGet]
        public List<ContratacaoViewModel> BuscarListaContratacoes()
        {
            return _contratacaoService.BuscarListaContratacoes();
        }

        [Route("BuscarContratacao")]
        [HttpGet]
        public ContratacaoViewModel BuscarContratacao(int id)
        {
            return _contratacaoService.BuscarContratacao(id);
        }

        [Route("BuscarContratacaoPorIdProposta")]
        [HttpGet]
        public List<ContratacaoViewModel> BuscarContratacaoPorIdProposta(int idProposta)
        {
            return _contratacaoService.BuscarContratacaoPorIdProposta(idProposta);
        }

        [Route("AdicionarContratacao")]
        [HttpPost]
        public ContratacaoViewModel AdicionarContratacao(ContratacaoViewModel contratacaoViewModel)
        {
            return _contratacaoService.AdicionarContratacao(contratacaoViewModel);
        }

        [Route("AlterarNome")]
        [HttpPatch]
        public ContratacaoViewModel? AlterarNome(ContratacaoViewModel contratacaoViewModel)
        {
            return _contratacaoService.AlterarNome(contratacaoViewModel);
        }

        [Route("DeletarContratacao")]
        [HttpDelete]
        public bool DeletarContratacao(int id)
        {
            bool result = _contratacaoService.DeletarContratacao(id);
            return true;
        }
    }
}