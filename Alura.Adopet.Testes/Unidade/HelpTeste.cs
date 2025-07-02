using Alura.Adopet.Console.Comandos;

namespace Alura.Adopet.Testes.Unidade;

public class HelpTeste
{

    [Fact]

    public async Task QuandoComandoNaoExistirDeveRetornarFalha()
    {
        //Arrange
        var comando = "invalido";
        var help = new Help(comando);

        //Act
        var resultado = await help.ExecutarAsync();
        //Assert

        Assert.NotNull(resultado);
        Assert.True(resultado.IsFailed);
    }

    [Theory]
    [InlineData("import")]
    [InlineData("show")]
    [InlineData("list")]
    [InlineData("help")]

    public async Task QaundoComandoExistirDeveRetornarSucesso(string comando)
    {
        //Arrange
        var help = new Help(comando);

        //Act
        var resultado = await help.ExecutarAsync();

        //Assert

        Assert.NotNull(resultado);
        Assert.True(resultado.IsSuccess);
    }
}
