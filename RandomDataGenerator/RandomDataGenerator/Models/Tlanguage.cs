using System;
using System.Collections.Generic;

namespace RandomDataGenerator.Models
{
    public partial class Tlanguage
    {
        public Tlanguage()
        {
            Thotelinfo = new HashSet<Thotelinfo>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string UpdateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public decimal Rowversion { get; set; }
        public string CreateUser { get; set; }

        public virtual ICollection<Thotelinfo> Thotelinfo { get; set; }
    }
}
