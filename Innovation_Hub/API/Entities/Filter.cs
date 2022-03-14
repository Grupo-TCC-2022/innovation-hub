using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities.Enums;

namespace API.Entities
{
    public class Filter
    {
        public int Skip { get; set; }
        public int Take { get; set; }
        public string OrderBy { get; set; }
        public InterestAreaEnum? Category { get; set; } = null;
        public int commentId { get; set; }
        public string userName { get; set; }
    }
}