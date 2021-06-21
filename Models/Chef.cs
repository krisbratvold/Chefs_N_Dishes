using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Chefs_N_Dishes.Models
{
    public class Chef
    {
        [Key]
        public int ChefId { get; set; }
        [Required(ErrorMessage="is required")]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage="is required")]
        [Display(Name ="Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage="is required")]
        [DataType(DataType.Date)]
        [Display(Name ="Date of Birth")]
        public DateTime Birthday { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public List<Dish> CreatedDishes { get; set; }
    }
}