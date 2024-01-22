using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bulky.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }

        [ForeignKey("ProductId")]
        public int ProductId { get; set; }
        [ValidateNever]
        public Product Product { get; set; }

        public int Count { get; set; }

        [ForeignKey("ApplicationUserId")]
        public string ApplicationUserId { get; set; }

        [ValidateNever]
        public ApplicationUser ApplicationUser { get; set; }

        [NotMapped]
        public double Price { get; set; }

    }
}
