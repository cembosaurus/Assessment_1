using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
            var result = await _context.Locations.Select(a => new
            {
                a.Id,
                a.Name,
                locker_banks = a.LockerBanks
                .Select(b => new
                {
                    b.Id,
                    b.LocationId,
                    b.Name,
                    lockers = b.Lockers
                .Select(c => new { c.Id, c.LockerBankId, c.Name })
                })
            }).ToListAsync();


            return result;
        }
    }
}
