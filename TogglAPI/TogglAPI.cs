using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TogglAPI
{
    public class TogglAPI
    {
        private const string APIEndpoint = "https://www.toggl.com/api/v8";
        public string access_token { get; private set; }
        private string Username { get; set; }
        private string Password { get; set; }

        private enum HttpVerb
        {
            GET,
            POST,
            PUT,
            DELETE
        }

        private async Task<string> RequestAsync(string path, HttpVerb verb = HttpVerb.GET, string body = null)
        {
            if (String.IsNullOrEmpty(access_token))
                throw new Exception("No token available. Call Authenticate first.");

            string response = null;

            switch (verb)
            {
                case HttpVerb.GET:
                    response = await HttpUtils.HttpGetAsync(APIEndpoint + path, new Dictionary<string, string>() { 
                            {"Authorization","Basic "+HttpUtils.base64Encode(access_token+":api_token")}
                        });
                    break;
                case HttpVerb.POST:
                    response = await HttpUtils.HttpPostAsync(APIEndpoint + path, body, new Dictionary<string, string>() { 
                            {"Authorization","Basic "+HttpUtils.base64Encode(access_token+":api_token")}
                        });
                    break;
                case HttpVerb.PUT:
                    response = await HttpUtils.HttpPutAsync(APIEndpoint + path, body, new Dictionary<string, string>() { 
                            {"Authorization","Basic "+HttpUtils.base64Encode(access_token+":api_token")}
                        });
                    break;
                case HttpVerb.DELETE:
                    await HttpUtils.HttpDeleteAsync(APIEndpoint + path, new Dictionary<string, string>() { 
                            {"Authorization","Basic "+HttpUtils.base64Encode(access_token+":api_token")}
                        });
                    response = "";
                    break;
            }
            return response;

        }

        public async Task<bool> AuthenticateAsync(string username, string password)
        {
            this.Username = username;
            this.Password = password;

            try
            {
                var response = await HttpUtils.HttpGetAsync("https://www.toggl.com/api/v8/me", new Dictionary<string, string>() { 
                    {"Authorization","Basic "+HttpUtils.base64Encode(username+":"+password)} 
                });
                access_token = JObject.Parse(response)["data"]["api_token"].ToString();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<User> GetMeAsync()
        {
            var data = JObject.Parse(await RequestAsync("/me?with_related_data=true"))["data"].ToString();
            return JsonConvert.DeserializeObject<User>(data);
        }

        public async Task<List<Workspace>> GetWorkspacesAsync()
        {
            var data = JsonConvert.DeserializeObject<List<Workspace>>(await RequestAsync("/workspaces"));
            return data;
        }
        public async Task<List<Project>> GetProjectsAsync(int WorkspaceID)
        {
            var data = JsonConvert.DeserializeObject<List<Project>>(await RequestAsync("/workspaces/" + WorkspaceID + "/projects"));
            return data;
        }
        public async Task<List<Tag>> GetTagsAsync(int WorkspaceID)
        {
            var data = JsonConvert.DeserializeObject<List<Tag>>(await RequestAsync("/workspaces/" + WorkspaceID + "/tags"));
            return data;
        }

        public async Task<TimeEntry> CreateTimeEntryAsync(string description, string[] tags, double duration, DateTime start, DateTime? stop, int? wid, int? pid, bool billable, string created_with)
        {
            string body = JsonConvert.SerializeObject(new
            {
                time_entry = new
                {
                    description = description,
                    tags = tags,
                    duration = duration,
                    start = start.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ"),
                    stop = stop == null ? null : ((DateTime)stop).ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ"),
                    pid = pid,
                    wid = wid,
                    billable = billable,
                    created_with = created_with
                }
            }, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            var data = JObject.Parse(await RequestAsync("/time_entries", HttpVerb.POST, body))["data"].ToString();
            return JsonConvert.DeserializeObject<TimeEntry>(data);
        }
        public async Task<TimeEntry> StartTimeEntryAsync(string description, string[] tags, int? wid, int? pid, bool billable, string created_with)
        {
            string body = JsonConvert.SerializeObject(new
            {
                time_entry = new
                {
                    description = description,
                    tags = tags,
                    pid = pid,
                    wid = wid,
                    billable = billable,
                    created_with = created_with
                }
            }, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            var data = JObject.Parse(await RequestAsync("/time_entries/start", HttpVerb.POST, body))["data"].ToString();
            return JsonConvert.DeserializeObject<TimeEntry>(data);
        }
        public async Task<TimeEntry> GetTimeEntryAsync(int TimeEntryID)
        {
            var data = JObject.Parse(await RequestAsync("/time_entries/" + TimeEntryID))["data"].ToString();
            return JsonConvert.DeserializeObject<TimeEntry>(data);
        }
        public async Task<TimeEntry> GetRunningTimeEntryAsync()
        {
            var data = JObject.Parse(await RequestAsync("/time_entries/current"))["data"].ToString();
            return JsonConvert.DeserializeObject<TimeEntry>(data);
        }
        public async Task<TimeEntry> UpdateTimeEntryAsync(int TimeEntryID, string description, string[] tags, double duration, DateTime start, DateTime? stop, int? wid, int? pid, bool billable, string created_with)
        {
            string body = JsonConvert.SerializeObject(new
            {
                time_entry = new
                {
                    description = description,
                    tags = tags,
                    duration = duration,
                    start = start.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ"),
                    stop = stop == null ? null : ((DateTime)stop).ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ"),
                    pid = pid,
                    wid = wid,
                    billable = billable,
                    created_with = created_with
                }
            }, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore});
            var data = JObject.Parse(await RequestAsync("/time_entries/" + TimeEntryID, HttpVerb.PUT, body))["data"].ToString();
            return JsonConvert.DeserializeObject<TimeEntry>(data);
        }
        public async Task DeleteTimeEntryAsync(int TimeEntryID)
        {
            await RequestAsync("/time_entries/" + TimeEntryID, HttpVerb.DELETE);
        }
        public async Task<TimeEntry> StopTimeEntryAsync(int TimeEntryID)
        {
            var data = JObject.Parse(await RequestAsync("/time_entries/" + TimeEntryID + "/stop ", HttpVerb.PUT))["data"].ToString();
            return JsonConvert.DeserializeObject<TimeEntry>(data);
        }
        public async Task<List<TimeEntry>> GetTimeEntriesAsync(DateTime since, DateTime until)
        {
            return JsonConvert.DeserializeObject<List<TimeEntry>>(await RequestAsync("/time_entries?start_date=" + since.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ") + "&end_date=" + until.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ")));
        }
    }
}
