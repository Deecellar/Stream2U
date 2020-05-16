using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Streaming.WebApp.Models
{
    public class Channel
    {
        public int ChannelID { get; set; }
        public string ChannelName { get; set; }
        public User UserOwner { get; set; }
        public Stream[] Streams { get; set; }
    }
}
