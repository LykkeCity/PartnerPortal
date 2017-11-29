namespace LykkePartnerPortal.Helpers
{
    public class FileHelper
    {
        public static string Load(string emailsTemplatesFolder, string template)
        {
            string relativeTemplatePath = emailsTemplatesFolder + template;
            var file = System.IO.Path.Combine(relativeTemplatePath);
            return System.IO.File.ReadAllText(file);
        }
    }
}
