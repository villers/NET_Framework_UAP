using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NET_Framework.Model
{
    public class Computer
    {

        public string UniqueId { get; set; }

        public string Title { get; set; }

        public Component[] Components { get; set; }
    }

}
