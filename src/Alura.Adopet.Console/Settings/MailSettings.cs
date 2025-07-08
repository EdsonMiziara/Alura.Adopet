namespace Alura.Adopet.Console.Settings;
public class MailSettings
{
    public const string EmailSection = "AdopetEmailConfiguration";
    public string Servidor { get; set; } = string.Empty;
    public int Porta { get; set; }
    public string Usuario { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty;
}
