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
                .HasRequired(m => m.MessageThread)
                .WithMany(t => t.ThreadMessages)
                .HasForeignKey(m => m.MessageThreadId);

            modelBuilder.Configurations.Add(new UserConfig());
        }
    }
}
