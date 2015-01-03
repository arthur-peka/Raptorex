using Raptorex.BO.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raptorex.DA.Configurations
{
    public class ForumPostConfig : BaseConfig<ForumPost>
    {
        public ForumPostConfig()
        {
            HasRequired(p => p.MessageTopic)
                .WithMany(t => t.Messages)
                .HasForeignKey(p => p.MessageTopicId);
        }
    }
}
