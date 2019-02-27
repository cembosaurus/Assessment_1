using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataStore.Data
{
    public interface ILockersRepository
    {
        Task<object> Lockers();
    }
}