using Alura.Adopet.Console.Servicos;
using Alura.Adopet.Console.Util;

namespace Alura.Adopet.Console.Comandos;

public static class FabricaDeComandos
{

    public static IComando CriarComando(string[] argumentos)
    {
        if ((argumentos is null) || (argumentos.Length == 0))
        {
            return null;
        }
        var comando = argumentos[0];
        switch (comando)
        {
            case "import":
                HttpClientPet clientPet = new(new AdopetAPIClientFactory().CreateClient("Adopet"));
                LeitorDeArquivo leitorDeArquivos = new(argumentos[1]);
                return new Import(clientPet, leitorDeArquivos);
            case "list":
                HttpClientPet clientPetList = new(new AdopetAPIClientFactory().CreateClient("Adopet"));
                return new List(clientPetList);
            case "show":
                LeitorDeArquivo leitorDeArquivoShow = new(argumentos[1]);
                return new Show(leitorDeArquivoShow);
            case "help":
                var comandoASerExibido = argumentos.Length == 2 ? argumentos[1] : null;
                return new Help(comando: comandoASerExibido);
            default:
                return null;
        }
    }
}
