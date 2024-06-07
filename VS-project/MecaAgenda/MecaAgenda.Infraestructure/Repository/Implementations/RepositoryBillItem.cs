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
    public class RepositoryBillItem : IRepositoryBillItem
    {
        private readonly MecaAgendaContext _context;

        public RepositoryBillItem(MecaAgendaContext context)
        {
            _context = context;
        }

        public async Task<BillItems> GetAsync(int id)
        {
            var @object = await _context.Set<BillItems>()
                .Where(x => x.BillItemId == id)
                .OrderBy(x => x.BillItemId)
                .FirstOrDefaultAsync();
            return @object!;
        }

        public async Task<ICollection<BillItems>> GetByBillAsync(int idBill)
        {
            var collection = await _context.Set<BillItems>()
                .Where(x => x.BillId == idBill)
                .OrderBy(x => x.BillItemId)
                .AsNoTracking()
                .ToListAsync();
            return collection;
        }

        public async Task<ICollection<BillItems>> ListAsync()
        {
            var collection = await _context.Set<BillItems>()
                .OrderBy(x => x.BillItemId)
                .AsNoTracking()
                .ToListAsync();
            return collection;
        }
    }
}
