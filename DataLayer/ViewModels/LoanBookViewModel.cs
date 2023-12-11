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

        public int revivalCount { get; set; }
    }
}
