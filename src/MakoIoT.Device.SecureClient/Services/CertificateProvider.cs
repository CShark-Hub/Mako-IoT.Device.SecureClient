using System;
using System.Security.Cryptography.X509Certificates;
using MakoIoT.Device.SecureClient.Exceptions;
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
            return GetCertificateInternal(Constants.GetCertificateFileName(name));
        }

        public X509Certificate GetDefaultBundle()
        {
            return GetCertificateInternal(Constants.CertificateFile);
        }

        private X509Certificate GetCertificateInternal(string filename)
        {
            if (!_storageService.FileExists(filename))
                throw new SecureClientException($"Certificate file {filename} not found on the device");

            try
            {
                _log.Trace($"Reading certificate from file {filename}");
                var cs = _storageService.ReadFile(filename);
                _log.Trace($"Certificate string length: {cs.Length}");
                return new X509Certificate(cs);
            }
            catch (Exception e)
            {
                throw new SecureClientException("Error loading certificate", e);
            }
        }
    }
}
