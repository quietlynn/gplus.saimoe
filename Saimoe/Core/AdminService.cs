using Saimoe.Repository;
/**
 * @author: Tsinghua <mytsingh@gmail.com>.
 * @description:
 * Manage all business relate to admin
 * 
 */
using System;

namespace Saimoe.Core
{
    public class AdministratorService
    {
        private AdministratorRepository _administratorRepository;

        public AdministratorService(AdministratorRepository administratorRepository = null)
        {
            _administratorRepository = administratorRepository ?? new AdministratorRepository();
        }

        /// <summary>
        /// Check if a id is an adminstrator id
        /// </summary>
        /// <param name="googlePlusId"></param>
        /// <returns>True if yes, else False</returns>
        public bool IsAdministratorId(string googlePlusId)
        {
            if (string.IsNullOrEmpty(googlePlusId))
            {
                throw new ArgumentNullException("google plus id");
            }

            return _administratorRepository.IsAdministratorId(googlePlusId);
        }
    }
}