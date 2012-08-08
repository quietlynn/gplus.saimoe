using Saimoe.Models;
using Saimoe.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Saimoe.Core
{
    public class VotingService
    {
        private VotingRepository _votingRepository;

        public VotingService(VotingRepository votingRepository = null)
        {
            _votingRepository = votingRepository ?? new VotingRepository();
        }

        public void AddVoting(Voting voting)
        {
            if (voting == null)
            {
                throw new ArgumentNullException("Voting");
            }

            _votingRepository.AddVoting(voting);
        }

        /// <summary>
        /// Get a voting info by its id
        /// </summary>
        /// <param name="id">Id of voting</param>
        /// <returns>Found voting or null</returns>
        public Voting GetVoting(int id)
        {
            return _votingRepository.GetVoting(id);
        }
        /// <summary>
        /// Find voting by name
        /// </summary>
        /// <param name="name">Keyword of name</param>
        /// <returns>All votings with name contains keyword</returns>
        public IEnumerable<Voting> FindVoting(string name)
        {
            return _votingRepository.FindVoting(name);
        }

    }
}