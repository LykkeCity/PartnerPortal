using System.ComponentModel.DataAnnotations;

namespace Core.Enumerations
{
    public enum SupportedRegulations
    {
        [Display(Name = "switzerland")]
        Switzerland = 0,

        [Display(Name = "europe")]
        Europe = 1,

        [Display(Name = "usa")]
        USA = 2
    }
}
