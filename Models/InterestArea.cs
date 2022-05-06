using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using innovation_hub.Models.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace innovation_hub.Models
{
    /* Representar tabela no banco com nome areas de interesse */
    public class InterestArea
    {
        [Key]
        public int Id { get; set; }
        public CategoryEnum Category { get; set; }
        [NotMapped]
        public List<SelectListItem> Categories { get; set; }

        public InterestArea()
        {
            Categories = new List<SelectListItem>();

            Categories.Add(new SelectListItem
            {
                Value = ((int)CategoryEnum.arte_e_cultura).ToString(),
                Text = "Arte e Cultura"
            });

            Categories.Add(new SelectListItem
            {
                Value = ((int)CategoryEnum.musica_e_entretenimento).ToString(),
                Text = "Música e Entretenimento"
            });

            Categories.Add(new SelectListItem
            {
                Value = ((int)CategoryEnum.automoveis_e_veiculos).ToString(),
                Text = "Automoveis e Veiculos"
            });

            Categories.Add(new SelectListItem
            {
                Value = ((int)CategoryEnum.informatica_e_eletronica).ToString(),
                Text = "Informatica e Eletrônica"
            });

            Categories.Add(new SelectListItem
            {
                Value = ((int)CategoryEnum.educacao).ToString(),
                Text = "Educação"
            });

            Categories.Add(new SelectListItem
            {
                Value = ((int)CategoryEnum.vida).ToString(),
                Text = "Vida"
            });

            Categories.Add(new SelectListItem
            {
                Value = ((int)CategoryEnum.familia).ToString(),
                Text = "Família"
            });

            Categories.Add(new SelectListItem
            {
                Value = ((int)CategoryEnum.negocios_e_empreendedorismo).ToString(),
                Text = "Negócios e Empreendedorismo"
            });

            Categories.Add(new SelectListItem
            {
                Value = ((int)CategoryEnum.culinaria_e_gastronomia).ToString(),
                Text = "Culinária e Gastronomia"
            });

            Categories.Add(new SelectListItem
            {
                Value = ((int)CategoryEnum.saude_e_bem_estar).ToString(),
                Text = "Saúde e Bem Estar"
            });

            Categories.Add(new SelectListItem
            {
                Value = ((int)CategoryEnum.esporte).ToString(),
                Text = "Esporte"
            });

            Categories.Add(new SelectListItem
            {
                Value = ((int)CategoryEnum.viagem_e_turismo).ToString(),
                Text = "Viagem e Turismo"
            });

            Categories.Add(new SelectListItem
            {
                Value = ((int)CategoryEnum.economia_e_financas).ToString(),
                Text = "Economia e Finanças"
            });

            Categories.Add(new SelectListItem
            {
                Value = ((int)CategoryEnum.politica_e_mundo).ToString(),
                Text = "Política e Mundo"
            });

            Categories.Add(new SelectListItem
            {
                Value = ((int)CategoryEnum.ciencia_e_tecnologia).ToString(),
                Text = "Ciência e Tecnologia"
            });

            Categories.Add(new SelectListItem
            {
                Value = ((int)CategoryEnum.trabalho_e_carreira).ToString(),
                Text = "Trabalho e Carreira"
            });

            Categories.Add(new SelectListItem
            {
                Value = ((int)CategoryEnum.psicologia_e_sociedade).ToString(),
                Text = "Psicologia e Sociedade"
            });

            Categories.Add(new SelectListItem
            {
                Value = ((int)CategoryEnum.meio_ambiente).ToString(),
                Text = "Meio Ambiente"
            });
        }
    }
}