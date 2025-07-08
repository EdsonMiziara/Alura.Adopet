using Alura.Adopet.Console.Comandos.Abstracoes;
using Alura.Adopet.Console.Servicos.Arquivos;
using Alura.Adopet.Console.Servicos.Http;
using Alura.Adopet.Console.Servicos.Mail;
using Alura.Adopet.Console.Settings;

namespace Alura.Adopet.Console.Comandos.ComandoFactory;

public class ImportFactory : IComandoFactory
{
    public bool ConsegueCriarOTipo(Type? tipoComando)
    {
        return tipoComando?.IsAssignableTo(typeof(Import)) ?? false;
    }

    public IComando? CriarComando(string[] argumentos)
    {
        var petService = new PetService(new AdopetAPIClientFactory(Configurations.ApiSetting.Uri).CreateClient("adopet"));
        var leitorDeArquivosPet = LeitorDeArquivosFactory.CreatePetFrom(argumentos[1]);
        if (leitorDeArquivosPet is null) { return null; }
        var import = new Import(petService, leitorDeArquivosPet);
        import.DepoisDaExecucao += EnvioDeEmail.Disparar;
        return import;
    }
}
