using CPMS.DAL.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CPMS.BL.Entities
{
    public class Developer
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }

        public string FullName
        {
            get => $"{FirstName} {LastName}";
        }
    }
}
