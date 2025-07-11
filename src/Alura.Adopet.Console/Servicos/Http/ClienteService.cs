﻿using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos.Abstracoes;
using System.Net.Http.Json;

namespace Alura.Adopet.Console.Servicos.Http;

public class ClienteService : IApiService<Cliente>
{
    private HttpClient client;

    public ClienteService(HttpClient httpClient)
    {
        client = httpClient;
    }

    public Task CreateAsync(Cliente cliente)
    {
        return client.PostAsJsonAsync("client/add", cliente);
    }

    public async Task<IEnumerable<Cliente>?> ListAsync()
    {
        HttpResponseMessage response = await client.GetAsync("cliente/list");
        return await response.Content.ReadFromJsonAsync<IEnumerable<Cliente>>();
    }
}
