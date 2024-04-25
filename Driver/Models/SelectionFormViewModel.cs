using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Driver.Models
{
    public class SelectionFormViewModel
    {
        [Required]
        public int BusNumberId { get; set; }

        [Required]
        public int NameId { get; set; }

        [Required]
        public int LoopId { get; set; }

        public List<SelectListItem> BusNumbers { get; set; }

        public List<SelectListItem> Names { get; set; }

        public List<SelectListItem> Loops { get; set; }
    }
}