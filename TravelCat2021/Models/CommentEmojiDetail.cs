using System;
using System.Collections.Generic;

#nullable disable

namespace TravelCat2021.Models
{
    public partial class CommentEmojiDetail
    {
        public long Id { get; set; }
        public string MemberId { get; set; }
        public long CommentId { get; set; }
        public int EmojiId { get; set; }
        public string TourismId { get; set; }

        public virtual Comment Comment { get; set; }
        public virtual Emoji Emoji { get; set; }
        public virtual Member Member { get; set; }
    }
}
