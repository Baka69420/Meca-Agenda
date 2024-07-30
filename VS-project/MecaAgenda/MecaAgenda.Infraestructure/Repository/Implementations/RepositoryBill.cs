using MecaAgenda.Infraestructure.Data;
using MecaAgenda.Infraestructure.Models;
using MecaAgenda.Infraestructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MecaAgenda.Infraestructure.Repository.Implementations
{
    public class RepositoryBill : IRepositoryBill
    {
        private readonly MecaAgendaContext _context;

        public RepositoryBill(MecaAgendaContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(Bills bill)
        {
            await _context.Set<Bills>().AddAsync(bill);
            await _context.SaveChangesAsync();
            return bill.BillId;
        }

        public async Task DeleteAsync(int billId)
        {
            var billToDelete = await GetAsync(billId);

            if (billToDelete != null)
            {
                _context.Set<Bills>().Remove(billToDelete);

                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Bill with ID {billId} does not exist.");
            }
        }

        public async Task<Bills> GetAsync(int id)
        {
            var @object = await _context.Set<Bills>()
                .Where(x => x.BillId == id)
                .Include(x => x.Client)
                .Include(x => x.Branch)
                .Include(x => x.BillItems)
                    .ThenInclude(x => x.Product)
                .Include(x => x.Appointments)
                    .ThenInclude(x => x.Service)
                .OrderBy(x => x.BillId)
                .FirstOrDefaultAsync();
            return @object!;
        }

        public async Task<ICollection<Bills>> ListAsync(int? idBranch, int? idClient, DateOnly? billDate)
        {
            var collection = await _context.Set<Bills>()
                .Include(x => x.Client)
                .Include(x => x.Branch)
                .OrderByDescending(x => x.Date)
                .AsNoTracking()
                .ToListAsync();

            if (idBranch.HasValue)
                collection = collection.Where(x => x.BranchId == idBranch.Value).ToList();

            if (idClient.HasValue)
                collection = collection.Where(x => x.ClientId == idClient.Value).ToList();

            if (billDate.HasValue)
                collection = collection.Where(x => x.Date == billDate.Value).ToList();

            return collection;
        }

        public async Task UpdateAsync(Bills bill)
        {
            var billToUpdate = await GetAsync(bill.BillId);

            if (billToUpdate != null)
            {
                billToUpdate.Date = bill.Date;
                billToUpdate.TotalAmount = bill.TotalAmount;
                billToUpdate.PaymentMethod = bill.PaymentMethod;
                billToUpdate.Paid = bill.Paid;

                _context.Entry(billToUpdate).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Bill with ID {bill.BillId} does not exist.");
            }
        }
    }
}
