﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebStokTakip.Models.Identity
{
    public class Login
    {
        [Required(ErrorMessage = "Bu alan zorunludur")]
        [DisplayName("Kullanıcı Adı")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Bu alan zorunludur")]
        [DisplayName("Şifre")]
        public string Password { get; set; }

        [DisplayName("Beni Hatırla")]
        public bool RememberMe { get; set; }
    }
}