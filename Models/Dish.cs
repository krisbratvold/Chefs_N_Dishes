using System;
using System.ComponentModel.DataAnnotations;

namespace Chefs_N_Dishes.Models
{
public class Dish
    {
        [Key]
        public int DishId { get; set; }
        [Required(ErrorMessage="is required")]
        [Display(Name = "Name of Dish")]
        public string Name { get; set; }

        [Required(ErrorMessage="is required")]
        public int Tastiness { get; set; }

        [Required(ErrorMessage="is required")]
        [Display(Name = "# of Calories")]
        [Range(1,100000,ErrorMessage="calories must be greater than 0")]
        public int Calories { get; set; }

        [Required(ErrorMessage="is required")]
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        [Display(Name = "Chef")]
        public int ChefId { get; set; }
        public Chef Creator { get; set; }
    }
}