using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NET_Framework.Model
{
    public class Component
    {
        public ComponentsKey[] Graphic { get; set; }

        public ComponentsKey[] Cpu { get; set; }

        public ComponentsKey[] Memory { get; set; }

        public ComponentsKey[] Storage { get; set; }
    }

}
