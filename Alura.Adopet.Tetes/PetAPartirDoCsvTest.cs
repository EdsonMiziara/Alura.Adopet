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
}
