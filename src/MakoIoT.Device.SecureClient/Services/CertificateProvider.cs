using System;
using System.Security.Cryptography.X509Certificates;
using MakoIoT.Device.Services.Interface;

namespace MakoIoT.Device.SecureClient.Services
{
    public class CertificateProvider : ICertificateProvider
    {
        private readonly ILog _log;
        private readonly IStorageService _storageService;

        public CertificateProvider(IStorageService storageService, ILog log)
        {
            _storageService = storageService;
            _log = log;
        }

        public X509Certificate GetCertificate(string name)
        {
            if (_storageService.FileExists(Constants.GetCertificateFileName(name)))
            {
                try
                {
                    _log.Trace($"Reading certificate from file {Constants.GetCertificateFileName(name)}");
                    var cs = _storageService.ReadFile(Constants.GetCertificateFileName(name));
                    _log.Trace($"Certificate string length: {cs.Length}");
                    return new X509Certificate(cs);
                }
                catch (Exception e)
                {
                    _log.Error(e);
                }
            }

            return null;
        }
    }
}
