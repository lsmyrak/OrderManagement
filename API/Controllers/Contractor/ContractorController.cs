using API.Commands;
using API.Queries;
using Contracts.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers.Contractor
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractorController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ContractorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public Task<IEnumerable<ContractorDto>> Contractors()
        {
            return _mediator.Send(new GetContractorQuery());
        }

        [HttpGet("{id}")]
        public Task<ContractorDto> Contractor(int id)
        {
            return _mediator.Send(new GetContractorByIdQuery(id));
        }

        [HttpGet("{filtr}")]
        public async Task<IEnumerable<ContractorDto>> ContractorByFiltr(string filtr)
        {
            return await _mediator.Send(new GetContractorByFilterQuery(filtr));
        }

        [HttpPost]
        public async Task<ActionResult> AddContractor(ContractorDto contractorDto)
        {
            await _mediator.Send(new AddContractorCommand(contractorDto));
            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateContractor(ContractorDto contractorDto)
        {
            await _mediator.Send(new UpdateContractorCommand(contractorDto));
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteContractor(int id)
        {
            await _mediator.Send(new DeleteContractorCommand(id));
            return NoContent();
        }
    }
}
