using System;
using System.Collections.Generic;

#nullable disable

namespace TravelCat2021.Models
{
    public partial class Member
    {
        public Member()
        {
            BadgeDetails = new HashSet<BadgeDetail>();
            CollectionsDetails = new HashSet<CollectionsDetail>();
            CommentEmojiDetails = new HashSet<CommentEmojiDetail>();
            Comments = new HashSet<Comment>();
            FollowLists = new HashSet<FollowList>();
            Issues = new HashSet<Issue>();
            MessageEmojiDetails = new HashSet<MessageEmojiDetail>();
            Messages = new HashSet<Message>();
        }

        public string MemberId { get; set; }
        public string MemberAccount { get; set; }
        public string MemberPassword { get; set; }
        public bool MemberStatus { get; set; }

        public virtual MemberProfile MemberProfile { get; set; }
        public virtual ICollection<BadgeDetail> BadgeDetails { get; set; }
        public virtual ICollection<CollectionsDetail> CollectionsDetails { get; set; }
        public virtual ICollection<CommentEmojiDetail> CommentEmojiDetails { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<FollowList> FollowLists { get; set; }
        public virtual ICollection<Issue> Issues { get; set; }
        public virtual ICollection<MessageEmojiDetail> MessageEmojiDetails { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}
