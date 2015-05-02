using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TogglAPI.Models
{
    public class User
    {
        public class BlogPost
        {
            public string title { get; set; }
            public string url { get; set; }
        }

        public int id { get; set; }
        public string fullname { get; set; }
        public string api_token { get; set; }
        /// <summary>
        /// default workspace id (integer)
        /// </summary>
        public int default_wid { get; set; }
        [JsonProperty(PropertyName="email")]
        public string email { get; set; }
        public string jquery_timeofday_format { get; set; }
        public string jquery_date_format { get; set; }
        public string timeofday_format { get; set; }
        public string date_format { get; set; }
        /// <summary>
        /// whether start and stop time are saved on time entry (boolean)
        /// </summary>
        public bool store_start_and_stop_time { get; set; }
        /// <summary>
        /// (integer 0-6, Sunday=0)
        /// </summary>
        public int beginning_of_week { get; set; }
        /// <summary>
        /// user's language (string)
        /// </summary>
        public string language { get; set; }
        /// <summary>
        /// url with the user's profile picture(string)
        /// </summary>
        public string image_url { get; set; }
        /// <summary>
        /// should a piechart be shown on the sidebar (boolean)
        /// </summary>
        public bool sidebar_piechart { get; set; }
        /// <summary>
        /// timestamp of last changes
        /// </summary>
        public DateTime at { get; set; }
        /// <summary>
        /// an object with toggl blog post title and link
        /// </summary>
        public BlogPost new_blog_post { get; set; }
        /// <summary>
        /// (boolean) Toggl can send newsletters over e-mail to the user
        /// </summary>
        public bool send_product_emails { get; set; }
        /// <summary>
        /// (boolean) if user receives weekly report
        /// </summary>
        public bool send_weekly_report { get; set; }
        /// <summary>
        /// (boolean) email user about long-running (more than 8 hours) tasks
        /// </summary>
        public bool send_timer_notifications { get; set; }
        /// <summary>
        /// (boolean) google signin enabled
        /// </summary>
        public bool openid_enabled { get; set;}
        /// <summary>
        /// (string) timezone user has set on the "My profile" page ( IANA TZ timezones )
        /// </summary>
        public string timezone { get; set; }

        public List<TimeEntry> time_entries { get; set; }
        public List<Project> projects { get; set; }
        public List<Tag> tags { get; set; }
        public List<Workspace> workspaces { get; set; }
        public List<Client> clients { get; set; }

        //public string current_password { get; set; }
        //public string password { get; set; }
    }
}
