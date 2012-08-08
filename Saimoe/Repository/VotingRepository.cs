using Saimoe.Models;
using System.Collections;
using System.Collections.Generic;
/**
 * @author: Tsinghua <mytsingh@gmail.com>.
 * @description:
 * The voting repository for CRUD
 * 
 */
using System.Linq;

namespace Saimoe.Repository
{
    public class VotingRepository
    {
        SaimoeContext _dbContext;

        #region Constructor
        /// <summary>
        /// Initialize a repository with given connection string.
        /// </summary>
        /// <param name="connectionString">connection string</param>
        public VotingRepository(string connectionString)
        {
            _dbContext = new SaimoeContext(connectionString);
        }

        /// <summary>
        /// Initialize a repository with default connection string found in the 'SaimoeContext' section of the application configuration file.
        /// </summary>
        public VotingRepository()
        {
            _dbContext = new SaimoeContext();
        }
        #endregion

        /// <summary>
        /// Check if a google plus id is a adminstrator id
        /// </summary>
        /// <param name="googlePlusId">Id of google plus</param>
        /// <returns>True if is an administrator id, else False</returns>
        public bool IsAdministratorId(string googlePlusId)
        {
            return _dbContext.Administrators.Any(a => a.GooglePlusId == googlePlusId);
        }

        /// <summary>
        /// Add a new voting
        /// </summary>
        /// <param name="voting">new voting</param>
        public void AddVoting(Voting voting)
        {
            _dbContext.Votings.AddObject(voting);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Get a voting by its id
        /// </summary>
        /// <param name="id">Id of voting</param>
        /// <returns>Found voting or null</returns>
        public Voting GetVoting(int id)
        {
            return _dbContext.Votings.SingleOrDefault(v => v.Id == id);
        }

        /// <summary>
        /// Find voting by name
        /// </summary>
        /// <param name="name">Keyword of name</param>
        /// <returns>All votings with name contains keyword</returns>
        public IEnumerable<Voting> FindVoting(string name)
        {
            return _dbContext.Votings.Where(v => v.Name.Contains(name)).ToList();
        }

    }
}