using System;
using System.Collections.Generic;

namespace Contracts.Dtos
{
    public class OrderDto :BaseDto
    {
        public Guid Number { get; set; } = Guid.NewGuid();
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public decimal NettoPrice { get; set; }
        public decimal GrossPrice { get; set; }
        public ContractorDto Contractor { get; set; }
        public int ContractorId { get; set; }
        public virtual List<OrderDetalisDto> OrderDetalis { get; set; } = new List<OrderDetalisDto>();
    }
}
