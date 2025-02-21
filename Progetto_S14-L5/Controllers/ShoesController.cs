using Microsoft.AspNetCore.Mvc;
using Progetto_S14_L5.Models;

namespace Progetto_S14_L5.Controllers
{
    public class ShoesController : Controller
    {
        public static List<Shoes> shoes =
        [
            new()
            {
                Id = Guid.Parse("4f3acffc-7f94-4256-8ba3-c8bd7f3ddd72"),
                Name = "Zoom Pogo Plus",
                Price = 67.99,
                Description = "Flat sneakers",
                MainImage =
                    "https://img01.ztat.net/article/spp-media-p1/c026b73e01bc484891ec5ddf33583dc9/006314e48be74e5a89cd75e11318b5b2.jpg?imwidth=400",
                Images =
                [
                    "https://img01.ztat.net/article/spp-media-p1/0e3c12b5784443708c5a2c9c538481d6/6c3dcd65ca5d4365be5abf72f9ec8aac.jpg?imwidth=400",
                    "https://img01.ztat.net/article/spp-media-p1/8aaf97aebf984d00aa6ca341acfd8bca/9a189c4bbd294b9ba57cddfaf8d2f06d.jpg?imwidth=400",
                ],
            },
            new()
            {
                Id = Guid.Parse("10af765c-008c-453f-829e-874efe001f50"),
                Name = "Air Force",
                Price = 107.99,
                Description = "White flat sneakers",
                MainImage =
                    "https://img01.ztat.net/article/spp-media-p1/553c5bd966ed3085afe815aed8fae88a/e3e7c98e73a1467a866815e8ffc1315e.jpg?imwidth=400",
                Images =
                [
                    "https://img01.ztat.net/article/spp-media-p1/3beab105f6ee325d99e322e9b0e7dc7e/aaf05e38fce74b32812fd51ed9be421a.jpg?imwidth=400",
                    "https://img01.ztat.net/article/spp-media-p1/7ea1adc8e2413519aa0f1b107cd9036b/b0fc9185c02745619913ab6ae2cc6a20.jpg?imwidth=400",
                ],
            },
            new()
            {
                Id = Guid.Parse("097d0d73-72b1-4828-8efc-3aedcf192af8"),
                Name = "Samba OG",
                Price = 119.95,
                Description = "Cream and white flat sneakers",
                MainImage =
                    "https://img01.ztat.net/article/spp-media-p1/b390e3e3654c47c9b7e2b3925b6479c6/a21d1d0ca7fe429c8dde422890b6dc50.jpg?imwidth=400",
                Images =
                [
                    "https://img01.ztat.net/article/spp-media-p1/839ec20373d64d12977130975f9b27c1/3a48a469fa82496ea2eb896a2b84523e.jpg?imwidth=400",
                    "https://img01.ztat.net/article/spp-media-p1/e7aa64a79dda470db2359fad45d54063/33e14fec84d1450f9828f07960f2e682.jpg?imwidth=400",
                ],
            },
        ];

        public IActionResult Index()
        {
            return View(new ShoesListModelView() { Shoes = shoes });
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddShoes(AddShoesModel addShoesModel)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Check datas, something went wrong!";
                return RedirectToAction("Add");
            }

            addShoesModel.CheckMainImage();

            addShoesModel.CheckImages();

            shoes.Add(
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = addShoesModel.Name,
                    Price = addShoesModel.Price,
                    Description = addShoesModel.Description,
                    MainImage = addShoesModel.MainImage,
                    Images = addShoesModel.Images,
                }
            );

            TempData["Message"] = "All right! Shoes added to catalogue!";

            return RedirectToAction("Index");
        }

        [HttpGet("/shoes/details/{id:guid}")]
        public IActionResult Details(Guid id)
        {
            var selectedShoes = shoes.FirstOrDefault(s => s.Id == id);

            if (selectedShoes != null)
            {
                var shoesFound = new ShoesModelView()
                {
                    Id = selectedShoes.Id,
                    Name = selectedShoes.Name,
                    Price = selectedShoes.Price,
                    Description = selectedShoes.Description,
                    MainImage = selectedShoes.MainImage,
                    Images = selectedShoes.Images,
                };

                return View(shoesFound);
            }
            else
            {
                TempData["Message"] = "Something gone wrong! Try again!";

                return RedirectToAction("Index");
            }
        }

        [HttpGet("/remove/{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            var selectedShoes = shoes.FirstOrDefault(s => s.Id == id);

            if (selectedShoes == null)
            {
                return RedirectToAction("Index");
            }

            if (shoes.Remove(selectedShoes))
            {
                TempData["Message"] = "Shoes removed successfully!";

                return RedirectToAction("Index");
            }
            else
            {
                TempData["Message"] = "Something gone wrong! Try again!";

                return RedirectToAction("Index");
            }
        }

        [HttpGet("/edit/{id:guid}")]
        public IActionResult Edit(Guid id)
        {
            var selectedShoes = shoes.FirstOrDefault(s => s.Id == id);

            if (selectedShoes == null)
            {
                return RedirectToAction("Index");
            }

            var editShoes = new EditShoesModel()
            {
                Id = selectedShoes.Id,
                Name = selectedShoes.Name,
                Price = selectedShoes.Price,
                Description = selectedShoes.Description,
                MainImage = selectedShoes.MainImage,
                Images = selectedShoes.Images,
            };

            return View(editShoes);
        }

        [HttpPost("edit/{id:guid}")]
        public IActionResult EditShoes(EditShoesModel editShoesModel, Guid id)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Check datas, something went wrong!";
                return RedirectToAction("Add");
            }

            var selectedShoes = shoes.FirstOrDefault(s => s.Id == id);

            if (selectedShoes == null)
            {
                TempData["Message"] = "Something gone wrong! Try again!";

                return RedirectToAction("Edit");
            }

            editShoesModel.CheckMainImage();

            editShoesModel.CheckImages();

            selectedShoes.Name = editShoesModel.Name;
            selectedShoes.Price = editShoesModel.Price;
            selectedShoes.Description = editShoesModel.Description;
            selectedShoes.MainImage = editShoesModel.MainImage;
            selectedShoes.Images = editShoesModel.Images;

            TempData["Message"] = "Shoes edited successfully!";

            return RedirectToAction("Index");
        }
    }
}
