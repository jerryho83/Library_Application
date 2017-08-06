using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.Data.Models
{
    public class LibraryBranch
    {
        [Required]
        public string Address { get; set; }

        public string Description { get; set; }
        public int Id { get; set; }

        public string ImageUrl { get; set; }

        public virtual IEnumerable<LibraryAsset> LibraryAssets { get; set; }

        [Required, Display(Name = "Branch Name")]
        [StringLength(30, ErrorMessage = "Limit branch name to 30 characters.")]
        public string Name { get; set; }
        public DateTime OpenDate { get; set; }

        public virtual IEnumerable<Patron> Patrons { get; set; }

        [Required]
        public string Telephone { get; set; }
    }
}