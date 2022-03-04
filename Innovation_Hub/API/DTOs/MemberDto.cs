using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;

namespace API.DTOs
{
    public class MemberDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        //Atributo Birthday ou Data de Nascimento, usado para fins de censura no site
        public int Age { get; set; }

        //Atributo UserName ou Apelido, o identificador pessoal de cada usuario
        public string UserName { get; set; }

        /*A classe Usuario aqui presente possui o atributo InterestAreas ou Areas de Interesse,
        este atributo eh uma lista de InterestArea, a outra classe que guardara todas as areas
        de interesse. Por ser uma lista, este atributo se transformara numa relacao de 1 (um)
        para * (muitos), ou seja, um usuario pode ter varias areas de interesse, quando se usar
        o entity framework ele criara duas tabelas no banco que se relacionarao por chaves
        estrangeiras*/
        public List<InterestArea> InterestAreas { get; set; }
    }
}