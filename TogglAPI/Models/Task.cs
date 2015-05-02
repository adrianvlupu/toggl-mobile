using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TogglAPI.Models
{
    /// <summary>
    /// Tasks are available only for pro workspaces.
    /// </summary>
    public class Task
    {
        public int id { get; set; }
        /// <summary>
        /// The name of the task (string, required, unique in project)
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// project ID for the task (integer, required)
        /// </summary>
        public int pid { get; set; }
        /// <summary>
        /// workspace ID, where the task will be saved (integer, project's workspace id is used when not supplied)
        /// </summary>
        public int wid { get; set; }
        /// <summary>
        /// user ID, to whom the task is assigned to (integer, not required)
        /// </summary>
        public int uid { get; set; }
        /// <summary>
        /// estimated duration of task in seconds (integer, not required)
        /// </summary>
        public int estimated_seconds { get; set; }
        /// <summary>
        /// whether the task is done or not (boolean, by default true)
        /// </summary>
        public bool active { get; set; }
        /// <summary>
        /// timestamp that is sent in the response for PUT, indicates the time task was last updated
        /// </summary>
        public DateTime at { get; set; }
        /// <summary>
        /// total time tracked (in seconds) for the task
        /// </summary>
        public int tracked_seconds { get; set; }
    }
}
