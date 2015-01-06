using Raptorex.BO.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raptorex.DA.Configurations
{
    public class UserConfig : BaseConfig<RaptorexUser>
    {
        public UserConfig() : base("Users") 
        {
            Property(u => u.Username)
                .IsRequired()
                .HasMaxLength(512)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("IX_Username") { IsUnique = true }));

            //Yes, I know it should be 254 (as IETF says)!
            //However, originally it was 320, and there certainly are non-compliant addresses, so let's keep it 320
            Property(u => u.Email)
                .HasMaxLength(320); 
        }
    }
}
