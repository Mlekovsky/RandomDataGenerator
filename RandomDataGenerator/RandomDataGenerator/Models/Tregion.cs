using System;
using System.Collections.Generic;

namespace RandomDataGenerator.Models
{
    public partial class Tregion
    {
        public Tregion()
        {
            Thotel = new HashSet<Thotel>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int TcountryId { get; set; }
        public string UpdateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public decimal Rowversion { get; set; }
        public string CreateUser { get; set; }

        public virtual Tcountry Tcountry { get; set; }
        public virtual ICollection<Thotel> Thotel { get; set; }
    }
}
