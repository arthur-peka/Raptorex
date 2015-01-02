using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raptorex.BO.Entities
{
    public class ForumPost : CreatedEntity
    {
        public string Text { get; set; }

        #region Navigation

        public Guid MessageThreadId { get; set; }

        public ForumTopic MessageThread { get; set; }

        #endregion
    }
}
