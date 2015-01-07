using Raptorex.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raptorex.Tests.Fixtures
{
    public class BaseFixture : IDisposable
    {
        public BaseFixture()
        {
            ModelMappings.Create();
        }

        public void Dispose()
        {
            
        }
    }
}
