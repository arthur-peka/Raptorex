using Raptorex.BO.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raptorex.DA.Configurations
{
    public class BaseConfig<T> : EntityTypeConfiguration<T> where T : BaseEntity
    {
        public BaseConfig(string tableName)
        {
            Map(e => e.ToTable(tableName));
        }
    }
}
