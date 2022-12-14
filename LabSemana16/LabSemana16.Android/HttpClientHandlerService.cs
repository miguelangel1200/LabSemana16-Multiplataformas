using System.Net.Http;
using LabSemana16.Droid;
using Xamarin.Forms;
[assembly: Dependency(typeof(HttpClientHandlerService))]
namespace LabSemana16.Droid
{
    public class HttpClientHandlerService : IHttpClientHandlerService
    {
        public HttpClientHandler GetInsecureHandler()
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback =
                (message, cert, chain, errors) =>
                {
                    if (cert.Issuer.Equals("CN=localhost"))
                        return true;
                    return errors == System.Net.Security.SslPolicyErrors.None;
                };
            return handler;
        }
    }
}