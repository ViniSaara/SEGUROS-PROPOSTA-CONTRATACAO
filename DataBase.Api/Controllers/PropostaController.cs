using AutoMapper;
using DataBase.Api.Entities;
using DataBase.Api.Services;
using DataBase.Api.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace DataBase.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PropostaController : ControllerBase
    {
        private readonly PropostaService _propostaService;

        public PropostaController(PropostaService propostaService)
        {
            _propostaService = propostaService;
        }

        [Route("BuscarListaPropostas")]
        [HttpGet]
        public List<PropostaViewModel> BuscarListaPropostas()
        {
            return _propostaService.BuscarListaPropostas();
        }

        [Route("BuscarProposta")]
        [HttpGet]
        public PropostaViewModel BuscarProposta(int id)
        {
            return _propostaService.BuscarProposta(id);
        }

        [Route("AdicionarProposta")]
        [HttpPost]
        public PropostaViewModel AdicionarProposta(PropostaViewModel propostaViewModel)
        {
            return _propostaService.AdicionarProposta(propostaViewModel);
        }

        [Route("AlterarNome")]
        [HttpPatch]
        public PropostaViewModel AlterarNome(PropostaViewModel propostaViewModel)
        {
            return _propostaService.AlterarNome(propostaViewModel);
        }

        [Route("AlterarStatus")]
        [HttpPatch]
        public PropostaViewModel AlterarStatus(PropostaViewModel propostaViewModel)
        {
            return _propostaService.AlterarStatus(propostaViewModel);
        }

        [Route($"DeletarProposta")]
        [HttpDelete]
        public bool DeletarProposta(int id)
        {
            bool result = _propostaService.DeletarProposta(id);
            return result;
        }
    }
}
