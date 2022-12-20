using Contracts.Dtos;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace API.Services
{
    public interface IContractorService
    {
        Task Add(ContractorDto contractorDto);
        Task<ContractorDto> Get(int id);
        Task<IEnumerable<ContractorDto>> GetAll();
        Task Delete(int id);
        Task Update(ContractorDto contractorDto);
        Task<IEnumerable<ContractorDto>> GetBy(Expression<Func<Contractor, bool>> predycate);
    }
}
