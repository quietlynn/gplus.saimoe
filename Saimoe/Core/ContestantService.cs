/**
 * @file: Core/ContestantService.cs
 * @author: Tsinghua <mytsingh@gmail.com>.
 * @description:
 * Manage all business relate to contestant
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Saimoe.Models;
using Saimoe.Models.EF;
using Saimoe.Repository;

namespace Saimoe.Core
{
    /// <summary>
    ///  @author: Tsinghua <mytsingh@gmail.com>.
    ///  @description:
    ///  Manage all business relate to contestant
    /// </summary>
    public class ContestantService
    {
        private ContestantRepository _contestantRepository;

        public ContestantService(ContestantRepository contestantRepository = null)
        {
            _contestantRepository = contestantRepository ?? new ContestantRepository();
        }

        /// <summary>
        /// Add a contestant to database
        /// </summary>
        /// <param name="googlePlusId">Id of google plus</param>
        /// <param name="registrationInfo">Registration info of contestant</param>
        public void AddContestant(Contestant contestant)
        {
            if (contestant == null)
            {
                throw new ArgumentNullException("Contestant Registration");
            }

            _contestantRepository.AddContestant(contestant);
        }

        /// <summary>
        /// Get contestant registration info by given google plus id
        /// </summary>
        /// <param name="gPlusId">google plus id</param>
        /// <returns>found contestant registration info or null</returns>
        public Contestant GetContestant(string googlePlusId)
        {
            if (string.IsNullOrEmpty(googlePlusId))
            {
                throw new ArgumentNullException("GPlus Id");
            }

            return _contestantRepository.GetContestant(googlePlusId);
        }

        /// <summary>
        /// Update profile of contestant
        /// </summary>
        /// <param name="profile"></param>
        public void UpdateContestantProfile(Profile profile)
        {
            if (profile == null)
            {
                throw new ArgumentNullException("contestant");
            }

            _contestantRepository.UpdateProfile(profile);
        }

    }
}