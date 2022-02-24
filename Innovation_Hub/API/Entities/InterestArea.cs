using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities.Enums;

namespace API.Entities
{
    public class InterestArea
    {
        public int Id { get; set; }
        public InterestAreaEnum InterestAreaName { get; set; }

        public InterestArea(InterestAreaEnum InterestAreaName)
        {
            this.InterestAreaName = InterestAreaName;
        }
    }
}