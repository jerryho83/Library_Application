using Library.Data.Models;
using System.Collections.Generic;

namespace Library.Data
{
    public interface ILibraryAssets
    {
        void Add(LibraryAsset newAssets);

        IEnumerable<LibraryAsset> GetAll();

        string GetAuthorOrDirector(int id);

        LibraryAsset GetById(int id);

        string GetDeweyIndex(int id);

        string GetISBN(int id);

        string GetTitile(int id);

        string GetType(int id);
        LibraryBranch GetCurrentLocation(int id);

    }
}