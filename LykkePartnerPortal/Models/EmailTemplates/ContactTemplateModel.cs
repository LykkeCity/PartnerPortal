using LykkePartnerPortal.Models.Contacts;

namespace LykkePartnerPortal.Models.EmailTemplates
{
    public class ContactTemplateModel : IEmailTemplate
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Source { get; set; }
        public string PhoneNumber { get; set; }
        public string Message { get; set; }

        public static ContactTemplateModel Create(ContactRequestModel model)
        {
            return new ContactTemplateModel()
            {
                Email = model.Email,
                Source = model.Source,
                FullName = model.FullName,
                Message = model.Message,
                PhoneNumber = model.PhoneNumber
            };
        }
    }
}