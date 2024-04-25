using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Driver.Models
{
    public class SelectionFormViewModel
    {
        public IEnumerable<SelectListItem> BusNumbers { get; set; }
        public IEnumerable<SelectListItem> FirstNames { get; set; }
        public IEnumerable<SelectListItem> LoopNames { get; set; }
    }
}