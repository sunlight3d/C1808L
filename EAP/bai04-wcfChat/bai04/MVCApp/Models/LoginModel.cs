﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCApp.Models
{
    public class LoginModel
    {
        public String UserName { get; set; }
        public String Password { get; set; }
        public bool RememberMe { get; set; }
    }
}