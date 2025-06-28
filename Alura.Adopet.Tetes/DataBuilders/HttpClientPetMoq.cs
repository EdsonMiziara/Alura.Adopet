using Alura.Adopet.Console.Servicos;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Adopet.Testes.DataBuilders;

internal static class HttpClientPetMoq
{
    public static Mock<HttpClientPet> CriaMoq()
    {
        var httpClientPet = new Mock<HttpClientPet>(MockBehavior.Default,
                            It.IsAny<HttpClient>());
        return httpClientPet;
    }
}
