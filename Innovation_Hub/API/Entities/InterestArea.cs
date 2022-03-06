using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using API.Entities.Enums;

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
        public int Id { get; set; }
        public InterestAreaEnum InterestAreaName { get; set; }

        public InterestArea() { }
        public InterestArea(InterestAreaEnum InterestAreaName)
        {
            this.InterestAreaName = InterestAreaName;
        }
    }
}