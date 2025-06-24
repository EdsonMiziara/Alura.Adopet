using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Adopet.Tetes;

public class HttpClientPetTest
{
    [Fact]

    public async Task ListaPetDeveRetornarListaNaoVazia()
    {
        //Arrange
        var clientPet = new HttpClientPet();

        //Act
        var lista = await clientPet.ListPetsAsync();

        //Assert
        Assert.NotNull(lista);
        Assert.NotEmpty(lista);
    }
    [Fact]

    public async Task QuandoApiForaDeveRetornarExcecao()
    {
        //Arrange
        var clientPet = new HttpClientPet(uri: "http://localhost:11111");

        //Act + Assert
        await Assert.ThrowsAnyAsync<HttpRequestException>(
             () => clientPet.ListPetsAsync());
    }
    [Fact]

    public async Task QuandoApiOnlineEDadosCorretosDeveCriarPetNoBanco()
    {
        //Arrange
        var clientPet = new HttpClientPet();
        Pet pet = new(Guid.NewGuid(), "Cleber", TipoPet.Gato);

        //Act
        await clientPet.CreatePetAsync(pet);
        var lista = await clientPet.ListPetsAsync();

        bool petExiste = lista?.Any(p => p.Nome == pet.Nome) ?? false;

        //Assert
        Assert.True(petExiste);
    }

}
