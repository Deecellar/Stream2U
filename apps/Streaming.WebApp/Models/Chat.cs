using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Streaming.WebApp.Models
{
    public class Chat
    {
        public int ChatID { get; set; }
        public ChatMessage[] ChatMessages { get; set; }
    }
}
