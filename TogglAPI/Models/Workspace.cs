using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TogglAPI.Models
{
    public class Workspace
    {
        public int id { get; set; }
        /// <summary>
        /// the name of the workspace (string)
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// If it's a pro workspace or not. Shows if someone is paying for the workspace or not (boolean)
        /// </summary>
        public bool premium { get; set; }
        /// <summary>
        /// shows whether currently requesting user has admin access to the workspace (boolean)
        /// </summary>
        public bool admin { get; set; }
        /// <summary>
        /// default hourly rate for workspace, won't be shown to non-admins if the only_admins_see_billable_rates flag is set to true (float)
        /// </summary>
        public int default_hourly_rate { get; set; }
        /// <summary>
        /// default currency for workspace (string)
        /// </summary>
        public string default_currency { get; set; }
        /// <summary>
        /// whether only the admins can create projects or everybody (boolean)
        /// </summary>
        public bool only_admins_may_create_projects { get; set; }
        /// <summary>
        /// whether only the admins can see billable rates or everybody (boolean)
        /// </summary>
        public bool only_admins_see_billable_rates { get; set; }
        /// <summary>
        /// type of rounding (integer)
        /// </summary>
        public int rounding { get; set; }
        /// <summary>
        /// round up to nearest minute (integer)
        /// </summary>
        public int rounding_minutes { get; set; }
        /// <summary>
        /// timestamp that indicates the time workspace was last updated
        /// </summary>
        public DateTime at { get; set; }
        /// <summary>
        /// URL pointing to the logo (if set, otherwise omited) (string)
        /// </summary>
        public string logo_url { get; set; }
    }
}
