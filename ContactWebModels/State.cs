using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactWebModels
{
    public class State
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Name is required")]
        [Display(Name ="State")]
        [StringLength(ContactsManagerConstants.MAX_STATE_LENGTH)]
        public String Name { get; set; }

        [Required(ErrorMessage ="State abbreviation is required")]
        [StringLength(ContactsManagerConstants.MIN_STATE_ABBR_LENGTH)]
        public String Abbreviation { get; set; }
    }
}
