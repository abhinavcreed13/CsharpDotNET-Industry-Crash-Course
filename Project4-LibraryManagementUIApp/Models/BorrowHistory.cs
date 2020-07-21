using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Session3_LibraryManagementUIApp.Models
{
    public class BorrowHistory
    {
        [Key]
        public int BorrowHistoryId { get; set; }

        [Required]
        [Display(Name = "Book")]
        //Foreign Key
        public int BookId { get; set; }

        //Navigation properties
        public Book Book { get; set; }

        [Required]
        [Display(Name = "Customer")]
        //Foreign Key
        public int CustomerId { get; set; }

        //Navigation properties
        public Customer Customer { get; set; }

        [Display(Name = "Borrow Date")]
        public DateTime BorrowDate { get; set; }

        [Display(Name = "Return Date")]
        public DateTime? ReturnDate { get; set; }
    }
}