using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raptorex.BO.Entities
{
    public class ForumTopic : CreatedEntity
    {
        public string Title { get; set; }

        #region Navigation
        public ICollection<ForumPost> ThreadMessages { get; set; }

        #endregion
    }
}
