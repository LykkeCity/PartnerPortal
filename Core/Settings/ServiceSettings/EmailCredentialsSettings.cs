namespace Core.Settings.ServiceSettings
{
    public class EmailCredentialsSettings
    {
        public string EmailAccount { get; set; }
        public string EmailPassword { get; set; }
        public bool UseDefaultCredentials { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public bool EnableSsl { get; set; }
        public string EmailTo { get; set; }

        public string ContactsPopUpTemplate { get; set; }
        public string NewsletterTemplate { get; set; }

        public string EmailsTemplatesFolder { get; set; }

        public string ContactsPopUpSubject { get; set; }
        public string NewsletterSubject { get; set; }

    }
}
