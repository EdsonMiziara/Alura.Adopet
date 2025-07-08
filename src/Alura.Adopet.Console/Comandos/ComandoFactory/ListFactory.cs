using Alura.Adopet.Console.Comandos.Abstracoes;
using Alura.Adopet.Console.Servicos.Http;
using Alura.Adopet.Console.Settings;

namespace Alura.Adopet.Console.Comandos.ComandoFactory;

public class ListFactory : IComandoFactory
{
    public bool ConsegueCriarOTipo(Type? tipoComando)
    {
        return tipoComando?.IsAssignableTo(typeof(List)) ?? false;
    }

    public IComando? CriarComando(string[] argumentos)
    {
        var petServiceList = new PetService(new AdopetAPIClientFactory(Configurations.ApiSetting.Uri).CreateClient("adopet"));
        return new List(petServiceList);
    }
}
