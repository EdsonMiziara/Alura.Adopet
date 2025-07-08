using Alura.Adopet.Console.Comandos.Abstracoes;
using Alura.Adopet.Console.Servicos.Http;
using Alura.Adopet.Console.Settings;

public class ListClientesFactory : IComandoFactory
{
    public bool ConsegueCriarOTipo(Type? tipoComando)
    {
        return tipoComando?.IsAssignableTo(typeof(ListClientes)) ?? false;
    }

    public IComando? CriarComando(string[] argumentos)
    {
        var clienteService = new ClienteService(new AdopetAPIClientFactory(Configurations.ApiSetting.Uri).CreateClient("adopet list comando que exibe no terminal o conteúdo cadastrado na base de dados da AdoPet."));
        return new ListClientes(clienteService);
    }
}