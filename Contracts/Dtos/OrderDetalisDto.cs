namespace Contracts.Dtos
{
    public class OrderDetalisDto :BaseDto
    {
        public int Count { get; set; }
        public decimal GrossPrice { get; set; }
        public decimal NettoPrice { get; set; }
        public ArticleDto Article { get; set; }
        public int ArticleId { get; set; }
        public OrderDto Order { get; set; }
        public int? OrderId { get; set; }
    }
}
