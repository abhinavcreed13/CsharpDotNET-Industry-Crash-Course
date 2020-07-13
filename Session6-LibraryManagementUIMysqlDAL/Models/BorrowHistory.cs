using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Session6_LibraryManagementUIMysqlDAL.Models
{
    public class BorrowHistory
    {
        [Key]
        public int BorrowHistoryId { get; set; }

        [Required]
        [Display(Name = "Book")]
        //Foreign Key
        public int BookId { get; set; }

        public string BookTitle { get; set; }

        [Required]
        [Display(Name = "Customer")]
        //Foreign Key
        public int CustomerId { get; set; }

        public string CustomerName { get; set; }

        [Display(Name = "Borrow Date")]
        public DateTime BorrowDate { get; set; }

        [Display(Name = "Return Date")]
        public DateTime? ReturnDate { get; set; }
    }
}