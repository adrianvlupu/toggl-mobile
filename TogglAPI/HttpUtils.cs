using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TogglAPI
{
    public static class HttpUtils
    {
        public static string base64Encode(string data)
        {
            byte[] encData_byte = new byte[data.Length];
            encData_byte = System.Text.Encoding.UTF8.GetBytes(data);
            string encodedData = Convert.ToBase64String(encData_byte);
            return encodedData;
        }

        public static async Task<bool> HttpDeleteAsync(string url, Dictionary<string, string> headers = null)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            if (headers != null)
            {
                foreach (var header in headers)
                {
                    request.Headers[header.Key] = header.Value;
                }
            }
            request.Method = "DELETE";
            request.ContentType = "application/x-www-form-urlencoded";
            try
            {
                HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync();
                if (response.StatusCode == HttpStatusCode.OK)
                    return true;
                else return false;
            }
            catch
            {
                return false;
            }
        }

        public static async Task<string> HttpGetAsync(string url, Dictionary<string, string> headers = null)
        {
            HttpWebRequest webRequest = (HttpWebRequest)HttpWebRequest.Create(url);
            if (headers != null)
            {
                foreach (var header in headers)
                {
                    webRequest.Headers[header.Key] = header.Value;
                }
            }
            //webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.Method = "GET";
            webRequest.Accept = "application/json";
            HttpWebResponse webResponse = (HttpWebResponse)await webRequest.GetResponseAsync();
            StreamReader webSource = new StreamReader(webResponse.GetResponseStream());
            string source = string.Empty;
            source = webSource.ReadToEnd();
            webResponse.Dispose();
            return source;
        }

        public static async Task<string> HttpPostAsync(string uri, string body, Dictionary<string, string> headers = null)
        {
            WebRequest webRequest = WebRequest.Create(uri);
            if (headers != null)
            {
                foreach (var header in headers)
                {
                    webRequest.Headers[header.Key] = header.Value;
                }
            }
            webRequest.ContentType = "application/json";
            webRequest.Method = "POST";
            byte[] bytes = Encoding.UTF8.GetBytes(body);
            Stream os = null;
            try
            {
                os = await webRequest.GetRequestStreamAsync();
                os.Write(bytes, 0, bytes.Length);
            }
            catch
            {
                throw new Exception("HttpPost: Request error");
            }
            finally
            {
                if (os != null)
                    os.Dispose();
            }

            try
            {
                WebResponse webResponse = await webRequest.GetResponseAsync();
                if (webResponse == null)
                    return null;
                StreamReader sr = new StreamReader(webResponse.GetResponseStream());
                return sr.ReadToEnd().Trim();
            }
            catch (WebException ex)
            {
                throw new Exception("HttpPost: Response error");
                throw new Exception(ex.Message);
            }
            return null;
        }

        public static async Task<string> HttpPutAsync(string uri, string body, Dictionary<string, string> headers = null)
        {
            if (String.IsNullOrEmpty(body))
                body = string.Empty;
            WebRequest webRequest = WebRequest.Create(uri);
            if (headers != null)
            {
                foreach (var header in headers)
                {
                    webRequest.Headers[header.Key] = header.Value;
                }
            }
            webRequest.ContentType = "application/json";
            webRequest.Method = "PUT";
            byte[] bytes = Encoding.UTF8.GetBytes(body);
            Stream os = null;
            try
            {
                os = await webRequest.GetRequestStreamAsync();
                os.Write(bytes, 0, bytes.Length);
            }
            catch
            {
                throw new Exception("HttpPut: Request error");
            }
            finally
            {
                if (os != null)
                    os.Dispose();
            }

            try
            {
                WebResponse webResponse = await webRequest.GetResponseAsync();
                if (webResponse == null)
                    return null;
                StreamReader sr = new StreamReader(webResponse.GetResponseStream());
                return sr.ReadToEnd().Trim();
            }
            catch (WebException ex)
            {
                throw new Exception("HttpPut: Response error");
                throw new Exception(ex.Message);
            }
            return null;
        }
    }
}
