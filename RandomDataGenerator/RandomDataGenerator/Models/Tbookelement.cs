using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace RandomDataGenerator.Models
{
    [Serializable]
    public partial class Tbookelement
    {
        public int Id { get; set; }
        public int? TbookingId { get; set; }
        public int? TbookeltypeId { get; set; }
        public string UpdateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? ThotelId { get; set; }
        public int? TflightId { get; set; }
        public decimal Rowversion { get; set; }
        public string CreateUser { get; set; }

        [XmlIgnoreAttribute]
        public virtual Tbooking Tbooking { get; set; }
        [XmlIgnoreAttribute]
        public virtual Tflight Tflight { get; set; }
        [XmlIgnoreAttribute]
        public virtual Thotel Thotel { get; set; }
    }
}
