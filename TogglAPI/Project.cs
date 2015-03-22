using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TogglAPI
{
    public class Project
    {
        public int id { get; set; }
        public int wid { get; set; }
        public int cid { get; set; }
        public string name { get; set; }
        public bool billable { get; set; }
        public bool is_private { get; set; }
        public bool active { get; set; }
        public DateTime at { get; set; }
    }
}
