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
        if (string.IsNullOrEmpty(propriedades[0] ) || string.IsNullOrEmpty(propriedades[1] ) || string.IsNullOrEmpty(propriedades[2]))
        {
            throw new ArgumentException("As Propriedades não podem ser nulas ou vazia", nameof(linha));
        }
        try
        {
            Guid id = Guid.Parse(propriedades[0]);
            string nome = propriedades[1];
            TipoPet tipo = int.Parse(propriedades[2]) == 1 ? TipoPet.Gato : TipoPet.Cachorro;
            return new Pet(id, nome, tipo);
        }
        catch (FormatException)
        {
            throw new ArgumentException("O ID do Pet deve ser um GUID válido", nameof(linha));
        }

    }

}
