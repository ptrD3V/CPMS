﻿using CPMS.DAL.Common;

namespace CPMS.GUI.Models
{
    public class DeveloperModel
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
