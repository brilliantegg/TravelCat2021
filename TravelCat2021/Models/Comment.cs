using System;
using System.Collections.Generic;

#nullable disable

namespace TravelCat2021.Models
{
    public partial class Comment
    {
        public Comment()
        {
            CommentEmojiDetails = new HashSet<CommentEmojiDetail>();
            Messages = new HashSet<Message>();
        }

        public long CommentId { get; set; }
        public string TourismId { get; set; }
        public string CommentTitle { get; set; }
        public string CommentContent { get; set; }
        public DateTime CommentDate { get; set; }
        public string CommentPhoto { get; set; }
        public int CommentStayTotal { get; set; }
        public string TravelPartner { get; set; }
        public short CommentRating { get; set; }
        public string TravelMonth { get; set; }
        public bool CommentStatus { get; set; }
        public string MemberId { get; set; }

        public virtual Member Member { get; set; }
        public virtual ICollection<CommentEmojiDetail> CommentEmojiDetails { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}
