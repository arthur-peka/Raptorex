using Raptorex.BO.Entities;
using Raptorex.DA.Configurations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raptorex.DA
{
    public class RaptorexContext : DbContext
    {
        public RaptorexContext() : base("RaptorexDb") { }

        public DbSet<ForumTopic> ForumTopics { get; set; }
        public DbSet<ForumPost> ForumPosts { get; set; }
        public DbSet<RaptorexUser> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Properties<DateTime>()
                .Configure(c => c.HasColumnType("datetime2"));

            modelBuilder.Entity<ForumPost>()
                .HasRequired(m => m.MessageTopic)
                .WithMany(t => t.Messages)
                .HasForeignKey(m => m.MessageTopicId);

            modelBuilder.Entity<ForumTopic>()
                .HasRequired(t => t.TopicSubforum)
                .WithMany(s => s.Topics)
                .HasForeignKey(t => t.TopicSubforumId);

            modelBuilder.Configurations.Add(new UserConfig());
        }
    }
}
