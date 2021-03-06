﻿using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace RandomDataGenerator.Models
{
    [Serializable]
    public partial class Tgroup
    {
        public Tgroup()
        {
            Tusergroup = new HashSet<Tusergroup>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal System { get; set; }
        public decimal Deleted { get; set; }
        public string UpdateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public decimal Rowversion { get; set; }
        public string CreateUser { get; set; }
        [XmlIgnoreAttribute]
        public virtual ICollection<Tusergroup> Tusergroup { get; set; }
    }
}
