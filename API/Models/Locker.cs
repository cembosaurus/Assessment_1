
namespace DataStore.Models
{
    public class Locker
    {

        public int? Id { get; set; }

        public int LockerBankId { get; set; }
        public LockerBank LockerBank { get; set; }

        public string Name { get; set; }



        //public int ContentId { get; set; }
        //public Content Content { get; set; }

    }
}
