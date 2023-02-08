using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Contract.Model
{
    public class RegionDto
    {
        [Required(ErrorMessage = "Region id is required")]
        public int RegionId { get; set; }

        [Required]
        [MinLength(5, ErrorMessage ="Region Desc must larger 5")]
        [MaxLength(50, ErrorMessage ="Region Desc is too many")]
        public string? RegionDescription { get; set; }
    }
}
