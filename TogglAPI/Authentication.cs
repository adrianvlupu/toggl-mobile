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

        //TODO: TogglAPI - Authentication with a session cookie
        //TODO: TogglAPI - Destroy the session
    }
}
