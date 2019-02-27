using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStore.DTOs
{
    public class LocationDTO
    {
        public int? id { get; set; }
        public string name { get; set; }
        public List<LockerBankDTO> locker_banks { get; set; }
    }
}
