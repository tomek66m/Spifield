﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Spifield.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage ="Login jest wymagany")]
        [Display(Name = "Nazwa użytkownika")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Hasło jest wymagane")]
        [Display(Name = "Hasło")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
