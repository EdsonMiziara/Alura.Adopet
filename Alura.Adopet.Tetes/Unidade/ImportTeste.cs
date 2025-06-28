using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos;
using Alura.Adopet.Console.Util;
using Alura.Adopet.Testes.DataBuilders;
using Moq;
using System.Threading.Tasks;

namespace Alura.Adopet.Testes.Unidade;

public class ImportTeste
{
    [Fact]

    public async Task DadaListaVaziaNaoDeveChamarCreatePetAsync()
    {
        //Arrange
        var listaDePet = new List<Pet>();

        var leitorDeArquivo = LeitorDeArquivosMoq.CriaMoq(listaDePet);

        var httpClientPet = HttpClientPetMoq.CriaMoq();

        var import = new Import(httpClientPet.Object, leitorDeArquivo.Object);
        string[] args = new string[] { "import", "lista.csv" };

        //Act

        await import.ExecutarAsync(args);

        //Assert

        httpClientPet.Verify(
            client => client.CreatePetAsync(It.IsAny<Pet>()),
            Times.Never);

    }

}
