using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Contratacao.Domain.Ports;

namespace Contratacao.Infra.Services
{
    public class ContratacaoExternaService : IContratacaoExternaService
    {
        private readonly JsonSerializerOptions _jsonSerializerOptions;
        private readonly HttpClient _httpClient;

        public ContratacaoExternaService(HttpClient httpClient)
        {
            _jsonSerializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:44352/");
        }

        public async Task<IEnumerable<Domain.Dto.ContratacaoDto>> BuscarListaContratacoesAsync()
        {
            var response = await _httpClient.GetAsync("Contratacao/BuscarListaContratacoes");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            if (string.IsNullOrEmpty(json))
                return Enumerable.Empty<Domain.Dto.ContratacaoDto>();

            return JsonSerializer.Deserialize<IEnumerable<Domain.Dto.ContratacaoDto>>(json, _jsonSerializerOptions);
        }

        public async Task<Domain.Dto.ContratacaoDto?> BuscarContratacaoAsync(int id)
        {
            var response = await _httpClient.GetAsync($"Contratacao/BuscarContratacao?id={id}");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            if (string.IsNullOrEmpty(json))
                return null;

            return JsonSerializer.Deserialize<Domain.Dto.ContratacaoDto>(json, _jsonSerializerOptions);
        }

        public async Task<Domain.Dto.PropostaDto?> ConsultarPropostaAsync(int idProposta)
        {
            _httpClient.BaseAddress = new Uri("https://localhost:44303/");
            var response = await _httpClient.GetAsync($"Proposta/BuscarProposta?id={idProposta}");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            if (string.IsNullOrEmpty(json))
                return null;

            return JsonSerializer.Deserialize<Domain.Dto.PropostaDto>(json, _jsonSerializerOptions);
        }

        public async Task<Domain.Dto.ContratacaoDto?> AlterarNomeAsync(Domain.Dto.ContratacaoDto ContratacaoDto)
        {
            var json = JsonSerializer.Serialize(ContratacaoDto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PatchAsync("Contratacao/AlterarNome", content);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<Domain.Dto.ContratacaoDto>(_jsonSerializerOptions);
        }

        public async void DeletarContratacaoAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"Contratacao/DeletarContratacao?id={id}");
            response.EnsureSuccessStatusCode();

            var result = response.Content.ReadAsStringAsync();
        }
    }
}