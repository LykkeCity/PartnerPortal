using System.ComponentModel.DataAnnotations;

namespace Core.Enumerations
{
    public enum Salutations
    {
        [Display(Name = "dr")]
        Dr = 0,

        [Display(Name = "mr")]
        Mr = 1,

        [Display(Name = "mrs")]
        Mrs = 2,

        [Display(Name = "ms")]
        Ms = 3
    }
}
