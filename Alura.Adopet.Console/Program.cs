using System.Diagnostics.CodeAnalysis;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.Modelos;

ComandosDoSistema comandos = new();
Console.ForegroundColor = ConsoleColor.Green;
try
{
    string comando = args[0].Trim();
    var cmd = comandos[comando];
    if (cmd is not null )
    {
        await cmd.ExecutarAsync(args);
    }
    else
    {
        Console.WriteLine($"Comando '{comando}' não encontrado. Use 'adopet help' para ver os comandos disponíveis.");
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
