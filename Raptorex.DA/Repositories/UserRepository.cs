﻿using Raptorex.BO.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raptorex.DA.Repositories
{
    public class UserRepository : BaseRepository<RaptorexUser>
    {
        public static UserRepository Instance = new UserRepository();


    }
}