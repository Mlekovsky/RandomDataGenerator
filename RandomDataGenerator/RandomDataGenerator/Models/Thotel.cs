using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace RandomDataGenerator.Models
{
    [Serializable]
    public partial class Thotel
    {
        public Thotel()
        {
            Tbookelement = new HashSet<Tbookelement>();
            Thotelinfo = new HashSet<Thotelinfo>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int TregionId { get; set; }
        public decimal Price { get; set; }
        public decimal? Roomsamounttotal { get; set; }
        public decimal? Roomsamountleft { get; set; }
        public string UpdateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public decimal Rowversion { get; set; }
        public string CreateUser { get; set; }
        [XmlIgnoreAttribute]
        public virtual Tregion Tregion { get; set; }
        [XmlIgnoreAttribute]
        public virtual ICollection<Tbookelement> Tbookelement { get; set; }
        [XmlIgnoreAttribute]
        public virtual ICollection<Thotelinfo> Thotelinfo { get; set; }
    }
}
