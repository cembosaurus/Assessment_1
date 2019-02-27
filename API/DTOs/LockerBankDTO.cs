using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStore.DTOs
{
    public class LockerBankDTO
    {
        public int? id { get; set; }
        public int locationId { get; set; }
        public string name { get; set; }
        public List<LockerDTO> lockers { get; set; }
    }
}
