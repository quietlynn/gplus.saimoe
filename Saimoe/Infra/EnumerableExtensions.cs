using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Saimoe.Infra
{
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Random grouping contestants
        /// </summary>
        /// <param name="contestants">contestants to be grouped</param>
        /// <param name="groupQuantity">the quantity of group</param>
        /// <returns>Grouped contestants</returns>
        public static IEnumerable<IEnumerable<T>> RandomGrouping<T>(this IEnumerable<T> contestants, int groupQuantity)
        {
            var random = new Random();
            //Random sort the list
            contestants = contestants.OrderBy(c => random.Next());

            var groupedContestants = new List<List<T>>();
            for (var i = 0; i < groupQuantity; i++)
            {
                groupedContestants.Add(new List<T>());
            }

            for (var i = 0; i < contestants.Count(); i++)
            {
                groupedContestants[i % groupQuantity].Add(contestants.ElementAt(i));
            }

            return groupedContestants;
        }
    }
}