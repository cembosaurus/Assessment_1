using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStore.Models
{
    public class Location
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public IList<LockerBank> LockerBanks { get; set; }

    }
}
