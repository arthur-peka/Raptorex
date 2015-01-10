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
        public DbSet<Subforum> Subforums { get; set; }
        public DbSet<ForumTopic> ForumTopics { get; set; }
        public DbSet<ForumPost> ForumPosts { get; set; }
        public DbSet<RaptorexUser> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Properties<DateTime>()
                .Configure(c => c.HasColumnType("datetime2"));

            modelBuilder.Configurations.Add(new UserConfig());
            modelBuilder.Configurations.Add(new ForumPostConfig());
            modelBuilder.Configurations.Add(new ForumTopicConfig());
        }
    }
}
