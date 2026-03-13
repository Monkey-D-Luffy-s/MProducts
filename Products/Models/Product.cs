using System.ComponentModel.DataAnnotations;

namespace Products.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int InStock { get; set; }
    }
}
