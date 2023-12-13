using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class LoanBookViewModel
    {
        public int PageId { get; set; }
        public int PageGroupID { get; set; }

        public int UserId { get; set; }
        public int LoanId { get; set; }

        [DisplayFormat(DataFormatString = "{0: yyyy/MM/dd}")]
        public DateTime ReturnedDate { get; set; }

        public DateTime LoanFrom { get; set; }

        public DateTime LoanUntill { get; set; }



        [Display(Name = "تعداد موجودی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        public int AvailableCount { get; set; }
        [Display(Name = "کد شخصی که کتاب را به امانت برده")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        public int BorrowPersonID { get; set; }
        [Display(Name = "امانت هست؟")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        public bool IsBorrow { get; set; }
        [Display(Name = "تاریخ امانت")]
        [DisplayFormat(DataFormatString = "{0: yyyy/MM/dd}")]
        public string BorrowedDate { get; set; }

        [Display(Name = "تعداد دفعاتی که امانت رفته")]
        public int LoanCount { get; set; }

        [Display(Name = "تعداد دفعات تمدید")]
        public int revivalCount { get; set; }
    }
}
