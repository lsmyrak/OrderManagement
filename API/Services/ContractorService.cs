using API.Repositories;
using AutoMapper;
using Contracts.Dtos;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace API.Services
{
    public class ContractorService : IContractorService
    {
        private readonly IRepository<Contractor> _contractorRepository;
        private IMapper _mapper;

        public ContractorService(IRepository<Contractor> contractorRepository, IMapper mapper)
        {
            _contractorRepository = contractorRepository;
            _mapper = mapper;
        }

        public async Task Add(ContractorDto contractorDto)
        {
            await _contractorRepository.Insert(_mapper.Map<Contractor>(contractorDto));
        }

        public async Task Delete(int id)
        {
            await _contractorRepository.Delete(id);
        }

        public async Task<ContractorDto> Get(int id)
        {
            return _mapper.Map<ContractorDto>(await _contractorRepository.Get(id));
        }

        public async Task<IEnumerable<ContractorDto>> GetAll()
        {
            var contractors = await _contractorRepository.GetAll();
            return contractors.Select(x => _mapper.Map<ContractorDto>(x));
        }

        public async Task<IEnumerable<ContractorDto>> GetBy(Expression<Func<Contractor, bool>> predycate)
        {
            var contractors = await _contractorRepository.GetByFilter(predycate);
            return contractors.Select(x => _mapper.Map<ContractorDto>(x));
        }

        public async Task Update(ContractorDto contractorDto)
        {
            var contractor = _mapper.Map<Contractor>(contractorDto);
            await _contractorRepository.Update(contractor);
        }
    }
}
