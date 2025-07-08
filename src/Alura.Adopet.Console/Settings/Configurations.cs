using Microsoft.Extensions.Configuration;

namespace Alura.Adopet.Console.Settings;

public static class Configurations
{
    private static IConfiguration? BuildConfiguration()
    {
        return new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddUserSecrets("e93981db-539b-4707-8e9f-50e2c09a18ce")
            .Build();
    }

    public static ApiSettings ApiSetting
    {
        get
        {
            var _config = BuildConfiguration();
            return _config
                .GetSection(ApiSettings.ApiSection)
                .Get<ApiSettings>() ?? throw new ArgumentException("Seção para configuração da API não encontrada");
        }
    }

    public static MailSettings EmailSettings
    {
        get
        {
            var _config = BuildConfiguration();
            return _config
                .GetSection(MailSettings.EmailSection)
                .Get<MailSettings>() ?? throw new ArgumentException("Seção para configuração de email não encontrada");
        }
    }
}
