namespace Core.Settings.ServiceSettings
{
    public class LykkePartnerPortalSettings
    {
        public EmailCredentialsSettings EmailCredentials { get; set; }
        public DbSettings Db { get; set; }
        public ProductsInformationSettings ProductsInformation { get; set; }
        public AuthenticationSettings Authentication { get; set; }
        public ServiceSettings Services { get; set; }
    }
}
