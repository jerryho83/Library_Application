using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Library.Data;
using Library.Service;
using Library.Models.Catalog;
namespace Library.Controllers
{
    public class CatalogController : Controller
    {
        private ILibraryAssets _assets;
        public CatalogController(ILibraryAssets assets)
        {
            this._assets = assets;
        }
        public IActionResult Index()
        {
            var assetModels = _assets.GetAll();
            var listingResult = assetModels.
                Select(result => new AssetIndexListingModel
                {
                    Id = result.Id,
                    ImageUrl = result.ImageUrl,
                    AuthorOrDirector = _assets.GetAuthorOrDirector(result.Id),
                    Dewey = _assets.GetDeweyIndex(result.Id),
                    Title = _assets.GetTitile(result.Id),
                    Type = _assets.GetType(result.Id)

                });
            var model = new AssetIndexModel()
            {
                Assets = listingResult
            };
            return View(model);
        }
        public IActionResult Detail(int id)
        {
            var asset = _assets.GetById(id);
            var model = new AssetDetailModel()
            {
                AssetId = asset.Id,
                Title = asset.Title,
                AuthorOrDirector = _assets.GetAuthorOrDirector(asset.Id),
                Type = _assets.GetType(asset.Id),
                IBSN = _assets.GetISBN(asset.Id),
                ImageUrl = asset.ImageUrl,
                DeweyCallNumber = _assets.GetDeweyIndex(asset.Id),
                Cost = asset.Cost,
                Year = asset.Year,
                Status = asset.Status.Name,
                CurrentLocation = _assets.GetCurrentLocation(asset.Id).Name
            };

            return View(model);
        }
    }
}
