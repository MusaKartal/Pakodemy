using AutoMapper;
using DataAccessLayer.Abstract;
using EntitiesLayer;
using EntitiesLayer.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class HumanDal : IHumanDal
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public HumanDal(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task Create(Human entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<CacheDto>>GetAll()
        {
            var toList = await _context.Set<Human>().ToListAsync();            
            var dto =  _mapper.Map<List<CacheDto>>(toList);
            return dto;
        }

        public async Task<List<ResponsetwoDto>> GetAllResponsetwo()
        {
            var toList = await _context.Set<Human>().ToListAsync();
            var dto = _mapper.Map<List<ResponsetwoDto>>(toList);
            return dto;
        }

        public Human GetByAge(int age)
        {
            return _context.Set<Human>().AsNoTracking().FirstOrDefault(n => n.Age == age);
        }    

        public HumanDto GetByName(string name)
        {
           var humanGetByName= _context.Set<Human>().AsNoTracking().FirstOrDefault(n => n.Name == name);
            var dto = _mapper.Map<HumanDto>(humanGetByName);
            return dto;
        }
    }
}
