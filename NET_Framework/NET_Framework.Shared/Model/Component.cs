using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NET_Framework.Model
{
    public class Component
    {
        [JsonProperty("Graphic")]
        public ComponentsKey[] Graphic { get; set; }

        [JsonProperty("Cpu")]
        public ComponentsKey[] Cpu { get; set; }

        [JsonProperty("Memory")]
        public ComponentsKey[] Memory { get; set; }

        [JsonProperty("Storage")]
        public ComponentsKey[] Storage { get; set; }
    }

}
