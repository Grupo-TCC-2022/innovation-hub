using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

/*Entities, tambem chamada de model, corresponde ao namespace para definição e armazenamento de
dados, usado para definir os atributos das entidades do sistema
Abstracao de coisas fisicas ou nao do mundo real*/
namespace API.Entities
{
    /*Classe InterestArea ou Area de Interesse, que guardara todas as areas de interesse
    catalogadas no site*/
    [Table("InterestAreas")]
    public class InterestArea
    {
        /*Enum Area de Interesse, estrutura de dados usada para guardar os valores constantes do
        sistema, atraves de um workaround (gambiarra) estamos passando essa lista de valores
        como estao embaixo, com underlines como separador de espaco para a view, e la esses
        valores atraves do metodo String.ReplaceAll todas as underlines sao substituidas por
        espacos*/
        public enum InterestAreaEnum
        {
            [Description("Arte e Cultura")]
            Arte_e_Cultura,
            [Description("Música e Entretenimento")]
            Musica_e_Entretenimento,
            [Description("Automóveis e Veiculos")]
            Automoveis_e_Veiculos,
            [Description("Informática e Eletronica")]
            Informatica_e_Eletronica,
            [Description("Educação")]
            Educacao,
            [Description("Vida")]
            Vida,
            [Description("Família")]
            Familia,
            [Description("Negócios e Empreendedorismo")]
            Negocios_e_Empreendedorismo,
            [Description("Culinaria e Gastronomia")]
            Culinaria_e_Gastronomia,
            [Description("Saúde e Bem Estar")]
            Saude_e_Bem_Estar,
            [Description("Esporte")]
            Esporte,
            [Description("Viagem e Turismo")]
            Viagem_e_Turismo,
            [Description("Economia e Finanças")]
            Economia_e_Financas,
            [Description("Política e Mundo")]
            Politica_e_Mundo,
            [Description("Ciência e Tecnologia")]
            Ciencia_e_Tecnologia,
            [Description("Trabalho e Carreira")]
            Trabalho_e_Carreira,
            [Description("Psicologia e Sociedade")]
            Psicologia_e_Sociedade,
            [Description("Meio Ambiente")]
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