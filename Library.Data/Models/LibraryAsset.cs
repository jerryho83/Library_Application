using System.ComponentModel.DataAnnotations;

namespace Library.Data.Models
{
    public class LibraryAsset
    {
        [Required, Display(Name = "Cost of Replacement")]
        public decimal Cost { get; set; }

        public int Id { get; set; }

        public string ImageUrl { get; set; }

        public virtual LibraryBranch Location { get; set; }

        public int NumberOfCopies { get; set; }

        [Required]
        public Status Status { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int Year { get; set; }
    }
}