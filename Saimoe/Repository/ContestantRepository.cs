/**
 * @file: Repository/ContestantRepository.cs
 * @author: Tsinghua <mytsingh@gmail.com>.
 * @description:
 * The contestant repository for CRUD contestants
 * 
 */
using System.Linq;
using Saimoe.Models;
using System;

namespace Saimoe.Repository
{
    public class ContestantRepository
    {
        SaimoeContext _dbContext;

        #region Constructor
        /// <summary>
        /// Initialize a repository with given connection string.
        /// </summary>
        /// <param name="connectionString">connection string</param>
        public ContestantRepository(string connectionString)
        {
            _dbContext = new SaimoeContext(connectionString);
        }

        /// <summary>
        /// Initialize a repository with default connection string found in the 'SaimoeContext' section of the application configuration file.
        /// </summary>
        public ContestantRepository()
        {
            _dbContext = new SaimoeContext();
        }
        #endregion

        /// <summary>
        /// Add a new contestant
        /// </summary>
        /// <param name="contestant">the new contestant</param>
        internal void AddContestant(Contestant contestant)
        {
            _dbContext.Contestants.AddObject(contestant);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Get contestant info by google plus id
        /// </summary>
        /// <param name="googlePlusId">google plus id</param>
        /// <returns>found contestant or null</returns>
        internal Contestant GetContestant(string googlePlusId)
        {
            return _dbContext.Contestants.SingleOrDefault(c => c.GooglePlusId == googlePlusId);
        }

        /// <summary>
        /// Update profile of contestant
        /// </summary>
        /// <param name="profile"></param>
        /// <remarks>Meet problems while using Attach, will be improve later</remarks>
        internal void UpdateProfile(Profile profile)
        {
            var dbProfile = _dbContext.Profiles.SingleOrDefault(p => p.Id == profile.Id);
            if (dbProfile == null)
            {
                throw new InvalidOperationException("The profile doesn't exist.");
            }

            #region TODO: Improve these ugly codes later
            dbProfile.Tagline = profile.Tagline;
            dbProfile.Interest = profile.Interest;
            dbProfile.Characteristic = profile.Characteristic;
            dbProfile.RegistrationPost = profile.RegistrationPost;
            dbProfile.ActingCute = profile.ActingCute;
            dbProfile.JoinedDate = profile.JoinedDate;
            #endregion

            _dbContext.SaveChanges();
        }
    }
}