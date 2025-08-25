using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contratacao.Domain.Services
{
    public interface IContratacaoService
    {
        Task<IEnumerable<Dto.ContratacaoDto>> BuscarListaContratacoesAsync();
        Task<Dto.ContratacaoDto> BuscarContratacaoAsync(int id);
        Task<bool> AdicionarContratacaoAsync(int idProposta);
        Task<Dto.ContratacaoDto> AlterarNomeAsync(Dto.ContratacaoDto contratacaoDto);
        void DeletarContratacaoAsync(int id);
    }
}