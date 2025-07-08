using FluentResults;

namespace Alura.Adopet.Console.Comandos.Abstracoes
{
    public interface IComando
    {
        Task<Result> ExecutarAsync();
    }
}
