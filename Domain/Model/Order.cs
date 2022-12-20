using Domain.Common;
using System;
using System.Collections.Generic;

namespace Domain.Model
{
    public class Order : BaseEntity
    {
        public Guid Number { get; set; } = Guid.NewGuid();
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public decimal NettoPrice { get; set; }
        public decimal GrossPrice { get; set; }
        public Contractor Contractor { get; set; }
        public int ContractorId { get; set; }
        public virtual List<OrderDetalis> OrderDetalis { get; set; } = new List<OrderDetalis>();
    }
}
