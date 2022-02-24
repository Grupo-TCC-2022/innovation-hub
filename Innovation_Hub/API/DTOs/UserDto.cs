using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;

namespace API.DTOs
{
    public class UserDto
    {
        public string UserName { get; set; }
        public List<InterestArea> InterestAreas { get; set; }
        public string Token { get; set; }
    }
}