using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class BookLoan
    {
        [Key]
        public int BookLoanID { get; set; }

        [Display(Name = "کتاب")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        public int PageID { get; set; }
        //[Display(Name = "گروه کتاب")]
        ////[Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        //public int? GroupID { get; set; }
        [Display(Name = "نام عضو")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        public int UserID { get; set; }
        //[DisplayFormat(DataFormatString = "{0: yyyy/MM/dd}")]
        public DateTime LoanFrom { get; set; }
        //[DisplayFormat(DataFormatString = "{0: yyyy/MM/dd}")]
        [Display(Name = "تاریخ برگشت")]
        public DateTime? LoanUntill { get; set; }
        [Display(Name = "تاریخ بازگشت")]
        public DateTime? ReturnedOn { get; set; }
        //public virtual List<User> Users { get; set; }
        //public virtual List<Page> Pages { get; set; }
        public virtual Page Pages { get; set; }
        public virtual User User { get; set; }
        //[Display(Name = "کد شخصی که کتاب را به امانت برده")]
        //[Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        //public int BorrowPersonID { get; set; }

        //public DateTime IssuedOn { get; set; }

        //public DateTime? ReturnedOn { get; set; }

        //public DateTime DueDate { get; set; }

        //public double? PenaltyCharges { get; set; }

        //public bool IsOverdue
        //{
        //    get
        //    {
        //        return LoanUntill < DateTime.Now && ReturnedDate == null;
        //    }
        //}
    }
}
