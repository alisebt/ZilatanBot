using System;
using System.Collections.Generic;

namespace DomainModel.Models
{
    public partial class Photo
    {
        public int id { get; set; }
        public int userid { get; set; }
        public string imageaddress { get; set; }
    }
}
