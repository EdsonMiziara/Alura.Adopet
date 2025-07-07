using Alura.Adopet.Console.Servicos.Http;
using Alura.Adopet.Console.Servicos.Arquivos;

namespace Alura.Adopet.Console.Comandos;

public static class ComandosFactory
{
    public static IComando? CriarComando(string[] argumentos)
    {
        if ((argumentos is null) || (argumentos.Length == 0))
        {
            return null;
        }
        var comando = argumentos[0];
        switch (comando)
        {
            case nameof(Import):
                var petService = new PetService(new AdopetAPIClientFactory().CreateClient("adopet"));
                var leitorDeArquivosPet = LeitorDeArquivosFactory.CreatePetFrom(argumentos[1]);
                if (leitorDeArquivosPet is null) { return null; }
                return new Import(petService, leitorDeArquivosPet);

            case nameof(ImportClientes):
                var clienteService = new ClienteService(new AdopetAPIClientFactory().CreateClient("adopet"));
                var leitorDeArquivosClientes = LeitorDeArquivosFactory.CreateClienteFrom(argumentos[1]);
                if (leitorDeArquivosClientes is null) { return null; }
                return new ImportClientes(clienteService, leitorDeArquivosClientes);

            case nameof(List):
                var petServiceList = new PetService(new AdopetAPIClientFactory().CreateClient("adopet"));
                return new List(petServiceList);

            case nameof(Show):
                var leitorDeArquivosShow = LeitorDeArquivosFactory.CreatePetFrom(argumentos[1]);
                if (leitorDeArquivosShow is null) { return null; }
                return new Show(leitorDeArquivosShow);

            case nameof(Help):
                var comandoASerExibido = argumentos.Length==2? argumentos[1] : null;
                return new Help(comandoASerExibido);

            default: return null;
        }           
    }
}
