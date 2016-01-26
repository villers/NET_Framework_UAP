using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NET_Framework.Model
{
    public class ComponentsKey
    {
        [JsonProperty("UniqueId")]
        public string UniqueId { get; set; }

        [JsonProperty("Title")]
        public string Title { get; set; }

        [JsonProperty("Image")]
        public string Image { get; set; }
    }
}
