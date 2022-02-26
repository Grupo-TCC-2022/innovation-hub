using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class InterestArea
    {
        public enum InterestAreaEnum
        {
            Arte_e_Cultura,
            Musica_e_Entretenimento,
            Automoveis_e_Veiculos,
            Informatica_e_Eletronica,
            Educacao,
            Vida,
            Familia,
            Negocios_e_Empreendedorismo,
            Culinaria_e_Gastronomia,
            Saude_e_Bem_Estar,
            Esporte,
            Viagem_e_Turismo,
            Economia_e_Financas,
            Politica_e_Mundo,
            Ciencia_e_Tecnologia,
            Trabalho_e_Carreira,
            Psicologia_e_Sociedade,
            Meio_Ambiente
        }

        public int Id { get; set; }
        public InterestAreaEnum InterestAreaName { get; set; }

        public InterestArea(InterestAreaEnum InterestAreaName)
        {
            this.InterestAreaName = InterestAreaName;
        }
    }
}