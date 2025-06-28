using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Util;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Adopet.Testes.DataBuilders;

internal static class LeitorDeArquivosMoq
{
    public static Mock<LeitorDeArquivo> CriaMoq(List<Pet> listaDePets)
    {
        var leitorDeArquivo = new Mock<LeitorDeArquivo>(MockBehavior.Default, It.IsAny<string>());

        leitorDeArquivo.Setup(_ => _.RealizaLeitura()).Returns(listaDePets);

        return leitorDeArquivo;
    }

}
