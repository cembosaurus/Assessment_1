using DataStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStore.Data
{
    internal static class ModelSeed
    {
        internal static readonly Location[] location = new Location[] {
            new Location() { Id = 1, Name = "Sydney" },
            new Location() { Id = 2, Name = "Melbourne" },
            new Location() { Id = 3, Name = "Brisbane" }
        };

        internal static readonly LockerBank[] locekerBank = new LockerBank[] {
            new LockerBank() { Id = 1, LocationId = 1, Name = "cbd_lockerbank_1" },
            new LockerBank() { Id = 2, LocationId = 1, Name = "manly_lockerbank_2" },
            new LockerBank() { Id = 3, LocationId = 1, Name = "terrey_Hills_lockerbank_3" },
            new LockerBank() { Id = 4, LocationId = 2, Name = "cbd_lockerbank_1" },
            new LockerBank() { Id = 5, LocationId = 2, Name = "southbank_lockerbank_2" },
            new LockerBank() { Id = 6, LocationId = 3, Name = "cbd_lockerbank_1" },
            new LockerBank() { Id = 7, LocationId = 3, Name = "south_brisbane_lockerbank_2" }
        };

        internal static readonly Locker[] locker = new Locker[] {
            new Locker() { Id = 1, LockerBankId = 1, Name = "L1" },
            new Locker() { Id = 2, LockerBankId = 1, Name = "L2" },
            new Locker() { Id = 3, LockerBankId = 1, Name = "L3" },
            new Locker() { Id = 4, LockerBankId = 1, Name = "L4" },
            new Locker() { Id = 5, LockerBankId = 1, Name = "L5" },
            new Locker() { Id = 6, LockerBankId = 2, Name = "L1" },
            new Locker() { Id = 7, LockerBankId = 2, Name = "L2" },
            new Locker() { Id = 8, LockerBankId = 2, Name = "L3" },
            new Locker() { Id = 9, LockerBankId = 3, Name = "L1" },
            new Locker() { Id = 10, LockerBankId = 3, Name = "L2" },
            new Locker() { Id = 11, LockerBankId = 3, Name = "L3" },
            new Locker() { Id = 12, LockerBankId = 4, Name = "L1" },
            new Locker() { Id = 13, LockerBankId = 4, Name = "L2" },
            new Locker() { Id = 14, LockerBankId = 4, Name = "L3" },
            new Locker() { Id = 15, LockerBankId = 5, Name = "L1" },
            new Locker() { Id = 16, LockerBankId = 5, Name = "L2" },
            new Locker() { Id = 17, LockerBankId = 5, Name = "L3" },
            new Locker() { Id = 18, LockerBankId = 6, Name = "L1" },
            new Locker() { Id = 19, LockerBankId = 6, Name = "L2" },
            new Locker() { Id = 20, LockerBankId = 6, Name = "L3" },
            new Locker() { Id = 21, LockerBankId = 6, Name = "L4" },
            new Locker() { Id = 22, LockerBankId = 7, Name = "L1" },
            new Locker() { Id = 23, LockerBankId = 7, Name = "L2" },
            new Locker() { Id = 24, LockerBankId = 7, Name = "L3" },
            new Locker() { Id = 25, LockerBankId = 7, Name = "L4" }
        };
    }
}
