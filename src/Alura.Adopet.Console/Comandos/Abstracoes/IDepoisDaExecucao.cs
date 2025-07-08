using FluentResults;

namespace Alura.Adopet.Console.Comandos.Abstracoes;

public interface IDepoisDaExecucao
{
    event Action<Result>? DepoisDaExecucao;

}
