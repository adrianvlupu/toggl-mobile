using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TogglAPI.Models
{
    /// <summary>
    /// The requests are scoped with the user whose API token is used. Only his/her time entries are updated, retrieved and created.
    /// </summary>
    public class TimeEntry
    {
        public int id { get; set; }
        /// <summary>
        /// (string, strongly suggested to be used)
        /// </summary>
        public string description { get; set; }
        /// <summary>
        ///  workspace ID (integer, required if pid or tid not supplied)
        /// </summary>
        public int wid { get; set; }
        /// <summary>
        /// project ID (integer, not required)
        /// </summary>
        public int pid { get; set; }
        /// <summary>
        /// task ID (integer, not required)
        /// </summary>
        public int tid { get; set; }
        /// <summary>
        /// (boolean, not required, default false, available for pro workspaces)
        /// </summary>
        public bool billable { get; set; }
        /// <summary>
        /// time entry start time (string, required, ISO 8601 date and time)
        /// </summary>
        public DateTime start { get; set; }
        /// <summary>
        /// time entry stop time (string, not required, ISO 8601 date and time)
        /// </summary>
        public DateTime stop { get; set; }
        /// <summary>
        /// time entry duration in seconds. If the time entry is currently running, the duration attribute contains a negative value, denoting the start of the time entry in seconds since epoch (Jan 1 1970). The correct duration can be calculated as current_time + duration, where current_time is the current time in seconds since epoch. (integer, required)
        /// </summary>
        public long duration { get; set; }
        /// <summary>
        /// the name of your client app (string, required)
        /// </summary>
        public string created_with { get; set; }
        /// <summary>
        /// a list of tag names (array of strings, not required)
        /// </summary>
        public List<string> tags { get; set; }
        /// <summary>
        /// should Toggl show the start and stop time of this time entry? (boolean, not required)
        /// </summary>
        public bool duronly { get; set; }
        /// <summary>
        /// timestamp that is sent in the response, indicates the time item was last updated
        /// </summary>
        public DateTime at { get; set; }
    }
}
