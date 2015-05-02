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
    }
}
