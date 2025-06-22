using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Adopet.Console.Apoio;

public class List
{
    Extension extension;

    public List()
    {
        extension = new Extension();
    }

    public async void ListPetsAsync()
    {
        var pets = await extension.ListPetsAsync();
        foreach (var pet in pets)
        {
            System.Console.WriteLine(pet);
        }
    }
}
