using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contratacao.Domain.Dto
{
    public class ContratacaoDto
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public int IdProposta { get; set; }
        public DateTime DataContratacao { get; set; }
    }
}