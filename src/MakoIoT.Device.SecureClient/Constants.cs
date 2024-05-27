namespace MakoIoT.Device.SecureClient
{
    public static class Constants
    {
        public static string CertificateFile = "secureclient-cert.pem";
        public static string GetCertificateFileName(string name) => $"secureclient-cert-{name}.pem";
    }
}
