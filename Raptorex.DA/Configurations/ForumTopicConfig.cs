using Raptorex.BO.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raptorex.DA.Configurations
{
    public class ForumTopicConfig : BaseConfig<ForumTopic>
    {
        public ForumTopicConfig()
        {
            HasRequired(t => t.TopicSubforum)
                .WithMany(s => s.Topics)
                .HasForeignKey(t => t.TopicSubforumId);
        }
    }
}
