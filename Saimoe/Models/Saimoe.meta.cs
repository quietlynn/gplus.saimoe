using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Saimoe.Resources;

namespace Saimoe.Models
{
    [MetadataType(typeof(Profile.MetaData))]
    public partial class Profile
    {
        public class MetaData
        {
            [Required]
            [DataType(DataType.Text)]
            [Display(
                Name = "Tagline",
                Description = "TaglineDescription",
                ResourceType = typeof(WebResources)
            )]
            public string Tagline { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(
                Name = "Interest",
                Description = "InterestDescription",
                ResourceType = typeof(WebResources)
            )]
            public string Interest { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(
                Name = "Characteristic",
                Description = "CharacteristicDescription",
                ResourceType = typeof(WebResources)
            )]
            public string Characteristic { get; set; }

            [Required]
            [DataType(DataType.Date)]
            [Display(
                Name = "JoiningDate",
                Description = "JoiningDateDescription",
                ResourceType = typeof(WebResources)
            )]
            public DateTime JoinedDate { get; set; }

            [DataType(DataType.Url)]
            [Display(
                Name = "RegistrationPost",
                Description = "RegistrationPostDescription",
                ResourceType = typeof(WebResources)
            )]
            public string RegistrationPost { get; set; }

            [DataType(DataType.Text)]
            [Display(
                Name = "ActingCute",
                Description = "ActingCuteDescription",
                ResourceType = typeof(WebResources)
            )]
            public string ActingCute { get; set; }
        }
    }

}