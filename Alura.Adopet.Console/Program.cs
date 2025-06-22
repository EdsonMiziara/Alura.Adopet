using System.Net.Http.Headers;
using System.Net.Http.Json;
using Alura.Adopet.Console;
using Alura.Adopet.Console.Apoio;

// cria instância de HttpClient para consumir API Adopet

Console.ForegroundColor = ConsoleColor.Green;
try
{
    string comando = args[0].Trim();
    switch (comando)
    {
        case "import":
            var import = new Import();
            import.ImportacaoArquivoPet(caminhoDoArquivoDeImportacao: args[1]);
            break;
        case "help":
            new Help().ExibeComandos(comandoRealizado: args);
            break;
        case "show":
            new Show().Exibir(caminhoDoArquivoASerExibido: args[1]);            
            break;
        case "list":
            new List().ListPetsAsync();
            break;
        default:
            // exibe mensagem de comando inválido
            Console.WriteLine("Comando inválido!");
            break;
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

