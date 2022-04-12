using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace MyWebAPI.Models
{
    public class Region
    {
        [JsonIgnore]
        public int ID { get; set; }
        public string Name { get; set; }
    }
}