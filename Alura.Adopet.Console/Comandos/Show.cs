using Alura.Adopet.Console.Util;
using FluentResults;

namespace Alura.Adopet.Console.Comandos;

[DocComandoAttribute(instrucao: "show",
   documentacao: "adopet show <ARQUIVO> comando que exibe no terminal o conteúdo do arquivo importado.")]
public class Show:IComando
{
    private readonly LeitorDeArquivo leitor;

    public Show(LeitorDeArquivo leitor)
    {
        this.leitor = leitor;
    }

    public Task<Result> ExecutarAsync(string[] args)
    {
        try
        {
            this.ExibeConteudoArquivo();
            return Task.FromResult(Result.Ok());
        }
        catch (Exception ex)
        {
            return Task.FromResult(Result.Fail(new Error("Falha ao exibir o conteúdo do arquivo").CausedBy(ex)));
        }

    }

    private void ExibeConteudoArquivo()
    {
        var listaDepets = leitor.RealizaLeitura();
        foreach (var pet in listaDepets)
        {
            System.Console.WriteLine(pet);
        }


    }
}
