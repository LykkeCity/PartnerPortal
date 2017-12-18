using System.ComponentModel.DataAnnotations;

namespace Core.Enumerations
{
    public enum LykkeInformation
    {
        [Display(Name = "event")]
        Event = 0,

        [Display(Name = "other")]
        Other = 1,

        [Display(Name = "lykkeCom")]
        LykkeCom = 2,

        [Display(Name = "personalNetwork")]
        PersonalNetwork = 3
    }
}
