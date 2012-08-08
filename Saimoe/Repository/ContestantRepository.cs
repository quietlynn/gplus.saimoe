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
//using Omu.ValueInjecter;

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
        public Contestant GetContestant(string googlePlusId)
        {
            return _dbContext.Contestants.SingleOrDefault(c => c.GooglePlusId == googlePlusId);
        }

        /// <summary>
        /// Update profile of contestant
        /// </summary>
        /// <param name="profile"></param>
        public void UpdateProfile(Profile profile)
        {
            _dbContext.Profiles.Attach(_dbContext.Profiles.Single(p => p.Id == profile.Id));
            _dbContext.Profiles.ApplyCurrentValues(profile);

            _dbContext.SaveChanges();
        }

        internal void UpdateProfileByGoogleId(string googlePlusId, Profile profile)
        {
            var pid = _dbContext.Profiles.Single(c => c.Contestant.GooglePlusId == googlePlusId).Id;
            profile.Id = pid;
            _dbContext.Profiles.ApplyCurrentValues(profile);

            _dbContext.SaveChanges();
        }
    }
}