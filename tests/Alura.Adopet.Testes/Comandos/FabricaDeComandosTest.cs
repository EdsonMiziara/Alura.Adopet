using Alura.Adopet.Console.Comandos;

namespace Alura.Adopet.Testes.Comandos;

public class FabricaDeComandosTest
{
    [Theory]
    [InlineData("Import", "Import")]
    [InlineData("List", "List")]
    [InlineData("Show", "Show")]
    [InlineData("Help", "Help")]
    [InlineData("ImportClientes", "ImportClientes")]

    public void DadoParametroValidoDeveRetornarObjetoNaoNulo(string instrucao, string tipoComando)
    {
        //Arrange
        string[] args = new[] { instrucao, "lista.csv" };

        //Act
        var comando = ComandosFactory.CriarComando(args);
        //Assert
        Assert.NotNull(comando);
        Assert.Equal(tipoComando, comando.GetType().Name);
    }

    [Fact]
    public void DadoUmParametroDeveRetornarUmTipoImport()
    {
        //Arrange
        string[] args = { "Import", "lista.csv" };
        //Act
        var comando = ComandosFactory.CriarComando(args);
        //Assert
        Assert.IsType<Import>(comando); 
    }

    [Fact]
    public void DadoUmParametroDeveRetornarUmTipoList()
    {
        //Arrange
        string[] args = { "List", "lista.csv" };
        //Act
        var comando = ComandosFactory.CriarComando(args);
        //Assert
        Assert.IsType<List>(comando);
    }


    [Fact]
    public void DadoUmParametroInvalidoDeveRetornarNulo()
    {
        //Arrange
        string[] args = { "invalid", "lista.csv" };
        //Act
        var comando = ComandosFactory.CriarComando(args);
        //Assert
        Assert.Null(comando);
    }

    [Fact]
    public void DadoUmArrayDeArgumentosNuloDeveRetornarNulo()
    {
        //Arrange           
        //Act
        var comando = ComandosFactory.CriarComando(null);
        //Assert
        Assert.Null(comando);
    }

    [Fact]
    public void DadoUmArrayDeArgumentosVazioDeveRetornarNulo()
    {
        //Arrange
        string[] args = { };
        //Act
        var comando = ComandosFactory.CriarComando(args);
        //Assert
        Assert.Null(comando);
    }



}
