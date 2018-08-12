using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONCommunicator.Model
{
    [JsonObject(MemberSerialization.OptIn)]
    public class CelebrityInfo
    {
        // if don't include [JsonProperty], that field won't be included in Serialization process
        [JsonProperty]
        public string Name { get; set; }

        // just for demonstration
        public bool NotIncluded { get; set; }

        [JsonProperty]
        public string Occupation { get; set; }

        [JsonProperty]
        public int Age { get; set; }

        [JsonProperty]
        public string Partner { get; set; }
    }
}
