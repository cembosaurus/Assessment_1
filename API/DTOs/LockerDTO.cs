using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStore.DTOs
{
    public class LockerDTO
    {
        public int? id { get; set; }
        public int lockerBankId { get; set; }
        public string name { get; set; }
    }
}
