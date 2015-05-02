using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TogglAPI.Models
{
    /// <summary>
    /// Dashboard's main purpose is to give an overview of what users in the workspace are doing and have been doing. 
    /// </summary>
    public class Dashboard
    {
        /// <summary>
        /// The most active user object holds the data of the top 5 users who have tracked the most time during last 7 days. Most active user object has the following properties
        /// </summary>
        public class MostActiveUser
        {
            public int user_id { get; set; }
            /// <summary>
            /// project ID (ID is 0 if time entry doesn'y have project connected to it)
            /// </summary>
            public int project_id { get; set; }
            /// <summary>
            /// time entry duration in seconds. If the time entry is currently running, the duration attribute contains a negative value, denoting the start of the time entry in seconds since epoch (Jan 1 1970). The correct duration can be calculated as current_time + duration, where current_time is the current time in seconds since epoch.
            /// </summary>
            public int duration { get; set; }
            /// <summary>
            /// (Description property is not present if time entry description is empty)
            /// </summary>
            public string description { get; set; }
            /// <summary>
            /// time entry stop time (ISO 8601 date and time. Stop property is not present when time entry is still running)
            /// </summary>
            public DateTime stop { get; set; }
            /// <summary>
            /// task id, if applicable
            /// </summary>
            public int tid { get; set; }
        }
        /// <summary>
        /// The activity object holds the data of 10 latest actions in the workspace. Activity object has the following properties
        /// </summary>
        public class Activity
        {
            public int user_id { get; set; }
            /// <summary>
            /// Sum of time entry durations that have been created during last 7 days
            /// </summary>
            public int duration { get; set; }
        }

        /// <summary>
        /// The activity object holds the data of 10 latest actions in the workspace. Activity object has the following properties
        /// </summary>
        public List<Activity> activity { get; set; }
        /// <summary>
        /// The most active user object holds the data of the top 5 users who have tracked the most time during last 7 days. Most active user object has the following properties
        /// </summary>
        public List<MostActiveUser> most_active_user { get; set; }
    }
}
