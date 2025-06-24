using Alura.Adopet.Console.Modelos;

namespace Alura.Adopet.Console.Util;

public static class PetAPartirDoCsv
{
    public static Pet ConverteDoTexto(this string linha)
    {
        if (string.IsNullOrWhiteSpace(linha))
        {
            throw new ArgumentException("Linha não pode ser nula ou vazia", nameof(linha));
        }
        string[]? propriedades = linha.Split(';');
        if (propriedades.Length < 3)
        {
            throw new ArgumentException("Linha deve conter pelo menos 3 propriedades separadas por ponto e vírgula", nameof(linha));
        }
        Guid id = Guid.Parse(propriedades[0]);
        string nome = propriedades[1];
        TipoPet tipo = int.Parse(propriedades[2]) == 1 ? TipoPet.Gato : TipoPet.Cachorro;
        return new Pet(id, nome, tipo);
    }

}
