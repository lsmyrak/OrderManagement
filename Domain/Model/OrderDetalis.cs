using Domain.Common;

namespace Domain.Model
{
    public class OrderDetalis : BaseEntity
    {
        public int Count { get; set; }
        public decimal GrossPrice { get; set; }
        public decimal NettoPrice { get; set; }

        public Article Article { get; set; }
        public int ArticleId { get; set; }

        public Order Order { get; set; }
        public int? OrderId { get; set; }
    }
}
