using innovation_hub.Models.Enums;

namespace innovation_hub.Models
{
    /* Representar tabela no banco com nome areas de interesse */
    public class InterestArea
    {
        public int Id { get; set; }
        public CategoryEnum Category { get; set; }
    }
}