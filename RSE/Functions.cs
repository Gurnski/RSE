using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RSE
{
    internal class Functions
    {
        public static string XorString(string input)
        {
            string key = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
                sb.Append((char)(input[i] ^ key[(i % key.Length)]));
            String result = sb.ToString();

            return result;
        }
        
        public static string DownloadString(string url)
        {
            try
            {
                HttpClient client = new HttpClient();

                using (HttpResponseMessage response = client.GetAsync(url).Result)
                {
                    using (HttpContent content = response.Content)
                    {
                        return content.ReadAsStringAsync().Result;
                    }
                }
            }
            catch (HttpRequestException e)
            {
                MessageBox.Show("RSE can't establish a connection to the server, please try again.", "No connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return e.Message;
            }
        }
    }
}
