using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TogglAPI
{
    public class Workspace
    {
        public int id { get; set; }
        public string name { get; set; }
        public bool premium { get; set; }
        public bool admin { get; set; }
        public string default_currency { get; set; }
        public bool only_admins_may_create_projects { get; set; }
        public bool only_admins_see_billable_rates { get; set; }
        public bool only_admins_see_team_dashboard { get; set; }
        public bool projects_billable_by_default { get; set; }
        public string logo_url { get; set; }
    }
}
