using System;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TravelCat2021.Models;

#nullable disable

namespace TravelCat2021.Context
{
    public partial class TravelDbContext : DbContext
    {
        public TravelDbContext()
        {
        }

        public TravelDbContext(DbContextOptions<TravelDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Activity> Activities { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Badge> Badges { get; set; }
        public virtual DbSet<BadgeDetail> BadgeDetails { get; set; }
        public virtual DbSet<CollectionType> CollectionTypes { get; set; }
        public virtual DbSet<CollectionsDetail> CollectionsDetails { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<CommentEmojiDetail> CommentEmojiDetails { get; set; }
        public virtual DbSet<Emoji> Emojis { get; set; }
        public virtual DbSet<FollowList> FollowLists { get; set; }
        public virtual DbSet<Hotel> Hotels { get; set; }
        public virtual DbSet<Issue> Issues { get; set; }
        public virtual DbSet<IssueType> IssueTypes { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<MemberProfile> MemberProfiles { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<MessageEmojiDetail> MessageEmojiDetails { get; set; }
        public virtual DbSet<Restaurant> Restaurants { get; set; }
        public virtual DbSet<Spot> Spots { get; set; }
        public virtual DbSet<TourismPhoto> TourismPhotos { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //  if (!optionsBuilder.IsConfigured)
    //  {
    //    optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["TravelDatabase"].ConnectionString);
    //  }
    //}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Chinese_Taiwan_Stroke_CI_AS");

            modelBuilder.Entity<Activity>(entity =>
            {
                entity.ToTable("activity");

                entity.Property(e => e.ActivityId)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("activity_id")
                    .HasDefaultValueSql("([dbo].[GetactivityId]())")
                    .IsFixedLength(true);

                entity.Property(e => e.ActivityIntro)
                    .HasColumnType("ntext")
                    .HasColumnName("activity_intro");

                entity.Property(e => e.ActivityTel)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("activity_tel");

                entity.Property(e => e.ActivityTitle)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("activity_title")
                    .IsFixedLength(true);

                entity.Property(e => e.AddressDetail)
                    .HasMaxLength(100)
                    .HasColumnName("address_detail");

                entity.Property(e => e.BeginDate)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("begin_date");

                entity.Property(e => e.City)
                    .HasMaxLength(10)
                    .HasColumnName("city");

                entity.Property(e => e.District)
                    .HasMaxLength(10)
                    .HasColumnName("district");

                entity.Property(e => e.EndDate)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("end_date");

                entity.Property(e => e.Latitude)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("latitude");

                entity.Property(e => e.Longitude)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("longitude");

                entity.Property(e => e.Organizer)
                    .HasMaxLength(50)
                    .HasColumnName("organizer");

                entity.Property(e => e.PageStatus).HasColumnName("page_status");

                entity.Property(e => e.TransportInfo)
                    .HasMaxLength(1000)
                    .HasColumnName("transport_info");

                entity.Property(e => e.Website)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("website");
            });

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("admin");

                entity.Property(e => e.AdminId).HasColumnName("admin_id");

                entity.Property(e => e.AdminAccount)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("admin_account");

                entity.Property(e => e.AdminEmail)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("admin_email");

                entity.Property(e => e.AdminPassword)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("admin_password");

                entity.Property(e => e.EmailConfirmed)
                    .HasColumnName("emailConfirmed")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<Badge>(entity =>
            {
                entity.ToTable("badge");

                entity.Property(e => e.BadgeId).HasColumnName("badge_id");

                entity.Property(e => e.BadgePhoto)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("badge_photo");

                entity.Property(e => e.BadgeTitle)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("badge_title");
            });

            modelBuilder.Entity<BadgeDetail>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.MemberId, e.BadgeId })
                    .HasName("PK__badge_de__3EDDC8FA0D1FDA0D");

                entity.ToTable("badge_details");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.MemberId)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("member_id")
                    .IsFixedLength(true);

                entity.Property(e => e.BadgeId).HasColumnName("badge_id");

                entity.HasOne(d => d.Badge)
                    .WithMany(p => p.BadgeDetails)
                    .HasForeignKey(d => d.BadgeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__badge_det__badge__5441852A");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.BadgeDetails)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__badge_det__membe__4CA06362");
            });

            modelBuilder.Entity<CollectionType>(entity =>
            {
                entity.ToTable("collection_type");

                entity.Property(e => e.CollectionTypeId)
                    .ValueGeneratedNever()
                    .HasColumnName("collection_type_id");

                entity.Property(e => e.CollectionTypeTitle)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("collection_type_title");
            });

            modelBuilder.Entity<CollectionsDetail>(entity =>
            {
                entity.HasKey(e => new { e.CollectionId, e.MemberId })
                    .HasName("PK__collecti__08FA1D994A84366E");

                entity.ToTable("collections_detail");

                entity.Property(e => e.CollectionId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("collection_id");

                entity.Property(e => e.MemberId)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("member_id")
                    .IsFixedLength(true);

                entity.Property(e => e.CollectionTypeId).HasColumnName("collection_type_id");

                entity.Property(e => e.Privacy).HasColumnName("privacy");

                entity.Property(e => e.TourismId)
                    .IsRequired()
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("tourism_id")
                    .IsFixedLength(true);

                entity.HasOne(d => d.CollectionType)
                    .WithMany(p => p.CollectionsDetails)
                    .HasForeignKey(d => d.CollectionTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__collectio__colle__5535A963");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.CollectionsDetails)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__collectio__membe__4E88ABD4");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("comment");

                entity.Property(e => e.CommentId).HasColumnName("comment_id");

                entity.Property(e => e.CommentContent)
                    .IsRequired()
                    .HasColumnType("ntext")
                    .HasColumnName("comment_content");

                entity.Property(e => e.CommentDate)
                    .HasColumnType("datetime")
                    .HasColumnName("comment_date");

                entity.Property(e => e.CommentPhoto)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("comment_photo");

                entity.Property(e => e.CommentRating).HasColumnName("comment_rating");

                entity.Property(e => e.CommentStatus).HasColumnName("comment_status");

                entity.Property(e => e.CommentStayTotal).HasColumnName("comment_stay_total");

                entity.Property(e => e.CommentTitle)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("comment_title");

                entity.Property(e => e.MemberId)
                    .IsRequired()
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("member_id")
                    .IsFixedLength(true);

                entity.Property(e => e.TourismId)
                    .IsRequired()
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("tourism_id")
                    .IsFixedLength(true);

                entity.Property(e => e.TravelMonth)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("travel_month");

                entity.Property(e => e.TravelPartner)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("travel_partner");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__comment__member___48CFD27E");
            });

            modelBuilder.Entity<CommentEmojiDetail>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.MemberId, e.CommentId })
                    .HasName("PK__comment___EFDDC51A81DEC4D1");

