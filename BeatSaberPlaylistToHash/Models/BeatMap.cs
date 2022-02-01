using System.Collections.Generic;

namespace BeatSaberPlaylistToHash.Models
{
    /// <summary>
    /// Represents the metadata of a beat map
    /// </summary>
    public class BeatMap
    {
        /// <summary>
        /// Gets or sets the ID of a beat map
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the versions of the beat map
        /// </summary>
        public List<MapVersion> Versions { get; set; }
    }
}
