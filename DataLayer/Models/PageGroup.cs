using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class PageGroup
    {
        [Key]
        public int GroupID { get; set; }
        [Display(Name = "عنوان گروه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [MaxLength(150)]
        public string GroupTitle { get; set; }
        [Display(Name = "تصویر گروه")]
        //[Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        //[MaxLength(150)]
        public string GroupImgName { get; set; }
        //Navigation property
        public virtual List<Page> Pages { get; set; }
        public PageGroup()
        {
            
        }
    }
}
