using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TogglAPI.Models
{
    public class WorkspaceUser
    {
        /// <summary>
        /// workspace user id (integer)
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// user id of the workspace user (integer)
        /// </summary>
        public int uid { get; set; }
        public int wid { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        /// <summary>
        /// if user is workspace admin (boolean)
        /// </summary>
        public bool admin { get; set; }
        /// <summary>
        /// if the workspace user has accepted the invitation to this workspace (boolean)
        /// </summary>
        public bool active { get; set; }
        /// <summary>
        /// if user has not accepted the invitation the url for accepting his/her invitation is sent when the request is made by workspace_admin
        /// </summary>
        public string invite_url { get; set; }
        public DateTime at { get; set; }
    }
}
