using System.ComponentModel.DataAnnotations;

namespace Progetto_S14_L5.Models
{
    public class AddShoesModel
    {
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
    }
}
