using Domain.Common;
using System;
using System.Collections.Generic;

namespace Domain.Model
{
    public class Order : BaseEntity
    {
        public Guid Number { get; private set; }
        public DateTime OrderDate { get; private set; } = DateTime.Now;
        public decimal NettoPrice { get; private set; }
        public decimal GrossPrice { get; private set; }
        public Contractor Contractor { get; private set; }
        public int ContractorId { get; private set; }
        public virtual List<OrderDetalis> OrderDetalis { get; private set; } = new List<OrderDetalis>();

        public void AddOrderDetalis(OrderDetalis orderDetalis)
        {
            OrderDetalis.Add(orderDetalis);
        }
    }
}
