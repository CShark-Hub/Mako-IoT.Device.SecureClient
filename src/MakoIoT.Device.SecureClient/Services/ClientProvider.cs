using System;
using System.Net.Http;

namespace MakoIoT.Device.SecureClient.Services
{
    public class ClientProvider : IClientProvider
    {
        private readonly ICertificateProvider _certificateProvider;
        public ClientProvider(ICertificateProvider certificateProvider)
        {
            _certificateProvider = certificateProvider;
        }

        public HttpClient GetSecureHttpClient(string baseUrl)
        {
            return new HttpClient
            {
                BaseAddress = new Uri(baseUrl),
                HttpsAuthentCert = baseUrl.ToLower().StartsWith("https")
                    ? _certificateProvider.GetDefaultBundle()
                    : null
            };
        }
    }
}
