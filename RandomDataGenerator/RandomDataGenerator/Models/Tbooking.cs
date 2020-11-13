using System;
using System.Collections.Generic;

namespace RandomDataGenerator.Models
{
    public partial class Tbooking
    {
        public Tbooking()
        {
            Tbookelement = new HashSet<Tbookelement>();
            Tbookingpax = new HashSet<Tbookingpax>();
        }

        public int Id { get; set; }
        public int Bookno { get; set; }
        public int? TbookstateId { get; set; }
        public decimal? TotalPrice { get; set; }
        public int? Booked { get; set; }
        public string UpdateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? TcustomerId { get; set; }
        public decimal Rowversion { get; set; }
        public string CreateUser { get; set; }

        public virtual Tbookstate Tbookstate { get; set; }
        public virtual Tcustomer Tcustomer { get; set; }
        public virtual ICollection<Tbookelement> Tbookelement { get; set; }
        public virtual ICollection<Tbookingpax> Tbookingpax { get; set; }
    }
}
