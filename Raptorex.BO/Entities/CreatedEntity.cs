using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raptorex.BO.Entities
{
    public class CreatedEntity : BaseEntity
    {
        public RaptorexUser CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
