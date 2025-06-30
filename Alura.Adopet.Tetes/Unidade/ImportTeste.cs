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

        var resultado = await import.ExecutarAsync(args);

        //Assert
        Assert.True(resultado.IsFailed);

    }

    [Fact]

    public async void QuandoPetEstiverNoArquivoDeveSerImportado()
    {
        //Arrange
        var listaDePet = new List<Pet>();
        var pet = new Pet(
            id: new Guid("456b24f4 - 19e2 - 4423 - 845d - 4a80e8854a41"),
            nome: "Lima",
            tipo: TipoPet.Cachorro
        );
        listaDePet.Add(pet);

        var leitorDeArquivo = LeitorDeArquivosMoq.CriaMoq(listaDePet);

        var httpClientPet = HttpClientPetMoq.CriaMoq();

        var import = new Import(httpClientPet.Object, leitorDeArquivo.Object);
        string[] args = {"import", "lista.csv"}; 
        //Act
        var resultado = await import.ExecutarAsync(args);


        //Assert
        Assert.True(resultado.IsSuccess);
        
        var sucesso = (SuccessWithPets)resultado.Successes[0];
        Assert.Equal("Lima", sucesso.Data.First().Nome);


    }

}
