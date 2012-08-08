/**
 * @author: Tsinghua <mytsingh@gmail.com>.
 * @description:
 * The administrator repository for CRUD
 * 
 */
using System.Linq;
using Saimoe.Models;

namespace Saimoe.Repository
{
    public class AdministratorRepository
    {
        SaimoeContext _dbContext;

        #region Constructor
        /// <summary>
        /// Initialize a repository with given connection string.
        /// </summary>
        /// <param name="connectionString">connection string</param>
        public AdministratorRepository(string connectionString)
        {
            _dbContext = new SaimoeContext(connectionString);
        }

        /// <summary>
        /// Initialize a repository with default connection string found in the 'SaimoeContext' section of the application configuration file.
        /// </summary>
        public AdministratorRepository()
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
    }
}