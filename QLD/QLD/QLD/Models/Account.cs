using System;
using System.Collections.Generic;

#nullable disable

namespace QLD.Models
{
    public partial class Account
    {
        public Account()
        {
            Diems = new HashSet<Diem>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Diem> Diems { get; set; }
    }
}
