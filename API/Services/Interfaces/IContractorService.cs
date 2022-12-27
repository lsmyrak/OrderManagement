using Contracts.Dtos;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace API.Services.Interfaces
{
    public interface IContractorService
    {
        Task Add(ContractorDto contractorDto, CancellationToken cancellationToken);
        Task<ContractorDto> Get(int id, CancellationToken cancellationToken);
        Task<IEnumerable<ContractorDto>> GetAll(CancellationToken cancellationToken);
        Task Delete(int id, CancellationToken cancellationToken);
        Task Update(ContractorDto contractorDto, CancellationToken cancellationToken);
        Task<IEnumerable<ContractorDto>> GetBy(Expression<Func<Contractor, bool>> predycate, CancellationToken cancellationToken);
        Task<IEnumerable<ContractorDto>> GetByFilter(string filter,CancellationToken cancellationToken);
    }
}
