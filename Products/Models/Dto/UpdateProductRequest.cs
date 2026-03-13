namespace Products.Models.Dto
{
    public class UpdateProductRequest
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int InStock { get; set; }
    }
}
