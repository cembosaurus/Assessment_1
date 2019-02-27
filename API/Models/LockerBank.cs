using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStore.Models
{
    public class LockerBank
    {
        public int? Id { get; set; }

        public int LocationId { get; set; }
        public Location Location { get; set; }

        public string Name { get; set; }


        public IList<Locker> Lockers { get; set; }
    }
}
