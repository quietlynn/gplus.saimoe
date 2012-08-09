using Saimoe.Models;
using System.Collections;
using System.Collections.Generic;
/**
 * @author: Tsinghua <mytsingh@gmail.com>.
 * @description:
 * The Contest repository for CRUD
 * 
 */
using System.Linq;

namespace Saimoe.Repository
{
    public class ContestRepository
    {
        SaimoeContext _dbContext;

        #region Constructor
        /// <summary>
        /// Initialize a repository with given connection string.
        /// </summary>
        /// <param name="connectionString">connection string</param>
        public ContestRepository(string connectionString)
        {
            _dbContext = new SaimoeContext(connectionString);
        }

        /// <summary>
        /// Initialize a repository with default connection string found in the 'SaimoeContext' section of the application configuration file.
        /// </summary>
        public ContestRepository()
        {
            _dbContext = new SaimoeContext();
        }
        #endregion

        /// <summary>
        /// Add a new Contest
        /// </summary>
        /// <param name="Contest">new Contest</param>
        public void AddContest(Contest Contest)
        {
            _dbContext.Contests.AddObject(Contest);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Get a Contest by its id
        /// </summary>
        /// <param name="id">Id of Contest</param>
        /// <returns>Found Contest or null</returns>
        public Contest GetContest(int id)
        {
            return _dbContext.Contests.SingleOrDefault(v => v.Id == id);
        }

        /// <summary>
        /// Find Contest by name
        /// </summary>
        /// <param name="name">Keyword of name</param>
        /// <returns>All Contests with name contains keyword</returns>
        public IEnumerable<Contest> FindContest(string name)
        {
            return _dbContext.Contests.Where(v => v.Name.Contains(name)).ToList();
        }


        public void AddGrouping(Grouping grouping)
        { 
            
        }
    }
}