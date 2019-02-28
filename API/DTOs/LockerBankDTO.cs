using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStore.DTOs
{
    public class LockerBankDTO
    {
        public int? Id { get; set; }
        public int LocationId { get; set; }
        public string Name { get; set; }
        public List<LockerDTO> lockers { get; set; }
    }
}
