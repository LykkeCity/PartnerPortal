namespace LykkePartnerPortal.Helpers
{
    public class FileHelper
    {
        public static string Load(string emailsTemplatesFolder, string template)
        {
            var file = System.IO.Path.Combine(emailsTemplatesFolder, template);
            return System.IO.File.ReadAllText(file);
        }
    }
}
