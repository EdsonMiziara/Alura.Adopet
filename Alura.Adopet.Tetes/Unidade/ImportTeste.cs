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

        await import.ExecutarAsync();

        //Assert

        httpClientPet.Verify(
            client => client.CreatePetAsync(It.IsAny<Pet>()),
            Times.Never);

    }
    [Fact]

    public async Task QuandoArquivoNaoExistenteDeveGerarFalha()
    {
        //Arrange
        var listaDePet = new List<Pet>();

        var leitorDeArquivo = LeitorDeArquivosMoq.CriaMoq(listaDePet);
        leitorDeArquivo.Setup(_ => _.RealizaLeitura())
            .Throws(new FileNotFoundException());

        var httpClientPet = HttpClientPetMoq.CriaMoq();

        var import = new Import(httpClientPet.Object, leitorDeArquivo.Object);
        string[] args = new string[] { "import", "lista.csv" };

        //Act

        var resultado = await import.ExecutarAsync();

        //Assert
        Assert.True(resultado.IsFailed);

    }

    [Fact]

    public async void QuandoPetEstiverNoArquivoDeveSerImportado()
    {
        //Arrange
        List<Pet>? listaDePet = new();
        var pet = new Pet(new Guid("456b24f4-19e2-4423-845d-4a80e8854a99"),
        "Lima", TipoPet.Cachorro);
        listaDePet.Add(pet);

        var leitorDeArquivo = LeitorDeArquivosMoq.CriaMoq(listaDePet);

        var httpClientPet = HttpClientPetMoq.CriaMoq();

        var import = new Import(httpClientPet.Object, leitorDeArquivo.Object);
        string[] args = {"import", "lista.csv"}; 
        //Act
        var resultado = await import.ExecutarAsync();


        //Assert
        Assert.True(resultado.IsSuccess);
        
        var sucesso = (SuccessWithPets)resultado.Successes[0];
        Assert.Equal("Lima", sucesso.Data.First().Nome);


    }

}
