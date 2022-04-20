using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using innovation_hub.Extensions;

namespace innovation_hub.Models
{
    // Usuario padrao
    public class AppUser
    {
        // Id padrao para entity framework mapear
        public int Id { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        // Guardar data de nascimento para fazer calculo de idade depois
        public DateTime DateOfBirth { get; set; }

        // Apelido usado para logar no sistema
        public string Username { get; set; }

        // Colecao de areas de interesse do usuario
        public ICollection<InterestArea> InterestAreas { get; set; }

        // Lista de comentarios feitos pelo usuario
        public ICollection<Comment> Comments { get; set; }

        // Propostas em que o usuario esta inserido, feito atravers de uma relacao de muitos para muitos
        public ICollection<AppUserProposal> ProposalsIamIn { get; set; }

        // Propostas favoritadas pelo usuario
        public ICollection<Proposal> FavoriteProposals { get; set; }

        // Idade do usuario, que eh um metodo baseado na data de nascimento
        public int GetAge()
        {
            return DateOfBirth.CalculateAge();
        }
    }
}