using System;
using System.Collections.Generic;

namespace DomainModel.Models
{
    public partial class User
    {
        public int id { get; set; }
        public int telegram_userid { get; set; }
        public string telegram_username { get; set; }
        public string profilephoto { get; set; }
        public System.DateTime createdate { get; set; }
    }
}
