using Saimoe.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Saimoe.Infra
{
    public static class ContestantCsvHelper
    {
        /// <summary>
        /// Write contestants to a csv stream
        /// </summary>
        /// <param name="contestants"></param>
        /// <returns>CSV content</returns>
        public static Byte[] WriteAsCsv(IEnumerable<Contestant> contestants)
        {
            var content = string.Join("\n"/*breaking line*/, contestants.Select(c => string.Join(",", c.GooglePlusId,
                                                                                     c.Profile.Interest,
                                                                                     c.Profile.Characteristic,
                                                                                     c.Profile.ActingCute,
                                                                                     c.Profile.RegistrationPost,
                                                                                     c.Profile.Tagline,
                                                                                     c.Profile.JoinedDate.Year,
                                                                                     c.Profile.JoinedDate.Month)));
            var encoding = new UTF8Encoding();
            return encoding.GetBytes(content);
        }

        /// <summary>
        /// Read google plus id from input stream
        /// </summary>
        /// <param name="inputStream"></param>
        /// <returns>id strings</returns>
        public static IEnumerable<string> ReadIds(this Stream inputStream)
        {
            using (var reader = new StreamReader(inputStream))
            {
                var content = reader.ReadToEnd();
                return content.Split('\n').ToList();
            } 
        }
    }
}