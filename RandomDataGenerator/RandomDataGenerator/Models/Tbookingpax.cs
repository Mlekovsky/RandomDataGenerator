using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace RandomDataGenerator.Models
{
    [Serializable]
    public partial class Tbookingpax
    {
        public int Id { get; set; }
        public int? TbookingId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime? Dob { get; set; }
        public string Pesel { get; set; }
        public decimal? IsCustomer { get; set; }
        public string UpdateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public decimal Rowversion { get; set; }
        public string CreateUser { get; set; }
        [XmlIgnoreAttribute]
        public virtual Tbooking Tbooking { get; set; }
    }
}
