using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeatSaberPlaylistToHash.Models
{
    /// <summary>
    /// Represents the metadata version of the map
    /// </summary>
    public class MapVersion
    {
        /// <summary>
        /// Gets or sets the hash of the version
        /// </summary>
        public string Hash { get; set; }

        /// <summary>
        /// Gets or sets the key of the version
        /// </summary>
        public string Key { get; set; }
    }
}
