using LibraryShared.CustomValidations;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace LibraryShared
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Title is required for the book!")]
        [MaxLength(50,ErrorMessage ="Title of the book is too long!")]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        [ValidDate(ErrorMessage ="Date of publication is wrong!")]
        public DateTime DateOfPublication { get; set; }
    }
}