using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TogglAPI
{
    public class User
    {
        [JsonProperty(PropertyName="email")]
        public string email { get; set; }
        public string fullname { get; set; }
        public string image_url { get; set; }

        public List<Workspace> workspaces { get; set; }
        public List<Tag> tags { get; set; }
        public List<Project> projects { get; set; }
    }
}
