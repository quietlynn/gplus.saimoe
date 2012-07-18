using System.ComponentModel.DataAnnotations;

namespace Saimoe.Models
{
    public class ContestantRegistration
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(
            Name = "Tagline",
            Description = "TaglineDescription",
            ResourceType = typeof(Resources.WebResources)
        )]
        public string Tagline { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(
            Name = "Interest",
            Description = "InterestDescription",
            ResourceType = typeof(Resources.WebResources)
        )]
        public string Interest { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(
            Name = "Characteristic",
            Description = "CharacteristicDescription",
            ResourceType = typeof(Resources.WebResources)
        )]
        public string Characteristic { get; set; }

        [Required]
        [DataType(DataType.Url)]
        [Display(
            Name = "RegistrationPost",
            Description = "RegistrationPostDescription",
            ResourceType = typeof(Resources.WebResources)
        )]
        public string RegistrationPost { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(
            Name = "ActingCute",
            Description = "ActingCuteDescription",
            ResourceType = typeof(Resources.WebResources)
        )]
        public string ActingCute { get; set; }
    }
}