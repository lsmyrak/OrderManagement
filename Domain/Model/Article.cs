using Domain.Common;
using System.Collections.Generic;

namespace Domain.Model
{
    public class Article : BaseEntity
    {
        public string Name { get; set; }
        public decimal NettoPrice { get; set; }
        public decimal GrossPrice { get; set; }
        public int Tax { get; set; }
        public List<OrderDetalis>? OrderDetalis { get; set; } = new List<OrderDetalis>();


    }
}
