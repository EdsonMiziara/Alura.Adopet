using Moq;
using Moq.Protected;
using System.Net.Http;

namespace Alura.Adopet.Testes.Builder;

public class HttpClientMoqBuilder
{
    public static Mock<HttpClient> CriarMoq(string content)
    {
        var handlermock = new Mock<HttpMessageHandler>();
        var response = new HttpResponseMessage
        {
            StatusCode = System.Net.HttpStatusCode.OK,
            Content = new StringContent(content)
        };

        handlermock
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(response);

        var httpClient = new Mock<HttpClient>(MockBehavior.Default, handlermock.Object);
        httpClient.Object.BaseAddress = new Uri("http://localhost:5057");

        return httpClient;

    }
}
