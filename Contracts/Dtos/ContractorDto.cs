using System.Collections.Generic;

namespace Contracts.Dtos
{
    public class ContractorDto : BaseDto
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string NumberHome { get; set; }
        public List<OrderDto> Orders { get; set; } = new List<OrderDto>();
    }
}
