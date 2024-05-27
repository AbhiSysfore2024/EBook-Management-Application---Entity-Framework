namespace AppSettings
{
    public class ConnectionString
    {
        public string SQLServerManagementStudio { get; set; }
    }

    public class JWTClaimDetails
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Key { get; set; }
    }
}