using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace RandomDataGenerator.Models
{
    [Serializable]
    public partial class Tbooking
    {
        public Tbooking()
        {
            Tbookelement = new HashSet<Tbookelement>();
            Tbookingpax = new HashSet<Tbookingpax>();
        }

        public int Id { get; set; }
        public string Bookno { get; set; }
        public int? TbookstateId { get; set; }
        public decimal? TotalPrice { get; set; }
        public int? Booked { get; set; }
        public string UpdateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? TcustomerId { get; set; }
        public decimal Rowversion { get; set; }
        public string CreateUser { get; set; }

        [XmlIgnoreAttribute]
        public virtual Tbookstate Tbookstate { get; set; }
        [XmlIgnoreAttribute]
        public virtual Tcustomer Tcustomer { get; set; }
        [XmlIgnoreAttribute]
        public virtual ICollection<Tbookelement> Tbookelement { get; set; }
        [XmlIgnoreAttribute]
        public virtual ICollection<Tbookingpax> Tbookingpax { get; set; }
    }
}
