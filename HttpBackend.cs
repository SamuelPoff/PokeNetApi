using System;
using System.IO;
using System.Net.Http;

using System.Threading.Tasks;

namespace PokeNetApi
{
    /// <summary>
    /// Handles backend http requests to PokeAPI
    /// </summary>
    public class HttpBackend
    {

        public static readonly string DefaultApiSiteURL = "https://pokeapi.co";
        public static readonly string DefaultBaseURL = $"{DefaultApiSiteURL}/api/v2/";
        public static readonly string UserAgent = "PokeNetApi (Testing new class library for interacting with PokeApi)";

        private HttpClient client;

        public HttpBackend()
        {

            client = new HttpClient();
            client.DefaultRequestHeaders.UserAgent.ParseAdd(UserAgent);

        }

        public async Task<Stream> GetStreamAsync(string path)
        {

            string url = (path.Contains(DefaultBaseURL)) ? path : DefaultBaseURL + path;
            Stream result = null;
            try
            {
                result = await client.GetStreamAsync(url);
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return result;

        }

        public async Task<string> GetStringAsync(string path)
        {

            string url = (path.Contains(DefaultBaseURL)) ? path : DefaultBaseURL + path;
            return await client.GetStringAsync(url);

        }

    }
}
