using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos;
using Alura.Adopet.Console.Util;
using FluentResults;
using System.Drawing;

namespace Alura.Adopet.Console.Comandos;

[DocComandoAttribute(instrucao: "import",
    documentacao: "adopet import <ARQUIVO> comando que realiza a importação do arquivo de pets.")]
public class Import : IComando
{
    private readonly HttpClientPet clientPet;
    private readonly LeitorDeArquivo leitor;

    public Import(HttpClientPet clientPet, LeitorDeArquivo leitorDeArquivo)
    {
        this.clientPet = clientPet;
        this.leitor = leitorDeArquivo;

    }

    public async Task<Result> ExecutarAsync(string[] args)
    {
        return await this.ImportacaoArquivoPetAsync(caminhoDoArquivoDeImportacao: args[1]);
    }

    private async Task<Result> ImportacaoArquivoPetAsync(string caminhoDoArquivoDeImportacao)
    {
        try
        {
            List<Pet> listaDePet = leitor.RealizaLeitura();
            foreach (var pet in listaDePet)
            {
                System.Console.WriteLine(pet);
                await clientPet.CreatePetAsync(pet);
            }
            System.Console.WriteLine("Importação concluída!");
            return Result.Ok().WithSuccess(new SuccessWithPets(listaDePet));
        }
        catch (Exception ex) 
        {
            return Result.Fail(new Error("Importação falhou").CausedBy(ex));
        }
    }
}
