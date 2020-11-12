using System;
using System.Collections.Generic;

namespace RandomDataGenerator.Models
{
    public partial class Tuser
    {
        public Tuser()
        {
            Tusergroup = new HashSet<Tusergroup>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public decimal Deleted { get; set; }
        public string UpdateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public decimal Rowversion { get; set; }
        public string CreateUser { get; set; }

        public virtual ICollection<Tusergroup> Tusergroup { get; set; }
    }
}
