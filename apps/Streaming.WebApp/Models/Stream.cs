using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Streaming.WebApp.Models
{
    public class Stream
    {
        public int StreamID { get; set; }
        public Channel Owner { get; set; }
        public string Name { get; set; }
        public int Viewer { get; set; }
        public int CurrentViewership { get; set; }
        public string Tags { get; set; }
        public Chat StreamChat { get; set; }

    }
}
