using System;
using System.Collections.Generic;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;

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
        [Range(2011, 9999)]
        [Display(
            Name = "JoiningDateYear",
            ResourceType = typeof(Resources.WebResources)
        )]
        public int JoiningDateYear { get; set; }

        [Required]
        [Range(1, 12)]
        [Display(
            Name = "JoiningDateMonth",
            ResourceType = typeof(Resources.WebResources)
        )]
        public int JoiningDateMonth { get; set; }

        [DataType(DataType.Url)]
        [Display(
            Name = "RegistrationPost",
            Description = "RegistrationPostDescription",
            ResourceType = typeof(Resources.WebResources)
        )]
        public string RegistrationPost { get; set; }

        [DataType(DataType.Text)]
        [Display(
            Name = "ActingCute",
            Description = "ActingCuteDescription",
            ResourceType = typeof(Resources.WebResources)
        )]
        public string ActingCute { get; set; }
    }
}