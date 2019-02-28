using DataStore.DTOs;
using DataStore.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DataStore.Data
{
    public class LockersRepository : ILockersRepository
    {

        private readonly DataStore_DBContext _context;

        public LockersRepository(DataStore_DBContext context)
        {
            _context = context;
        }

        public async Task<object> Lockers()
        {

            var result = await
                _context.Locations.Select(loc => new
                {
                    Id = loc.Id,
                    Name = loc.Name
                })
                .GroupJoin(_context.LockerBanks, l => l.Id, lb => lb.LocationId, (a, b) => new { a.Id, a.Name, LockerBanks = b
                    .GroupJoin(_context.Lockers, lb => lb.Id, l => l.LockerBankId, (c, d) => new { c.Id, c.Name, Lockers = d.Select(l => new { l.Id, l.Name})
                    })
                })
                .ToListAsync();
                    
                    
                    
                    
                    
                    



            return result;
        }
    }
}
