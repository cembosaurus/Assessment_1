using DataStore.Models;
using Microsoft.EntityFrameworkCore;
using Users.Models;

namespace DataStore.Data
{
    public interface IDataStore_DBContext
    {
        DbSet<Location> Locations { get; set; }
        DbSet<LockerBank> LockerBanks { get; set; }
        DbSet<Locker> Lockers { get; set; }
        DbSet<User> Users { get; set; }
    }
}