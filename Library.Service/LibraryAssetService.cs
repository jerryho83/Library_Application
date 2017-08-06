using Library.Data;
using Library.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Library.Service
{
    public class LibraryAssetService : ILibraryAssets
    {
        private LibraryContext _context;

        public LibraryAssetService(LibraryContext context)
        {
            this._context = context;
        }

        public void Add(LibraryAsset newAssets)
        {
            _context.Add(newAssets);
            _context.SaveChanges();
        }

        public IEnumerable<LibraryAsset> GetAll()
        {
            return _context.LibraryAssets.
                    Include(asset => asset.Status).
                    Include(asset => asset.Location);
        }

        public string GetAuthorOrDirector(int id)
        {
            //check if this is book
            var isBook = _context.LibraryAssets.OfType<Book>()
               .Where(a => a.Id == id).Any();
            //check if this is video
            var isVideo = _context.LibraryAssets.OfType<Video>()
                .Where(a => a.Id == id).Any();

            return isBook ?
                _context.Books.FirstOrDefault(a => a.Id == id).Author :
                _context.Videos.FirstOrDefault(a => a.Id == id).Director
                ?? "Unknown";
        }

        public LibraryAsset GetById(int id)
        {
            return GetAll().FirstOrDefault(asset => asset.Id == id);
        }

        public LibraryBranch GetCurrentLocation(int id)
        {
            return GetById(id).Location;
        }

        public string GetDeweyIndex(int id)
        {
            if (_context.Books.Any(book => book.Id == id))
            {
                return _context.Books.
                        FirstOrDefault(book => book.Id == id).DeweyIndex;
            }
            else
                return "";
        }

        public string GetISBN(int id)
        {
            if (_context.Books.Any(a => a.Id == id))
            {
                return _context.Books
                    .FirstOrDefault(a => a.Id == id).ISBN;
            }
            else return "";
        }

        public string GetTitile(int id)
        {
            return _context.LibraryAssets.FirstOrDefault(a => a.Id == id).Title;
        }

        public string GetType(int id)
        {
            var books = _context.LibraryAssets
                .OfType<Book>().Where(a => a.Id == id);

            return books.Any() ? "Book" : "Video";
        }
    }
}