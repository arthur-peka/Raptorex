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
    public class Subforum : BaseEntity
    {
        [Required]
        [MaxLength(3000)]
        public string Title { get; set; }


        #region Navigation

        public ICollection<ForumTopic> Topics { get; set; }

        #endregion
    }
}
