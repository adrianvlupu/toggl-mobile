using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TogglAPI.Models;

namespace TogglAPI
{
    public partial class TogglAPI
    {
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
        public async Task<TimeEntry> StopTimeEntryAsync(int TimeEntryID)
        {
            var data = JObject.Parse(await RequestAsync("/time_entries/" + TimeEntryID + "/stop ", HttpVerb.PUT))["data"].ToString();
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
            }, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            var data = JObject.Parse(await RequestAsync("/time_entries/" + TimeEntryID, HttpVerb.PUT, body))["data"].ToString();
            return JsonConvert.DeserializeObject<TimeEntry>(data);
        }
        public async System.Threading.Tasks.Task DeleteTimeEntryAsync(int TimeEntryID)
        {
            await RequestAsync("/time_entries/" + TimeEntryID, HttpVerb.DELETE);
        }
        public async Task<List<TimeEntry>> GetTimeEntriesAsync(DateTime since, DateTime until)
        {
            return JsonConvert.DeserializeObject<List<TimeEntry>>(await RequestAsync("/time_entries?start_date=" + since.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ") + "&end_date=" + until.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ")));
        }

        //TODO: TogglAPI - Bulk update Time Entries
    }
}
