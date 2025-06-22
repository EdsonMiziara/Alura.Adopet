using System.IO;

namespace Alura.Adopet.Console.Apoio;

public class Help
{

    public void ExibeComandos(string[] comandoRealizado)
    {
        System.Console.WriteLine("Lista de comandos.");
        // se não passou mais nenhum argumento mostra help de todos os comandos
        if (comandoRealizado.Length == 1)
        {
            System.Console.WriteLine("adopet help <parametro> ous simplemente adopet help  " +
                 "comando que exibe informações de ajuda dos comandos.");
            System.Console.WriteLine("Adopet (1.0) - Aplicativo de linha de comando (CLI).");
            System.Console.WriteLine("Realiza a importação em lote de um arquivos de pets.");
            System.Console.WriteLine("Comando possíveis: ");
            System.Console.WriteLine($" adopet import <arquivo> comando que realiza a importação do arquivo de pets.");
            System.Console.WriteLine($" adopet show   <arquivo> comando que exibe no terminal o conteúdo do arquivo importado." + "\n\n\n\n");
            System.Console.WriteLine("Execute 'adopet.exe help [comando]' para obter mais informações sobre um comando." + "\n\n\n");
        }
        // exibe o help daquele comando específico
        else if (comandoRealizado.Length == 2)
        {
            string comandoASerExibido = comandoRealizado[1];
            if (comandoASerExibido.Equals("import"))
            {
                System.Console.WriteLine(" adopet import <arquivo> " +
                    "comando que realiza a importação do arquivo de pets.");
            }
            if (comandoASerExibido.Equals("show"))
            {
                System.Console.WriteLine(" adopet show <arquivo>  comando que " +
                    "exibe no terminal o conteúdo do arquivo importado.");
            }
            if (comandoASerExibido.Equals("list"))
            {
                System.Console.WriteLine(" adopet list comando que lista todos os pets cadastrados.");
            }
        }
    }

}
