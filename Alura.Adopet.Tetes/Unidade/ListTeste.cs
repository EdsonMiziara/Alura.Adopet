using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Util;
using Alura.Adopet.Testes.DataBuilders;

namespace Alura.Adopet.Testes.Unidade;

public class ListTeste
{
    [Fact]
    public async Task QuandoExecutarComandoListDeveRetornarListaDePets()
    {
        //Arrange
        List<Pet>? listaDePet = new();
        var pet = new Pet(new Guid("456b24f4-19e2-4423-845d-4a80e8854a99"),
                          "Lima", TipoPet.Cachorro);
        listaDePet.Add(pet);

        var httpClientPet = HttpClientPetMoq.GetMoqList(listaDePet);

        //Act
        var retorno = await new List(httpClientPet.Object)
            .ExecutarAsync();

        //Assert
        var resultado = (SuccessWithPets)retorno.Successes[0];
        Assert.Single(resultado.Data);
    }
}
