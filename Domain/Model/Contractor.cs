using Domain.Common;
using System.Collections.Generic;

namespace Domain.Model
{

    public class Contractor : BaseEntity
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string NumberHome { get; set; }

        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
