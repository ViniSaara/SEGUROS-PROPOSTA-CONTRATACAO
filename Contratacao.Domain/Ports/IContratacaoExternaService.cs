using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contratacao.Domain.Ports
{
    public interface IContratacaoExternaService
    {
        Task<IEnumerable<Dto.ContratacaoDto>> BuscarListaContratacoesAsync();
        Task<Dto.ContratacaoDto> BuscarContratacaoAsync(int id);
        Task<Dto.PropostaDto> ConsultarPropostaAsync(int idProposta);
        Task<Dto.ContratacaoDto?> AlterarNomeAsync(Dto.ContratacaoDto contratacaoDto);
        void DeletarContratacaoAsync(int id);
    }
}