using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace f21sc_courswork_1.Utils
{
    class TimeHelper
    {
        /// <summary>
        /// This allows for easy and static access of the unix epoch time ; this is used to get the current timestamp.
        /// </summary>
        public static readonly DateTime Epoch = new DateTime(1970, 1, 1);

        /// <summary>
        /// Converts a <see cref="DateTime"/> to the corresponding unix timestamp
        /// </summary>
        /// <param name="dateTime"><see cref="DateTime"/> to convert</param>
        /// <returns>Timestamp in the form of a <see cref="Int32"/></returns>
        public static int DateTimeToTimestamp(DateTime dateTime)
        {
            TimeSpan timeBetween = dateTime.Subtract(Epoch);
            return (int)timeBetween.TotalSeconds;
        }
    }
}
