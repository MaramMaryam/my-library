using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [MaxLength(250)]
        public string FullName { get; set; }

        [Display(Name = "کد ملی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        public int Code { get; set; }

        [Display(Name = "تاریخ عضویت")]
        [DisplayFormat(DataFormatString = "{0: yyyy/MM/dd}")]
        public DateTime CreateDate { get; set; }

        [Display(Name = "تلفن")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [MaxLength(350)]
        public string Tel { get; set; }


        [Display(Name = "پست الکترونیک")]
        [MaxLength(350)]
        public string Email { get; set; }

        public virtual List<Page> Page { get; set; }
        public virtual List<Loan> Loan { get; set; }
        //public virtual PageGroup PageGroup { get; set; }

        public User()
        {

        }
    }
}
