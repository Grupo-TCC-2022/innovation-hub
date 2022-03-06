using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    [Table("Socials")]
    public class Social
    {
        public int Id { get; set; }
        public string Link { get; set; }
    }
}