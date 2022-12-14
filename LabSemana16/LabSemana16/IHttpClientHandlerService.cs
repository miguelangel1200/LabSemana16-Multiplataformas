
using System.Net.Http;

namespace LabSemana16
{
    public interface IHttpClientHandlerService
    {
        HttpClientHandler GetInsecureHandler();
    }
}
