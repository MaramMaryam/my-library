using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Loan
    {
        [Key]
        public int LoanID { get; set; }
        public int PageID { get; set; }
        public int PageGroupID { get; set; }

        public int UserID { get; set; }

        //[Display(Name = "کد ملی")]
        //[Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        //[MaxLength(250)]
        //public int Code { get; set; }

        [Display(Name = "از")]
        [DisplayFormat(DataFormatString = "{0: yyyy/MM/dd}")]
        public DateTime LoanFrom { get; set; }

        [Display(Name = "تا")]
        [DisplayFormat(DataFormatString = "{0: yyyy/MM/dd}")]
        public DateTime LoanUntill { get; set; }
        public virtual List<Page> Page { get; set; }
        public virtual PageGroup PageGroup { get; set; }

        public virtual List<User> User { get; set; }
        public Loan()
        {

        }
    }
}
