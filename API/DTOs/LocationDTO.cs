using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStore.DTOs
{
    public class LocationDTO
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<LockerBankDTO> LockerBanks { get; set; }
    }
}
