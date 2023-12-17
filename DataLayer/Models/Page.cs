﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Web.Mvc;
//using System.Web.Mvc.AllowHtmlAttribute;

namespace DataLayer
{
    public class Page
    {
        [Key]
        public int PageID { get; set; }
        [Display(Name = "گروه کتاب")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        public int GroupID { get; set; }
        [Display(Name = "عنوان کتاب")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [MaxLength(250)]
        public string Title { get; set; }
        [Display(Name = "مولف کتاب")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [MaxLength(250)]
        public string Author { get; set; }


        [Display(Name = "توضیح مختصر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [MaxLength(350)]
        [DataType(DataType.MultilineText)]
        public string ShortDescription { get; set; }

        [Display(Name = "متن")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [DataType(DataType.MultilineText)]
        //[AllowHtml()]
        public string Text { get; set; }
        [Display(Name = "بازدید")]
        public int Visit { get; set; } 
        [Display(Name = "تعداد موجودی")]
        public int? AvailableCount { get; set; }
        [Display(Name = "تعداد امانت")]
        public int? BorrowCount { get; set; }
        [Display(Name = "تصویر")]
        public string ImageName { get; set; }
        [Display(Name = "اسلایدر")]
        public bool ShowInSlider { get; set; }
        [Display(Name = "تاریخ انتشار")]
        [DisplayFormat(DataFormatString = "{0: yyyy/MM/dd}")]
        public DateTime CreateDate { get; set; }
        //public int BorrowCount { get; set; }
        //[Display(Name = "تعداد امانت برده شده")]
        //[Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [Display(Name = "کلمات کلیدی")]
        public string Tags { get; set; }

        public virtual PageGroup PageGroup { get; set; }
        public virtual List<BookLoan> bookLoans { get; set; }
        public virtual BookLoan bookLoan { get; set; }
        //public virtual Authors Authors { get; set; }

        public virtual List<PageComment> PageComments { get; set; }
        //public virtual List<Loan> Loan { get; set; }
        public virtual List<User> User { get; set; }

        public Page()
        {

        }
    }
}
