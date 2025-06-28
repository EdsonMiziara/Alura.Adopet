using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.Servicos;
using Alura.Adopet.Console.Util;

HttpClientPet clientPet = new(new AdopetAPIClientFactory().CreateClient("Adopet"));
var leitorDeArquivo = new LeitorDeArquivo(caminhoDoArquivoASerLido: args[1]);    
Dictionary<string, IComando> comandosDoSistema = new()
{
    {"help",new Help() },
    {"import",new Import(clientPet, leitorDeArquivo)},
    {"list",new List(clientPet) },
    {"show",new Show(leitorDeArquivo) },
};

Console.ForegroundColor = ConsoleColor.Green;
try
{    
    string comando = args[0].Trim();
    if (comandosDoSistema.ContainsKey(comando))
    {
        IComando? cmd = comandosDoSistema[comando];
        await cmd.ExecutarAsync(args);
    }
    else
    {
        Console.WriteLine("Comando inválido!");
    } 
        
}
catch (Exception ex)
{
    // mostra a exceção em vermelho
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Aconteceu um exceção: {ex.Message}");
}
finally
{
    Console.ForegroundColor = ConsoleColor.White;
}
