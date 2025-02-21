using System.ComponentModel.DataAnnotations;

namespace Progetto_S14_L5.Models
{
    public class EditShoesModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Shoes' name is required!")]
        [StringLength(20, ErrorMessage = "Name must be from 2 to 20 characters", MinimumLength = 2)]
        public string? Name { get; set; }

        [Display(Name = "Price")]
        [Required(ErrorMessage = "Shoes' price is required!")]
        [Range(0.01, 1000000, ErrorMessage = "Price must be from €0,01 to €1000000")]
        public double? Price { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Shoes' description is required!")]
        [StringLength(
            200,
            ErrorMessage = "Description must be from 10 to 200 characters",
            MinimumLength = 10
        )]
        public string? Description { get; set; }

        [Display(Name = "Cover picture")]
        public string? MainImage { get; set; }

        [Display(Name = "Other pictures")]
        public List<string> Images { get; set; } = ["", ""];

        // Controllo sull'immagine di copertina
        public void CheckMainImage()
        {
            Random rdn = new();

            if (string.IsNullOrEmpty(MainImage) || string.IsNullOrWhiteSpace(MainImage))
            {
                MainImage = Shoes.shoesImgs[rdn.Next(0, Shoes.shoesImgs.Count)];
            }
        }

        // Controllo sulle immagini aggiuntive
        public void CheckImages()
        {
            Random rdn = new();

            for (int i = 0; i < Images.Count; i++)
            {
                if (string.IsNullOrEmpty(Images[i]) || string.IsNullOrWhiteSpace(Images[i]))
                {
                    Images[i] = Shoes.shoesImgs[rdn.Next(0, Shoes.shoesImgs.Count)];
                }
            }
        }
    }
}
