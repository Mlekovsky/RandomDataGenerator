using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace RandomDataGenerator.Models
{
    [Serializable]
    public partial class Tusergroup
    {
        public int Id { get; set; }
        public int TuserId { get; set; }
        public int TgroupId { get; set; }
        public string UpdateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public decimal Rowversion { get; set; }
        [XmlIgnoreAttribute]
        public virtual Tgroup Tgroup { get; set; }
        [XmlIgnoreAttribute]
        public virtual Tuser Tuser { get; set; }
    }
}
