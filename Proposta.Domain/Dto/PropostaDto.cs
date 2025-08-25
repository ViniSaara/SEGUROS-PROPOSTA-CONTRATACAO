using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proposta.Domain.Dto
{
    public class PropostaDto
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Status { get; set; }
    }
}