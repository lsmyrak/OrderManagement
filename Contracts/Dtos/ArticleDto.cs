using System.Collections.Generic;

namespace Contracts.Dtos
{
    public class ArticleDto : BaseDto
    {
        public string Name { get; set; }
        public decimal NettoPrice { get; set; }
        public decimal GrossPrice { get; set; }
        public int Tax { get; set; }
        public List<OrderDetalisDto> OrderDetalis { get; set; } = new List<OrderDetalisDto>();
    }
}
