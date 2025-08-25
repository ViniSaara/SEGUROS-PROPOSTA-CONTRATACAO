using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contratacao.Domain.Ports
{
    public interface IGerenciamentoFilaService
    {
        void AdicionarNaFila(string mensagem, string nomeFila);
        void AdicionarNaFila<T>(T item, string nomeFila);
    }
}