namespace Alura.Adopet.Console.Comandos.Abstracoes;

public interface IComandoFactory
{
    bool ConsegueCriarOTipo(Type? tipoComando);
    IComando? CriarComando(string[] argumentos);
}
