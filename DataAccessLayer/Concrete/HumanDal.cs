using DataAccessLayer.Abstract;
using EntitiesLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class HumanDal : IHumanDal
    {
        private readonly DataContext _context;

        public HumanDal(DataContext context)
        {
            _context = context;
        }

        public async Task Create(Human entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public IList<Human> GetAll()
        {
            return _context.Set<Human>().ToList();
        }

        
        public Human GetByName(string name)
        {
            return _context.Set<Human>().AsNoTracking().FirstOrDefault(n=> n.Name == name);
        }
    }
}
