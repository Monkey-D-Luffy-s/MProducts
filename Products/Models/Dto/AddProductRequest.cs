namespace Products.Models.Dto
{
    public class AddProductRequest
    {
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int InStock { get; set; }
    }
}
