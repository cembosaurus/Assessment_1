using DataStore.DTOs;
using DataStore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataStore.Data
{
    public interface ILockersRepository
    {
        Task<LockersDTO> Lockers();
    }
}