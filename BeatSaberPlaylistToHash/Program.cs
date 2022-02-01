using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using BeatSaberPlaylistToHash.Models;
using BeatSaberPlaylistToHash.Services;

namespace BeatSaberPlaylistToHash
{
    class Program
    {
        static void Main(string[] args)
        {
            _ = MainAsync(args);
            Console.ReadLine();
        }

        static async Task MainAsync(string[] args)
        {
            var dir = Path.GetDirectoryName(args[0]);
            var filename = Path.GetFileNameWithoutExtension(args[0]);

            var bsrCodes = (await File.ReadAllLinesAsync(args[0])).Select(FilterBsr);
            var tasks = bsrCodes.Select(GetSongMetadataAsync);
            var songs = await Task.WhenAll(tasks);

            var playlist = new Playlist();
            playlist.Songs.AddRange(songs);

            var options = new JsonSerializerOptions(JsonSerializerDefaults.Web);
            var jsonString = JsonSerializer.Serialize(playlist, options);
            await File.WriteAllTextAsync($"{dir}/{filename}.json", jsonString);
        }

        /// <summary>
        /// Gets the songs metadata from the API
        /// </summary>
        /// <param name="id">the bsr id</param>
        /// <returns></returns>
        static async Task<PlaylistSong> GetSongMetadataAsync(string id)
        {
            var api = new BeatSaverApi();
            var beatMap = await api.GetMapMetaByIdAsync(id);

            var song = new PlaylistSong
            {
                Hash = beatMap.Versions[0].Hash
            };

            return song;
        }

        /// <summary>
        /// Removes bsr command if exists
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        static string FilterBsr(string id)
        {
            return id.Replace("!bsr ", "");
        }
    }
}
