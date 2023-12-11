using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Authors
    {
        [Key]
        public int AuthorId { get; set; }
        [Display(Name = "نام و نام خانوادگی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [MaxLength(250)]
        public string FullName { get; set; }

        public virtual List<Page> Page { get; set; }
        public Authors()
        {

        }
    }
}
