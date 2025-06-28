using Alura.Adopet.Console.Util;

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

    public Task ExecutarAsync(string[] args)
    {
        this.ExibeConteudoArquivo(); 
        return Task.CompletedTask;
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
