using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using innovation_hub.Extensions;

namespace innovation_hub.Models
{
    public class AppUser
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Sobrenome { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Passeword { get; set; }
        [Required]
        public DateTime DateofBirth { get; set; }
        [Required]
        public string Nickname { get; set; }
        public ICollection<Comment> AppUserComments { get; set; }
        public ICollection<InterestArea> InterestAreas { get; set; }
        public ICollection<AppUserProposal> AppUserProposals { get; set; }

        // Idade do usuario, que eh um metodo baseado na data de nascimento
        public int GetAge()
        {
            return DateofBirth.CalculateAge();
        }
    }
}