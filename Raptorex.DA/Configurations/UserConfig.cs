﻿using Raptorex.BO.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raptorex.DA.Configurations
{
    public class UserConfig : BaseConfig<RaptorexUser>
    {
        public UserConfig() : base("User") { }
    }
}
