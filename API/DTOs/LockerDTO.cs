using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStore.DTOs
{
    public class LockerDTO
    {
        public int? Id { get; set; }
        public int LockerBankId { get; set; }
        public string Name { get; set; }
    }
}
