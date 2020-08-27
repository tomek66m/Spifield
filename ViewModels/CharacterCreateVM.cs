using Microsoft.AspNetCore.Mvc.Rendering;
using Spifield.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Spifield.ViewModels
{
    public class CharacterCreateVM
    {
        [Required(ErrorMessage="Nazwa postaci jest wymagana")]
        [Display(Name="Postać")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Wybór rasy jest wymagany")]
        public int RaceID { get; set; }

        public List<SelectListItem> RacesList { get; set; }
    }
}
