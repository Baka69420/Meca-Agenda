using MecaAgenda.Infraestructure.Data;
using MecaAgenda.Infraestructure.Models;
using MecaAgenda.Infraestructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MecaAgenda.Infraestructure.Repository.Implementations
{
    public class RepositoryProduct : IRepositoryProduct
    {
        private readonly MecaAgendaContext _context;

        public RepositoryProduct(MecaAgendaContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Products>> FindByBrandAsync(string brandName)
        {
            var collection = await _context.Set<Products>()
                .Where(x => x.Brand!.Contains(brandName))
                .OrderBy(x => x.ProductId)
                .AsNoTracking()
                .ToListAsync();
            return collection;
        }

        public async Task<ICollection<Products>> FindByNameAsync(string productName)
        {
            var collection = await _context.Set<Products>()
                .Where(x => x.Name!.Contains(productName))
                .OrderBy(x => x.ProductId)
                .AsNoTracking()
                .ToListAsync();
            return collection;
        }

        public async Task<Products> GetAsync(int id)
        {
            var @object = await _context.Set<Products>()
                .Where(x => x.ProductId == id)
                .OrderBy(x => x.ProductId)
                .FirstOrDefaultAsync();
            return @object!;
        }

        public async Task<ICollection<Products>> GetByCategoryAsync(int idCategory)
        {
            var collection = await _context.Set<Products>()
                .Where(x => x.CategoryId == idCategory)
                .OrderBy(x => x.ProductId)
                .AsNoTracking()
                .ToListAsync();
            return collection;
        }

        public async Task<ICollection<Products>> ListAsync()
        {
            var collection = await _context.Set<Products>()
                .OrderBy(x => x.ProductId)
                .AsNoTracking()
                .ToListAsync();
            return collection;
        }
    }
}
