using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proposta.Domain.Dto;

namespace Proposta.Domain.Services
{
    public interface IPropostaService
    {
        Task<IEnumerable<Domain.Dto.PropostaDto>> BuscarListaPropostasAsync();
        Task<Domain.Dto.PropostaDto> BuscarPropostaAsync(int id);
        void AdicionarPropostaAsync(PropostaDto proposta);
        Task<PropostaDto> AlterarNomeAsync(PropostaDto propostaDto);
        Task<PropostaDto> AlterarStatusAsync(PropostaDto propostaDto);
        void DeletarPropostaAsync(int id);
    }
}