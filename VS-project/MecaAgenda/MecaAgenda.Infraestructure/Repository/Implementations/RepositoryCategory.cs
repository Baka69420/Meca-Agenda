﻿using MecaAgenda.Infraestructure.Data;
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
    public class RepositoryCategory : IRepositoryCategory
    {
        private readonly MecaAgendaContext _context;

        public RepositoryCategory(MecaAgendaContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(Categories category)
        {
            await _context.Set<Categories>().AddAsync(category);
            await _context.SaveChangesAsync();
            return category.CategoryId;
        }

        public async Task DeleteAsync(int categoryId)
        {
            var categoryToDelete = await GetAsync(categoryId);

            if (categoryToDelete != null)
            {
                _context.Set<Categories>().Remove(categoryToDelete);

                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Category with ID {categoryId} does not exist.");
            }
        }

        public async Task<Categories> GetAsync(int id)
        {
            var @object = await _context.Set<Categories>()
                .Where(x => x.CategoryId == id)
                .OrderBy(x => x.CategoryId)
                .FirstOrDefaultAsync();
            return @object!;
        }

        public async Task<ICollection<Categories>> ListAsync(string categoryName)
        {
            var collection = await _context.Set<Categories>()
                .OrderBy(x => x.CategoryId)
                .AsNoTracking()
                .ToListAsync();

            if (!string.IsNullOrEmpty(categoryName))
                collection = collection.Where(x => x.Name!.Contains(categoryName)).ToList();

            return collection;
        }

        public async Task UpdateAsync(Categories category)
        {
            var categoryToUpdate = await GetAsync(category.CategoryId);

            if (categoryToUpdate != null)
            {
                categoryToUpdate.Name = category.Name;

                _context.Entry(categoryToUpdate).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Category with ID {category.CategoryId} does not exist.");
            }
        }
    }
}
