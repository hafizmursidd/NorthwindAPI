using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Contract.Model
{
    public class SupplierDto
    {
        //public int SupplierId { get; set; }

        [Display(Name ="Suplier Name")]
        [Required]
        [StringLength (50, ErrorMessage ="Length company name too many")]
        public string? CompanyName { get; set; }

        [Required]
        public string? Address { get; set; }
    }
}
