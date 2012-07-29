using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Saimoe.Models
{
    public partial class Contestant
    {
        public Contestant(string googlePlusId, Profile profile)
            : this()
        {
            GooglePlusId = googlePlusId;
            Profile = profile;
        }

        public Contestant()
        {
            // TODO: Complete member initialization
            CreatedDate = DateTime.Now;
            LastLoginDate = DateTime.Now;
        }
    }
}