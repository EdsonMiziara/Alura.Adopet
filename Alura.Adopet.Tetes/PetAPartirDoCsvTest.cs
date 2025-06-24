using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Util;

namespace Alura.Adopet.Tetes;

public class PetAPartirDoCsvTest
{
    [Fact]

    public void QuandoUmaStringForValidaDeveRetornarUmPet()
    {
        //Arrange
        string linha = "d0f8c1b2-3e4f-5a6b-7c8d-9e0f1a2b3c4d; Rex; 1";

        //Act
        Pet pet = linha.ConverteDoTexto();
        
        //Assert
        Assert.NotNull(pet);
    }

    [Theory]
    [InlineData("; Rex; 1")]
    [InlineData("a1b2c3d4-e5f6-7a8b-9c0d-e1f2g3h4i5j6; ; 2")]
    [InlineData("12345678-1234-5678-1234-567812345678; Max; ")]
    [InlineData(".; Max; 3")]
    [InlineData("; ; ;")]
    [InlineData("12345678-1234-5678-1234-567812345678; Olivia ")]

    public void QuandoUmaStringForInvalidaDeveLancarExcecao(string linha)
    {
        //Arrange


        //Act + Assert
        Assert.Throws<ArgumentException>(() => linha.ConverteDoTexto());
    }
}
