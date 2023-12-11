using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Return
    {
        [Key]
        public int ReturnID { get; set; }
        public int LoanID { get; set; }
        public int PageID { get; set; }
        public int PageGroupID { get; set; }

        public int UserID { get; set; }

        [DisplayFormat(DataFormatString = "{0: yyyy/MM/dd}")]
        public DateTime ReturnedDate { get; set; }
        public string Status { get; set; } // Damaged? Late?
        public double PenalityFee { get; set; }


        public virtual List<Page> Page { get; set; }
        public virtual PageGroup PageGroup { get; set; }

        public virtual List<User> User { get; set; }
        public Return()
        {

        }
    }
}
