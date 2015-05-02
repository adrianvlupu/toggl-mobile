using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TogglAPI.Models
{
    public class Tag
    {
        public int id { get; set; }
        /// <summary>
        /// workspace ID, where the tag will be used (integer, required)
        /// </summary>
        public int wid { get; set; }
        /// <summary>
        /// The name of the tag (string, required, unique in workspace)
        /// </summary>
        public string name { get; set; }
    }
}
