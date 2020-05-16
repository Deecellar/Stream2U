using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Streaming.WebApp.Models
{
    public class ChatMessage
    {
        public int ChatMessageID { get; set; }
        public User ChatUser { get; set; }
        public DateTime SentTime { get; set; }
        public string MessageText { get; set; }
    }
}
