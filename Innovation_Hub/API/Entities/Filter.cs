using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class Filter
    {
        public int Skip { get; set; }
        public int Take { get; set; }
        public string OrderBy { get; set; }
    }
}