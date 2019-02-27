using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Users.Models;

namespace DataStore.Models
{
    public class Content
    {
        public int Id { get; set; }
        public List<Item> Items { get; set; }
        public int UserId { get; set; }

        public User User { get; set; }
        //public Locker Locker { get; set; }





    }
}
