using System;
using System.ComponentModel.DataAnnotations;

namespace ICT2106project.Models
{
    public class Book
    {
        public int bookID { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string bookTitle { get; set; }

        [Required]
        [Display(Name = "Author")]
        public string bookAuthor { get; set; }

        [RegularExpression(@"^[a-zA-Z]+$")]
        [StringLength(30)]
        [Display(Name = "Genre")]
        public string bookGenre { get; set; }

        [Display(Name = "Description")]
        public string bookDesc { get; set; }

        [Required]
        [Display(Name = "ISBN10")]
        public double bookISBN10 { get; set; }

        [Required]
        [Display(Name = "ISBN13")]
        public double bookISBN13 { get; set; }

        [Display(Name = "Type")]
        public string bookType { get; set; }

        [Display(Name = "Cover Image")]
        public string bookImage { get; set; }

        [Required]
        [Display(Name = "Library Location")]
        public string bookLocation { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        [Display(Name = "Quantity")]
        public int bookQuantity { get; set; }

        [Required]
        [Display(Name = "Availability")]
        public bool bookAvailability { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Of Loan")]
        public DateTime? dateOfLoan { get; set; }
    }
}