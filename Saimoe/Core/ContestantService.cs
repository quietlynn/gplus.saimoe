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
        /// <summary>
        /// Add a contestant to database
        /// </summary>
        /// <param name="googlePlusId">Id of google plus</param>
        /// <param name="registrationInfo">Registration info of contestant</param>
        public void AddContestant(string googlePlusId, ContestantRegistration registrationInfo)
        {
            if (string.IsNullOrEmpty(googlePlusId))
            {
                throw new ArgumentNullException("GPlus Id");
            }

            if (registrationInfo == null)
            {
                throw new ArgumentNullException("Contestant Registration");
            }

            var repository = new ContestantRepository();
            var contestant = new Contestant
            {
                GooglePlusId = googlePlusId,
                CreatedDate = DateTime.Now,
                LastLoginDate = DateTime.Now,
                Profile = AutoMapper.Mapper.Map<ContestantRegistration, Profile>(registrationInfo)
            };


            repository.AddContestant(contestant);
        }

        /// <summary>
        /// Get contestant info by given google plus id
        /// </summary>
        /// <param name="gPlusId">google plus id</param>
        /// <returns>found contestant info or null</returns>
        public Contestant GetContestant(string googlePlusId)
        {
            if (string.IsNullOrEmpty(googlePlusId))
            {
                throw new ArgumentNullException("GPlus Id");
            }

            var repository = new ContestantRepository();
            return repository.GetContestant(googlePlusId);
        }
    }
}