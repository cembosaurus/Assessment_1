using DataStore.DTOs;
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
                    Name = loc.Name,
                    LockerBanks = loc.LockerBanks
                    .Select( lb => new LockerBankDTO{
                        Id = lb.Id,
                        Name = lb.Name})
                        .GroupJoin( _context.Lockers, 
                        lb => lb.Id, 
                        l => l.LockerBankId, 
                        (bank,lockers) => new {
                            Id = bank.Id,
                            Name = bank.Name,
                            Lockers = lockers
                            .Select(l => new LockerDTO{
                                Id = l.Id,
                                Name = l.Name
                            })
                        })
                }).ToListAsync();


            return result;
        }
    }
}
