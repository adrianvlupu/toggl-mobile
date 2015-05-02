using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TogglAPI.Models
{
    public class Client
    {
        public int id { get; set; }
        /// <summary>
        /// The name of the client (string, required, unique in workspace)
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// workspace ID, where the client will be used (integer, required)
        /// </summary>
        public int wid { get; set; }
        /// <summary>
        /// Notes for the client (string, not required)
        /// </summary>
        public string notes { get; set; }
        /// <summary>
        /// The hourly rate for this client (float, not required, available only for pro workspaces)
        /// </summary>
        public float hrate { get; set; }
        /// <summary>
        /// The name of the client's currency (string, not required, available only for pro workspaces)
        /// </summary>
        public string cur { get; set; }
        /// <summary>
        /// timestamp that is sent in the response, indicates the time client was last updated
        /// </summary>
        public DateTime at { get; set; }
    }
}
