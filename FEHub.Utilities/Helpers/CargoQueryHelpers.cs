//-----------------------------------------------------------------------------
// <copyright file="CargoQueryHelpers.cs">
//     Copyright (c) 2020 by Bryan Bush. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FEHub.Utilities.Helpers
{
    internal static class CargoQueryHelpers
    {
        private const int BATCH_SIZE = 500;

        private static readonly HttpClient _httpClient = new HttpClient() { BaseAddress = new Uri("https://feheroes.gamepedia.com/api.php") };

        public static async Task<List<JToken>> GetAsync(Dictionary<string, string> queryParameters)
        {
            var results = new List<JToken>();

            List<JToken> batchResults;
            var offset = 0;

            do
            {
                batchResults = await GetAsyncHelper(queryParameters, offset);
                offset += BATCH_SIZE;

                if (batchResults == null)
                {
                    return null;
                }

                results.AddRange(batchResults);
            } while (batchResults.Count == BATCH_SIZE);

            return results;
        }

        private static async Task<List<JToken>> GetAsyncHelper(Dictionary<string, string> queryParameters, int offset = 0)
        {
            var request = new StringBuilder($"?action=cargoquery&format=json&offset={offset}&limit={BATCH_SIZE}");

            if (queryParameters.Count > 0)
            {
                request.Append($"&{string.Join("&", queryParameters.Select(x => $"{x.Key}={x.Value}"))}");
            }

            var response = await _httpClient.GetAsync(request.ToString());

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            using var stream = await response.Content.ReadAsStreamAsync();
            using var streamReader = new StreamReader(stream);
            using var jsonTextReader = new JsonTextReader(streamReader);

            var content = await JObject.LoadAsync(jsonTextReader);

            return content.SelectTokens("$.cargoquery[*].title").ToList();
        }
    }
}
