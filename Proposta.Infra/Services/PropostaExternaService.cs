using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Proposta.Domain.Ports;

namespace Proposta.Infra.Services
{
    public class PropostaExternaService : IPropostaExternaService
    {
        private readonly JsonSerializerOptions _jsonSerializerOptions;
        private readonly HttpClient _httpClient;

        public PropostaExternaService(HttpClient httpClient)
        {
            _jsonSerializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:44352/");
        }

        public async Task<IEnumerable<Domain.Dto.PropostaDto>> BuscarListaPropostasAsync()
        {
            var response = await _httpClient.GetAsync("proposta/BuscarListaPropostas");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            if (string.IsNullOrEmpty(json))
                return Enumerable.Empty<Domain.Dto.PropostaDto>();

            return JsonSerializer.Deserialize<IEnumerable<Domain.Dto.PropostaDto>>(json, _jsonSerializerOptions);
        }

        public async Task<Domain.Dto.PropostaDto?> BuscarPropostaAsync(int id)
        {
            var response = await _httpClient.GetAsync($"proposta/BuscarProposta?id={id}");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            if (string.IsNullOrEmpty(json))
                return null;

            return JsonSerializer.Deserialize<Domain.Dto.PropostaDto>(json, _jsonSerializerOptions);
        }

        public async Task<Domain.Dto.PropostaDto?> AlterarNomeAsync(Domain.Dto.PropostaDto propostaDto)
        {
            var json = JsonSerializer.Serialize(propostaDto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PatchAsync("Proposta/AlterarNome", content);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<Domain.Dto.PropostaDto>(_jsonSerializerOptions);
        }

        public async Task<Domain.Dto.PropostaDto?> AlterarStatusAsync(Domain.Dto.PropostaDto propostaDto)
        {
            var json = JsonSerializer.Serialize(propostaDto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PatchAsync("Proposta/AlterarStatus", content);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<Domain.Dto.PropostaDto>(_jsonSerializerOptions);
        }

        public async void DeletarPropostaAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"proposta/DeletarProposta?id={id}");
            response.EnsureSuccessStatusCode();

            var result = response.Content.ReadAsStringAsync();
        }
    }
}