using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TogglAPI.Models
{
    public class Project
    {
        public int id { get; set; }
        /// <summary>
        /// The name of the project (string, required, unique for client and workspace)
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// workspace ID, where the project will be saved (integer, required)
        /// </summary>
        public int wid { get; set; }
        /// <summary>
        /// client ID (integer, not required)
        /// </summary>
        public int cid { get; set; }
        /// <summary>
        /// whether the project is archived or not (boolean, by default true)
        /// </summary>
        public bool active { get; set; }
        /// <summary>
        /// whether project is accessible for only project users or for all workspace users (boolean, default true)
        /// </summary>
        public bool is_private { get; set; }
        /// <summary>
        /// whether the project can be used as a template (boolean, not required)
        /// </summary>
        public bool template { get; set; }
        /// <summary>
        /// id of the template project used on current project's creation
        /// </summary>
        public int templace_id { get; set; }
        /// <summary>
        /// whether the project is billable or not (boolean, default true, available only for pro workspaces)
        /// </summary>
        public bool billable { get; set; }
        /// <summary>
        /// whether the estimated hours is calculated based on task estimations or is fixed manually (boolean, default false, not required, premium functionality)
        /// </summary>
        public bool auto_estimates { get; set; }
        /// <summary>
        /// if auto_estimates is true then the sum of task estimations is returned, otherwise user inserted hours (integer, not required, premium functionality)
        /// </summary>
        public int estimated_hours { get; set; }
        /// <summary>
        /// timestamp that is sent in the response for PUT, indicates the time task was last updated (read-only)
        /// </summary>
        public DateTime at { get; set; }
        /// <summary>
        /// id of the color selected for the project
        /// </summary>
        public int color { get; set; }

        /// <summary>
        /// hourly rate of the project (float, not required, premium functionality)
        /// </summary>
        public float rate { get; set; }
        /// <summary>
        /// timestamp indicating when the project was created (UTC time), read-only
        /// </summary>
        public DateTime created_at { get; set; }
    }
}
