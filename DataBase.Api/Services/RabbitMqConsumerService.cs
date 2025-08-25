using System.Text;
using System.Text.Json;
using DataBase.Api.Entities;
using DataBase.Api.ViewModel;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace DataBase.Api.Services
{
    public class RabbitMqConsumerService : BackgroundService
    {
        private const string HOST_NAME = "localhost";
        private const string USER_NAME = "guest";
        private const string PASSWORD = "guest";
        private const int PORT = 5674;

        private const string NOME_FILA_CRIAR_PROPOSTA = "fila-criar-proposta";
        private const string NOME_FILA_CRIAR_CONTRATACAO = "fila-criar-contratacao";

        private readonly IServiceScopeFactory _scopeFactory;
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public RabbitMqConsumerService(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;

            var factory = new ConnectionFactory()
            {
                HostName = HOST_NAME,
                Port = PORT,
                UserName = USER_NAME,
                Password = PASSWORD
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            _channel.QueueDeclare(NOME_FILA_CRIAR_PROPOSTA, true, false, false, null);
            _channel.QueueDeclare(NOME_FILA_CRIAR_CONTRATACAO, true, false, false, null);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumerProposta = new EventingBasicConsumer(_channel);
            consumerProposta.Received += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                var propostaViewModel = JsonSerializer.Deserialize<PropostaViewModel>(message);

                if (propostaViewModel != null)
                {
                    using var scope = _scopeFactory.CreateScope();
                    var propostaService = scope.ServiceProvider.GetRequiredService<PropostaService>();
                    propostaService.AdicionarProposta(propostaViewModel);
                }
            };

            var consumerContratacao = new EventingBasicConsumer(_channel);
            consumerContratacao.Received += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                var contratacaoViewModel = JsonSerializer.Deserialize<ContratacaoViewModel>(message);

                if (contratacaoViewModel != null)
                {
                    using var scope = _scopeFactory.CreateScope();
                    var contratacaoService = scope.ServiceProvider.GetRequiredService<ContratacaoService>();
                    contratacaoService.AdicionarContratacao(contratacaoViewModel);
                }
            };

            _channel.BasicConsume(NOME_FILA_CRIAR_PROPOSTA, true, consumerProposta);
            _channel.BasicConsume(NOME_FILA_CRIAR_CONTRATACAO, true, consumerContratacao);

            return Task.CompletedTask;
        }

        public override void Dispose()
        {
            _channel.Close();
            _connection.Close();
            base.Dispose();
        }
    }
}
