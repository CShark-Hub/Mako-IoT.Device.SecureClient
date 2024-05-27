using System.Security.Cryptography.X509Certificates;

namespace MakoIoT.Device.SecureClient.Services
{
    public interface ICertificateProvider
    {
        X509Certificate GetCertificate(string name);
    }
}