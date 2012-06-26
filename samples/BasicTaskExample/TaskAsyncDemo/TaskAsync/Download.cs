using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http; // new in 4.5 

namespace TaskAsyncDemo
{
    public class Download
    {
        public Download()
        {
        }

        public async Task<string> GetHypertext(Uri uri)
        {
            // .net 4.5 HttpClient
            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync(uri);
            response.EnsureSuccessStatusCode();

            string result = await response.Content.ReadAsStringAsync();

            return result;
        }

        public async Task<byte[]> GetBinary(Uri uri)
        {
            // .net 4.5 HttpClient
            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsByteArrayAsync();
        }
    }
}
