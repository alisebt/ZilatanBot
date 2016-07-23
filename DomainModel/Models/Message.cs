using System;
using System.Collections.Generic;

namespace DomainModel.Models
{
    public partial class Message
    {
        public int Id { get; set; }
        public int message_Id { get; set; }
        public int from_id { get; set; }
        public string from_username { get; set; }
        public long date { get; set; }
        public string text { get; set; }
        public System.DateTime createDate { get; set; }
    }
}
