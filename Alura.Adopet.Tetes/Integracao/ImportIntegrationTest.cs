using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos;
using Alura.Adopet.Console.Util;
using Alura.Adopet.Testes.DataBuilders;
using Moq;
using System.Threading.Tasks;

namespace Alura.Adopet.Testes.Integracao;

public class ImportIntegrationTest
{
    [Fact]

    public async Task QauandoApiNoArDeveRetornarListadePet()
    {
        //Arrange
        var listaDePet = new List<Pet>();
        var pet = new Pet(new Guid("b1f8c5d2-3e4f-4c6a-9b0c-7e8f9a0b1c2d"), "Rex", TipoPet.Cachorro);
        listaDePet.Add(pet);

        var leitorDeArquivo = LeitorDeArquivosMoq.CriaMoq(listaDePet);

        var clientPet = new HttpClientPet(new AdopetAPIClientFactory().CreateClient("Adopet"));

        Import import = new Import(clientPet, leitorDeArquivo.Object);
        string[] args = new string[] { "import", "lista.csv" };

        //Act

        await import.ExecutarAsync(args);

        //Assert
        var listapet = await clientPet.ListPetsAsync();
        Assert.NotNull(listapet);
    }

}
