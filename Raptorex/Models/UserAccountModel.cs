using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Raptorex.Models
{
    public class UserAccountModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string PasswordPlainText { get; set; }

        public string Email { get; set; }

        public byte[] Avatar { get; set; }
    }
}