using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Collections;

namespace ICT2106project.Models
{
    public class Loan
    {
        public int LoanID { get; set; }
        
        [DataType(DataType.Date)]
        [Display(Name = "Date of Loan")]
        public DateTime? dateOfLoan { get; set; }
        
        [DataType(DataType.Date)]
        [Display(Name = "Date of Return")]
        public DateTime? dateOfReturn { get; set; }
        
        [Display(Name = "Loan Quantity")]
        public int? loanQuantity { get; set; }
        
        [Display(Name = "Loan Status")]
        public String loanStatus { get; set; }

        public List<Book> books { get; set; }
    }
}