using System;
using System.Collections.Generic;

#nullable disable

namespace TravelCat2021.Models
{
    public partial class Emoji
    {
        public Emoji()
        {
            CommentEmojiDetails = new HashSet<CommentEmojiDetail>();
            MessageEmojiDetails = new HashSet<MessageEmojiDetail>();
        }

        public int EmojiId { get; set; }
        public string EmojiTitle { get; set; }
        public string EmojiPic { get; set; }

        public virtual ICollection<CommentEmojiDetail> CommentEmojiDetails { get; set; }
        public virtual ICollection<MessageEmojiDetail> MessageEmojiDetails { get; set; }
    }
}
