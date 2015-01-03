using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Raptorex.Models
{
    public class UserAccountModel
    {
        public string Username { get; set; }

        public string PasswordPlainText { get; set; }

        public string Email { get; set; }

        public byte[] Avatar { get; set; }
    }
}