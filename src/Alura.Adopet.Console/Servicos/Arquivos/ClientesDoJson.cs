
using Alura.Adopet.Console.Modelos;
using System.Text.Json;

namespace Alura.Adopet.Console.Servicos.Arquivos;

public class ClientesDoJson : LeitorDeArquivosJson<Cliente>
{
    public ClientesDoJson(string caminhoArquivo) : base(caminhoArquivo)
    {
    }
}

