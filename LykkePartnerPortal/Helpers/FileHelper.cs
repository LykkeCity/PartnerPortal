using Microsoft.AspNetCore.Hosting;

namespace LykkePartnerPortal.Helpers
{
    public class FileHelper
    {
        public static string Load(IHostingEnvironment env, string path, string template)
        {
            var webRootInfo = string.Format("{0}{1}", env.WebRootPath, path);
            var file = System.IO.Path.Combine(webRootInfo, template);
            return System.IO.File.ReadAllText(file);
        }
    }
}
