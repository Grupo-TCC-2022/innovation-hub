using System;
using System.Collections.Generic;

namespace API.Entities
{
    public class AppUser
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string UserName { get; set; }
        public List<InterestArea> InterestAreas { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}