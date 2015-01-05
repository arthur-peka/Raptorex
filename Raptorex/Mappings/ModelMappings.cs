using AutoMapper;
using Raptorex.BO.Entities;
using Raptorex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace Raptorex.Mappings
{
    public static class ModelMappings
    {
        public static void Create()
        {
            Mapper.CreateMap<UserAccountModel, RaptorexUser>()
                .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => Crypto.HashPassword(src.PasswordPlainText)));
        }
    }
}