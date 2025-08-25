using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contratacao.Domain.Entities
{
    public class Contratacao
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public int IdProposta { get; set; }
        public DateTime DataContratacao { get; set; }

        public Contratacao(string? nome, int idProposta)
        {
            Nome = nome; //TODO: Fazer validação
            IdProposta = idProposta; //TODO: Fazer validação
            DataContratacao = DateTime.Now;
        }
    }
}