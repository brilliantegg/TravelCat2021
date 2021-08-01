using System;
using System.Collections.Generic;

#nullable disable

namespace TravelCat2021.Models
{
    public partial class MessageEmojiDetail
    {
        public long Id { get; set; }
        public string MemberId { get; set; }
        public long MsgId { get; set; }
        public int EmojiId { get; set; }
        public string TourismId { get; set; }

        public virtual Emoji Emoji { get; set; }
        public virtual Member Member { get; set; }
        public virtual Message Msg { get; set; }
    }
}
