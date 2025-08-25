using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proposta.Domain.Entities
{
    public class Proposta
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Status { get; set; }

        public Proposta(string? nome)
        {
            Nome = nome; //TODO: Fazer validação
            Status = "Em Análise";
        }
    }
}