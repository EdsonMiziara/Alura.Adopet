using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.Servicos;
using Alura.Adopet.Console.UI;
using Alura.Adopet.Console.Util;
using FluentResults;

HttpClientPet clientPet = new(new AdopetAPIClientFactory().CreateClient("Adopet"));
LeitorDeArquivo leitorDeArquivos = args.Length == 2 ? new(args[1]) : null;
Dictionary<string, IComando> comandosDoSistema = new()
{
    {"help",new Help() },
    {"import",new Import(clientPet, leitorDeArquivos)},
    {"list",new List(clientPet) },
    {"show",new Show(leitorDeArquivos) },
};


string comando = args[0].Trim();
if (comandosDoSistema.ContainsKey(comando))
{
    IComando? cmd = comandosDoSistema[comando];
    var resultado = await cmd.ExecutarAsync(args);
    ConsoleUI.ExibeResultado(resultado);
}
else
{
    ConsoleUI.ExibeResultado(Result.Fail("Comando Inválido"));
}



