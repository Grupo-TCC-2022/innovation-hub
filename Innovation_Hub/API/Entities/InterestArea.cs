using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/*Entities, tambem chamada de model, corresponde ao namespace para definição e armazenamento de
dados, usado para definir os atributos das entidades do sistema*/
namespace API.Entities
{
    /*Classe InterestArea ou Area de Interesse, que guardara todas as areas de interesse
    catalogadas no site*/
    public class InterestArea
    {
        /*Enum Area de Interesse, estrutura de dados usada para guardar os valores constantes do
        sistema, atraves de um workaround (gambiarra) estamos passando essa lista de valores
        como estao embaixo, com underlines como separador de espaco para a view, e la esses
        valores atraves do metodo String.ReplaceAll todas as underlines sao substituidas por
        espacos*/
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