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

        public async Task<int> AddAsync(Products product)
        {
            await _context.Set<Products>().AddAsync(product);
            await _context.SaveChangesAsync();
            return product.ProductId;
        }

        public async Task DeleteAsync(int productId)
        {
            var productToDelete = await GetAsync(productId);

            if (productToDelete != null)
            {
                _context.Set<Products>().Remove(productToDelete);

                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Product with ID {productId} does not exist.");
            }
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
                .Include(x => x.Category)
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
                .Include(x => x.Category)
                .OrderBy(x => x.ProductId)
                .AsNoTracking()
                .ToListAsync();
            return collection;
        }

        public async Task UpdateAsync(Products product)
        {
            var productToUpdate = await GetAsync(product.ProductId);

            if (productToUpdate != null)
            {
                productToUpdate.Name = product.Name;
                productToUpdate.Description = product.Description;
                productToUpdate.CategoryId = product.CategoryId;
                productToUpdate.Price = product.Price;
                productToUpdate.Brand = product.Brand;
                productToUpdate.StockQuantity = product.StockQuantity;

                _context.Entry(productToUpdate).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Product with ID {product.ProductId} does not exist.");
            }
        }
    }
}
