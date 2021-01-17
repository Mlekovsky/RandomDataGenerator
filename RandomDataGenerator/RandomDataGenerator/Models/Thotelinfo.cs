using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace RandomDataGenerator.Models
{
    [Serializable]
    public partial class Thotelinfo
    {
        public int Id { get; set; }
        public int? ThotelId { get; set; }
        public string Description { get; set; }
        public int? TlanguageId { get; set; }
        public string UpdateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public decimal Rowversion { get; set; }
        public string CreateUser { get; set; }
        [XmlIgnoreAttribute]
        public virtual Thotel Thotel { get; set; }
        [XmlIgnoreAttribute]
        public virtual Tlanguage Tlanguage { get; set; }
    }
}
