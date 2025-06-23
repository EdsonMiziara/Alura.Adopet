using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Adopet.Console.Comandos;

internal class ComandosDoSistema
{
    private Dictionary<string, IComando> comandosDoSistema = new()
    {
        { "import", new Import() },
        { "help", new Help() },
        { "show", new Show() },
        { "list", new List() }
    };

    public IComando? this [string key] =>
        comandosDoSistema.ContainsKey(key) ? comandosDoSistema[key] : null;
}
