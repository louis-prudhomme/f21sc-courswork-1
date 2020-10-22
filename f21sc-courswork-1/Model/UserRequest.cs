using f21sc_courswork_1.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace f21sc_courswork_1.Model
{
    /// <summary>
    /// This class represents a user-issued HTTP request
    /// </summary>
    class UserRequest
    {
        public UserRequest(string targetUrl)
        {
            TargetUrl = targetUrl;
            IssuedAt = DateTime.Now;
        }

        /// <summary>
        /// URL the user wants to access
        /// </summary>
        public string TargetUrl { get; }
        /// <summary>
        /// Time at which the request was issued
        /// </summary>
        public DateTime IssuedAt { get; }

        public int TimestampIssuedAt { 
            get 
            {
                return TimeHelper.DateTimeToTimestamp(IssuedAt);
            }        
        }   
    }
}
