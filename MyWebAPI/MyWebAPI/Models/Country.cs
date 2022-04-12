using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebAPI.Models
{
    public class Country
    {
        public int ID { get; set; }

        public int RegionID { get; set; }

        public string Name { get; set; }
    }
}