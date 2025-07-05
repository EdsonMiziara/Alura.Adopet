using Alura.Adopet.Console.Modelos;

namespace Alura.Adopet.Console.Servicos.Abstracoes;
public interface IApiService<T>
{
    Task CreateAsync(T obj);
    Task<IEnumerable<T>?> ListAsync();
}
