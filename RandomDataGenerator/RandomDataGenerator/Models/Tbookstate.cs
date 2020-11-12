using System;
using System.Collections.Generic;

namespace RandomDataGenerator.Models
{
    public partial class Tbookstate
    {
        public Tbookstate()
        {
            Tbooking = new HashSet<Tbooking>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string UpdateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public decimal Rowversion { get; set; }
        public string CreateUser { get; set; }

        public virtual ICollection<Tbooking> Tbooking { get; set; }
    }
}
