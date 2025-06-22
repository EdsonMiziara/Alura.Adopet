using System.IO;

namespace Alura.Adopet.Console.Apoio;

public class Import
{

    public readonly Extension extension;
    HttpClient client;

    public Import()
    {
        extension = new Extension();
        this.client = extension.client;
    }
    public async void ImportacaoArquivoPet(string caminhoDoArquivoDeImportacao)
    {
        List<Pet> listaDePet = new List<Pet>();

        string caminhoDoArquivoASerImportado = caminhoDoArquivoDeImportacao;
        using (StreamReader sr = new StreamReader(caminhoDoArquivoASerImportado))
        {
            while (!sr.EndOfStream)
            {
                // separa linha usando ponto e vírgula
                string[] propriedades = sr.ReadLine().Split(';');
                // cria objeto Pet a partir da separação
                Pet pet = new Pet(Guid.Parse(propriedades[0]),
                  propriedades[1],
                  TipoPet.Cachorro
                 );

                System.Console.WriteLine(pet);
                listaDePet.Add(pet);
            }
        }
        foreach (var pet in listaDePet)
        {
            try
            {
                var resposta = await extension.CreatePetAsync(pet);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
        System.Console.WriteLine("Importação concluída!");
    }
}
