using System;

namespace Library.Data.Models
{
    public class Hold
    {
        public DateTime HoldPlaced { get; set; }
        public int Id { get; set; }
        public virtual LibraryAsset LibraryAsset { get; set; }
        public virtual LibraryCard LibraryCard { get; set; }
    }
}