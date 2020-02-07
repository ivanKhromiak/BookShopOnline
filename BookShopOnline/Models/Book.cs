using System.ComponentModel.DataAnnotations;

namespace BookShopOnline.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
    }
}