                entity.ToTable("comment_emoji_details");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.MemberId)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("member_id")
                    .IsFixedLength(true);

                entity.Property(e => e.CommentId).HasColumnName("comment_id");

                entity.Property(e => e.EmojiId).HasColumnName("emoji_id");

                entity.Property(e => e.TourismId)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("tourism_id")
                    .IsFixedLength(true);

                entity.HasOne(d => d.Comment)
                    .WithMany(p => p.CommentEmojiDetails)
                    .HasForeignKey(d => d.CommentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__comment_e__comme__5165187F");

                entity.HasOne(d => d.Emoji)
                    .WithMany(p => p.CommentEmojiDetails)
                    .HasForeignKey(d => d.EmojiId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__comment_e__emoji__571DF1D5");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.CommentEmojiDetails)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__comment_e__membe__4AB81AF0");
            });

            modelBuilder.Entity<Emoji>(entity =>
            {
                entity.ToTable("emoji");

                entity.Property(e => e.EmojiId)
                    .ValueGeneratedNever()
                    .HasColumnName("emoji_id");

                entity.Property(e => e.EmojiPic)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("emoji_pic");

                entity.Property(e => e.EmojiTitle)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("emoji_title");
            });

            modelBuilder.Entity<FollowList>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.MemberId })
                    .HasName("PK__follow_l__693A506CC940328A");

                entity.ToTable("follow_list");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.MemberId)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("member_id")
                    .IsFixedLength(true);

                entity.Property(e => e.FollowDate)
                    .HasColumnType("datetime")
                    .HasColumnName("follow_date");

                entity.Property(e => e.FollowedId)
                    .IsRequired()
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("followed_id")
                    .IsFixedLength(true);

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.FollowLists)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__follow_li__membe__4F7CD00D");
            });

            modelBuilder.Entity<Hotel>(entity =>
            {
                entity.ToTable("hotel");

                entity.Property(e => e.HotelId)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("hotel_id")
                    .HasDefaultValueSql("([dbo].[GethotelId]())")
                    .IsFixedLength(true);

                entity.Property(e => e.AddressDetail)
                    .HasMaxLength(100)
                    .HasColumnName("address_detail");

                entity.Property(e => e.City)
                    .HasMaxLength(10)
                    .HasColumnName("city");

                entity.Property(e => e.District)
                    .HasMaxLength(5)
                    .HasColumnName("district");

                entity.Property(e => e.HotelIntro)
                    .HasColumnType("ntext")
                    .HasColumnName("hotel_intro");

                entity.Property(e => e.HotelTel)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("hotel_tel");

                entity.Property(e => e.HotelTitle)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("hotel_title");

                entity.Property(e => e.Latitude)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("latitude");

                entity.Property(e => e.Longitude)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("longitude");

                entity.Property(e => e.PageStatus).HasColumnName("page_status");

                entity.Property(e => e.Website)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("website");
            });

            modelBuilder.Entity<Issue>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.MemberId, e.AdminId, e.IssueId })
                    .HasName("PK__issue__EAF49BA89E2A03D1");

                entity.ToTable("issue");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.MemberId)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("member_id")
                    .IsFixedLength(true);

                entity.Property(e => e.AdminId).HasColumnName("admin_id");

                entity.Property(e => e.IssueId).HasColumnName("issue_id");

                entity.Property(e => e.IssueContent)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .HasColumnName("issue_content");

                entity.Property(e => e.IssueResult)
                    .HasMaxLength(1000)
                    .HasColumnName("issue_result");

                entity.Property(e => e.IssueStatus).HasColumnName("issue_status");

                entity.Property(e => e.ProblemId)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("problem_id");

                entity.Property(e => e.ReportDate)
                    .HasColumnType("datetime")
                    .HasColumnName("report_date");

                entity.Property(e => e.ResolveDate)
                    .HasColumnType("datetime")
                    .HasColumnName("resolve_date");

                entity.HasOne(d => d.Admin)
                    .WithMany(p => p.Issues)
                    .HasForeignKey(d => d.AdminId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__issue__admin_id__534D60F1");

                entity.HasOne(d => d.IssueNavigation)
                    .WithMany(p => p.Issues)
                    .HasForeignKey(d => d.IssueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__issue__issue_id__5812160E");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.Issues)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__issue__member_id__4D94879B");
            });

            modelBuilder.Entity<IssueType>(entity =>
            {
                entity.HasKey(e => e.IssueId)
                    .HasName("PK__issue_ty__D6185C399DAC0D66");

                entity.ToTable("issue_type");

                entity.Property(e => e.IssueId).HasColumnName("issue_id");

                entity.Property(e => e.IssueName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("issue_name");
            });

            modelBuilder.Entity<Member>(entity =>
            {
                entity.ToTable("member");

                entity.Property(e => e.MemberId)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("member_id")
                    .HasDefaultValueSql("([dbo].[GetmemberId]())")
                    .IsFixedLength(true);

                entity.Property(e => e.MemberAccount)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("member_account");

                entity.Property(e => e.MemberPassword)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("member_password");

                entity.Property(e => e.MemberStatus).HasColumnName("member_status");
            });

            modelBuilder.Entity<MemberProfile>(entity =>
            {
                entity.HasKey(e => e.MemberId)
                    .HasName("PK__member_p__B29B85341BF7715D");

                entity.ToTable("member_profile");

                entity.Property(e => e.MemberId)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("member_id")
                    .IsFixedLength(true);

                entity.Property(e => e.AddressDetail)
                    .HasMaxLength(60)
                    .HasColumnName("address_detail");

                entity.Property(e => e.Birthday)
                    .HasColumnType("datetime")
                    .HasColumnName("birthday");

                entity.Property(e => e.BriefIntro)
                    .HasMaxLength(300)
                    .HasColumnName("brief_intro");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("city");

                entity.Property(e => e.CoverPhoto)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("cover_photo");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("create_time");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.EmailConfirmed)
                    .HasColumnName("emailConfirmed")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.MemberName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("member_name");

                entity.Property(e => e.MemberScore).HasColumnName("member_score");

                entity.Property(e => e.Nation)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("nation");

                entity.Property(e => e.Nickname)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("nickname");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.ProfilePhoto)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("profile_photo");

                entity.Property(e => e.WebsiteLink)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("website_link");

                entity.HasOne(d => d.Member)
                    .WithOne(p => p.MemberProfile)
                    .HasForeignKey<MemberProfile>(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__member_pr__membe__47DBAE45");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.HasKey(e => e.MsgId)
                    .HasName("PK__message__9CA9728D96A610CF");

                entity.ToTable("message");

                entity.Property(e => e.MsgId).HasColumnName("msg_id");

                entity.Property(e => e.CommentId).HasColumnName("comment_id");

                entity.Property(e => e.MemberId)
                    .IsRequired()
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("member_id")
                    .IsFixedLength(true);

                entity.Property(e => e.MsgContent)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .HasColumnName("msg_content");

                entity.Property(e => e.MsgStatus).HasColumnName("msg_status");

                entity.Property(e => e.MsgTime)
                    .HasColumnType("datetime")
                    .HasColumnName("msg_time");

                entity.Property(e => e.TourismId)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("tourism_id")
                    .IsFixedLength(true);

                entity.HasOne(d => d.Comment)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.CommentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__message__comment__5070F446");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__message__member___4BAC3F29");
            });

            modelBuilder.Entity<MessageEmojiDetail>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.MemberId, e.MsgId })
                    .HasName("PK__message___E5A6F91EFD15D3FA");

                entity.ToTable("message_emoji_details");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.MemberId)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("member_id")
                    .IsFixedLength(true);

                entity.Property(e => e.MsgId).HasColumnName("msg_id");

                entity.Property(e => e.EmojiId).HasColumnName("emoji_id");

                entity.Property(e => e.TourismId)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("tourism_id")
                    .IsFixedLength(true);

                entity.HasOne(d => d.Emoji)
                    .WithMany(p => p.MessageEmojiDetails)
                    .HasForeignKey(d => d.EmojiId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__message_e__emoji__5629CD9C");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.MessageEmojiDetails)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__message_e__membe__49C3F6B7");

                entity.HasOne(d => d.Msg)
                    .WithMany(p => p.MessageEmojiDetails)
                    .HasForeignKey(d => d.MsgId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__message_e__msg_i__52593CB8");
            });

            modelBuilder.Entity<Restaurant>(entity =>
            {
                entity.ToTable("restaurant");

                entity.Property(e => e.RestaurantId)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("restaurant_id")
                    .HasDefaultValueSql("([dbo].[GetrestId]())")
                    .IsFixedLength(true);

                entity.Property(e => e.AddressDetail)
                    .HasMaxLength(100)
                    .HasColumnName("address_detail");

                entity.Property(e => e.City)
                    .HasMaxLength(10)
                    .HasColumnName("city");

                entity.Property(e => e.District)
                    .HasMaxLength(5)
                    .HasColumnName("district");

                entity.Property(e => e.Latitude)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("latitude");

                entity.Property(e => e.Longitude)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("longitude");

                entity.Property(e => e.OpenTime)
                    .HasMaxLength(150)
                    .HasColumnName("open_time");

                entity.Property(e => e.PageStatus).HasColumnName("page_status");

                entity.Property(e => e.RestaurantIntro)
                    .HasColumnType("ntext")
                    .HasColumnName("restaurant_intro");

                entity.Property(e => e.RestaurantTel)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("restaurant_tel");

                entity.Property(e => e.RestaurantTitle)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("restaurant_title")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Spot>(entity =>
            {
                entity.ToTable("spot");

                entity.Property(e => e.SpotId)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("spot_id")
                    .HasDefaultValueSql("([dbo].[GetspotId]())")
                    .IsFixedLength(true);

                entity.Property(e => e.AdditionNote)
                    .HasMaxLength(250)
                    .HasColumnName("addition_note");

                entity.Property(e => e.AddressDetail)
                    .HasMaxLength(100)
                    .HasColumnName("address_detail");

                entity.Property(e => e.City)
                    .HasMaxLength(10)
                    .HasColumnName("city");

                entity.Property(e => e.District)
                    .HasMaxLength(5)
                    .HasColumnName("district");

                entity.Property(e => e.Latitude)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("latitude");

                entity.Property(e => e.Longitude)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("longitude");

                entity.Property(e => e.OpenTime)
                    .HasMaxLength(500)
                    .HasColumnName("open_time");

                entity.Property(e => e.PageStatus).HasColumnName("page_status");

                entity.Property(e => e.SpotIntro)
                    .HasColumnType("ntext")
                    .HasColumnName("spot_intro");

                entity.Property(e => e.SpotTel)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("spot_tel");

                entity.Property(e => e.SpotTitle)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("spot_title");

                entity.Property(e => e.TicketInfo)
                    .HasMaxLength(150)
                    .HasColumnName("ticket_info");

                entity.Property(e => e.TravellingInfo)
                    .HasMaxLength(1000)
                    .HasColumnName("travelling_info")
                    .IsFixedLength(true);

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("update_date");
            });

            modelBuilder.Entity<TourismPhoto>(entity =>
            {
                entity.ToTable("tourism_photo");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.TourismId)
                    .IsRequired()
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("tourism_id")
                    .IsFixedLength(true);

                entity.Property(e => e.TourismPhoto1)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("tourism_photo");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
