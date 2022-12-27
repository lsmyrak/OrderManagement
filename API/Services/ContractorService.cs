using API.Repositories;
using API.Services.Interfaces;
using AutoMapper;
using Contracts.Dtos;
using Domain.Model;
using Microsoft.AspNetCore.Components.RenderTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
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

        public async Task Add(ContractorDto contractorDto, CancellationToken cancellationToken)
        {
            await _contractorRepository.Insert(_mapper.Map<Contractor>(contractorDto),cancellationToken);
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            await _contractorRepository.Delete(id,cancellationToken);
        }

        public async Task<ContractorDto> Get(int id,CancellationToken cancellationToken)
        {
            return _mapper.Map<ContractorDto>(await _contractorRepository.Get(id,cancellationToken));
        }

        public async Task<IEnumerable<ContractorDto>> GetAll(CancellationToken cancellationToken)
        {
            var contractors = await _contractorRepository.GetAll(cancellationToken);
            return contractors.Select(x => _mapper.Map<ContractorDto>(x));
        }

        public async Task<IEnumerable<ContractorDto>> GetBy(Expression<Func<Contractor, bool>> predycate,CancellationToken cancellationToken)
        {
            var contractors = await _contractorRepository.GetBy(predycate,cancellationToken);
            return contractors.Select(x => _mapper.Map<ContractorDto>(x));
        }

        public async Task<IEnumerable<ContractorDto>> GetByFilter(string filter, CancellationToken cancellationToken)
        {
            var contractors = await _contractorRepository.GetAll(cancellationToken);
            var searchcontractor = contractors.Where(x=>x.City.Contains(filter) || x.Name.Contains(filter));
            return searchcontractor.Select(x => _mapper.Map<ContractorDto>(x));

        }

        public async Task Update(ContractorDto contractorDto,CancellationToken cancellationToken)
        {
            var contractorSrc = await  _contractorRepository.Get(contractorDto.Id, cancellationToken);
            var contractor = _mapper.Map<ContractorDto,Contractor>(contractorDto,contractorSrc);
            await _contractorRepository.Update(contractor,cancellationToken);
        }
    }
}
