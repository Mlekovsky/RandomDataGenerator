using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace RandomDataGenerator.Models
{
    [Serializable]
    public partial class Tflight
    {
        public Tflight()
        {
            Tbookelement = new HashSet<Tbookelement>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public DateTime? DepartureDate { get; set; }
        public DateTime? ArrivalDate { get; set; }
        public decimal? Price { get; set; }
        public decimal? Handbag { get; set; }
        public decimal? Handbagnum { get; set; }
        public decimal? Regbag { get; set; }
        public decimal? Regbagnum { get; set; }
        public string UpdateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public decimal Rowversion { get; set; }
        public string CreateUser { get; set; }
        [XmlIgnoreAttribute]
        public virtual ICollection<Tbookelement> Tbookelement { get; set; }
    }
}
