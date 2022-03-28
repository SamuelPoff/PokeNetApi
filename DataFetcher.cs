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
    public class DataFetcher
    {

        HttpBackend backend = new HttpBackend();

        public DataFetcher()
        {

        }

        public async Task<string> GetDataAsync(string path)
        {

            return await backend.GetStringAsync(path);

        }

        public async Task<Pokemon> GetPokemonAsync(string path)
        {

            Stream jsonStream = await backend.GetStreamAsync(path);
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            Pokemon pokemon = await JsonSerializer.DeserializeAsync<Pokemon>(jsonStream, options);
            Console.WriteLine(pokemon.name);
            return pokemon;

        }

    }
}
