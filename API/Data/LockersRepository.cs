using DataStore.DTOs;
using DataStore.Models;
using Microsoft.EntityFrameworkCore;
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


        public async Task<LockersDTO> Lockers()
        {

            var result = new LockersDTO {

                Locations = await
                    _context.Locations
                    .GroupJoin(
                        _context.LockerBanks,
                        loc => loc.Id,
                        lb => lb.LocationId,
                        (a, b) => new LocationDTO
                        {
                            Id = a.Id,
                            Name = a.Name,
                            LockerBanks = b.Select(s => new
                            {
                                s.Id,
                                s.LocationId,
                                s.Name
                            })
                            .GroupJoin(
                                _context.Lockers,
                                loba => loba.Id,
                                lk => lk.LockerBankId,
                                (c, d) => new LockerBankDTO
                                {
                                    Id = c.Id,
                                    Name = c.Name,
                                    LocationId = c.LocationId,
                                    Lockers = d.Select(s => new LockerDTO
                                    {
                                        Id = s.Id,
                                        LockerBankId = s.LockerBankId,
                                        Name = s.Name
                                    })
                                }
                            )
                        }
                    )
                    .ToListAsync()

            };

            return result;
        }
    }
}
