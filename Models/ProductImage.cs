using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations.Schema;

namespace W23G72.Models
{
    public class ProductImage
    {
        public int Id { get; set; }
        [Required]
        public string ImageURL { get; set; }
        [ForeignKey("ProductId")]
        public int ProductId { get; set; }
    }
}
