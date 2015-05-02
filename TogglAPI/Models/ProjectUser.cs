using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TogglAPI.Models
{
    class ProjectUser
    {
        public int id { get; set; }
        /// <summary>
        /// project ID (integer, required)
        /// </summary>
        public int pid { get; set; }
        /// <summary>
        /// user ID, who is added to the project (integer, required)
        /// </summary>
        public int uid { get; set; }
        /// <summary>
        /// workspace ID, where the project belongs to (integer, not-required, project's workspace id is used)
        /// </summary>
        public int wid { get; set; }
        /// <summary>
        /// admin rights for this project (boolean, default false)
        /// </summary>
        public bool manager { get; set; }
        /// <summary>
        /// hourly rate for the project user (float, not-required, only for pro workspaces) in the currency of the project's client or in workspace default currency
        /// </summary>
        public float rate { get; set; }
        /// <summary>
        /// timestamp that is sent in the response, indicates when the project user was last updated
        /// </summary>
        public DateTime at { get; set; }
    }
}
