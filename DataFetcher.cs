using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using System.Text.Json;

using PokeNetApi.Objects;

namespace PokeNetApi
{
    /// <summary>
    /// Fetches actual object representations of data from PokeAPI
    /// </summary>
    public class DataFetcher
    {

        HttpBackend backend = new HttpBackend();

        /// <summary>
        /// Returns raw string data from a given path in PokeAPI
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public async Task<string> GetDataAsync(string path)
        {

            return await backend.GetStringAsync(path);

        }

        /// <summary>
        /// Returns Pokemon instance of the pokemon at the given path in PokeAPI
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public async Task<Pokemon> GetPokemonAsync(string path)
        {

            Stream jsonStream = await backend.GetStreamAsync(path);
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            Pokemon pokemon = await JsonSerializer.DeserializeAsync<Pokemon>(jsonStream, options);
            return pokemon;

        }

    }
}
