using LykkePartnerPortal.Models.NewsLetters;

namespace LykkePartnerPortal.Models.EmailTemplates
{
    public class NewsletterTemplateModel : IEmailTemplate
    {
        public string Email { get; set; }
        public string Source { get; set; }

        public static NewsletterTemplateModel Create(NewsLetterRequestModel model)
        {
            return new NewsletterTemplateModel()
            {
                Email = model.Email,
                Source = model.Source
            };
        }
    }
}
