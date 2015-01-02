﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raptorex.BO.Entities
{
    /// <summary>
    /// Hierarchy: Subforum -> Topic -> Post
    /// </summary>
    public class ForumPost : CreatedEntity
    {
        public string Text { get; set; }

        #region Navigation

        public Guid MessageTopicId { get; set; }

        public ForumTopic MessageTopic { get; set; }

        #endregion
    }
}
