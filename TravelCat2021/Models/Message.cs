using System;
using System.Collections.Generic;

#nullable disable

namespace TravelCat2021.Models
{
    public partial class Message
    {
        public Message()
        {
            MessageEmojiDetails = new HashSet<MessageEmojiDetail>();
        }

        public long MsgId { get; set; }
        public DateTime MsgTime { get; set; }
        public string MsgContent { get; set; }
        public long CommentId { get; set; }
        public string MemberId { get; set; }
        public bool? MsgStatus { get; set; }
        public string TourismId { get; set; }

        public virtual Comment Comment { get; set; }
        public virtual Member Member { get; set; }
        public virtual ICollection<MessageEmojiDetail> MessageEmojiDetails { get; set; }
    }
}
