using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Proposta.Domain.Ports;
using RabbitMQ.Client;

namespace Proposta.Infra.Services
{
    public class GerenciamentoFilaService : IGerenciamentoFilaService
    {
        private ConnectionFactory _factory;

        public GerenciamentoFilaService()
        {
            _factory = new ConnectionFactory()
            {
                HostName = "localhost",
                Port = 5674,
                UserName = "guest",
                Password = "guest"
            };
        }

        public async void AdicionarNaFila(string mensagem, string nomeFila)
        {
            using (var connection = await _factory.CreateConnectionAsync())
            using (var channel = await connection.CreateChannelAsync())
            {
                await channel.QueueDeclareAsync(nomeFila, true, false, false, null);

                var body = Encoding.UTF8.GetBytes(mensagem);

                await channel.BasicPublishAsync("", nomeFila, body);
            }
        }

        public async void AdicionarNaFila<T>(T item, string nomeFila)
        {
            string mensagem = JsonSerializer.Serialize(item);
            AdicionarNaFila(mensagem, nomeFila);
        }
    }
}