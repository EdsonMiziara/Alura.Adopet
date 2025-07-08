using Alura.Adopet.Console.Atributos;
using Alura.Adopet.Console.Comandos.Abstracoes;
using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Results;
using Alura.Adopet.Console.Servicos.Abstracoes;
using FluentResults;

[DocComandoAttribute(instrucao: "list-clientes",
    documentacao: "adopet list comando que exibe no terminal o conteúdo cadastrado na base de dados da AdoPet.")]

public class ListClientes : IComando
{
    private readonly IApiService<Cliente> service;

    public ListClientes(IApiService<Cliente> service)
    {
        this.service = service;
    }

    public async Task<Result> ExecutarAsync()
    {
        try
        {
            IEnumerable<Cliente>? clientes = await service.ListAsync();
            return Result.Ok().WithSuccess(new SuccessWithClientes(clientes, "Listagem de clientes realizada com sucesso!"));
        }
        catch (Exception exception)
        {

            return Result.Fail(new Error("Listagem falhou!").CausedBy(exception));
        }
    }
}