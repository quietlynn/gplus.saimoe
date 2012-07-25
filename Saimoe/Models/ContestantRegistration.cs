using System;
using System.Collections.Generic;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;
using Saimoe.Resources;

namespace Saimoe.Models
{
    public class ContestantRegistration
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
        [Range(2011, 9999)]
        [Display(
            Name = "JoiningDateYear",
            ResourceType = typeof(WebResources)
        )]
        public int JoiningDateYear { get; set; }

        [Required]
        [Range(1, 12)]
        [Display(
            Name = "JoiningDateMonth",
            ResourceType = typeof(WebResources)
        )]
        public int JoiningDateMonth { get; set; }

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