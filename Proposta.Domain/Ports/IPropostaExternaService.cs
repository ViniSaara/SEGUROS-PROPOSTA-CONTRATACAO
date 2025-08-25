using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proposta.Domain.Ports
{
    public interface IPropostaExternaService
    {
        Task<IEnumerable<Dto.PropostaDto>> BuscarListaPropostasAsync();
        Task<Dto.PropostaDto> BuscarPropostaAsync(int id);
        Task<Dto.PropostaDto?> AlterarNomeAsync(Dto.PropostaDto propostaDto);
        Task<Dto.PropostaDto?> AlterarStatusAsync(Domain.Dto.PropostaDto propostaDto);
        void DeletarPropostaAsync(int id);
    }
}