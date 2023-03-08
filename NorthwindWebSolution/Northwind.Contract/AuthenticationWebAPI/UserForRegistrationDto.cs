﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Contract.AuthenticationWebAPI
{
    public class UserForRegistrationDto
    {

        [Required(ErrorMessage = "Username is required")]
        public string? UserName { get; set; }


        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }

        public string? PhoneNumber { get; set; }
    }
}
