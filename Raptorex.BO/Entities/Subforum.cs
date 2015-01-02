using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raptorex.BO.Entities
{
    /// <summary>
    /// Hierarchy: Subforum -> Topic -> Post
    /// </summary>
    public class Subforum : BaseEntity
    {
        public string Title { get; set; }


        #region Navigation

        public ICollection<ForumTopic> Topics { get; set; }

        #endregion
    }
}
