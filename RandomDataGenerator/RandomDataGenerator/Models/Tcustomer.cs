using System;
using System.Collections.Generic;

namespace RandomDataGenerator.Models
{
    public partial class Tcustomer
    {
        public Tcustomer()
        {
            Tbooking = new HashSet<Tbooking>();
        }

        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public decimal? Points { get; set; }
        public DateTime? Dob { get; set; }
        public string Pesel { get; set; }
        public string UpdateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public decimal Rowversion { get; set; }
        public string CreateUser { get; set; }

        public virtual ICollection<Tbooking> Tbooking { get; set; }
    }
}
