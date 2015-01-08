using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raptorex.BO.Entities
{
    /// <summary>
    /// Hierarchy: Subforum -> Topic -> Post
    /// </summary>
    public class ForumTopic : CreatedEntity
    {
        [Required]
        public string Title { get; set; }

        #region Navigation
        public ICollection<ForumPost> Messages { get; set; }

        public Guid TopicSubforumId { get; set; }

        public Subforum TopicSubforum { get; set; }

        #endregion
    }
}
