using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BeatSaberPlaylistToHash.Models;

namespace BeatSaberPlaylistToHash.Services
{
    public class BeatSaverApi
    {
        /// <summary>
        /// Gets the beat saver api url
        /// </summary>
        const string BEAT_SAVER_API = "https://api.beatsaver.com/";

        /// <summary>
        /// HTTP service
        /// </summary>
        readonly HttpClient _httpClient = new ();

        /// <summary>
        /// Gets the beat map metadata by bsr code from beat saver api
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<BeatMap> GetMapMetaByIdAsync(string id)
        {
            return _httpClient.GetFromJsonAsync<BeatMap>($"{BEAT_SAVER_API}/maps/id/{id}");
        }
    }
}
