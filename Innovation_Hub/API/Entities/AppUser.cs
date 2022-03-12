using System;
using System.Collections.Generic;
using API.Extensions;

/*Entities, tambem chamada de model, corresponde ao namespace para definição e armazenamento de
dados, usado para definir os atributos das entidades do sistema
Abstracao de coisas fisicas ou nao do mundo real*/
namespace API.Entities
{
    /*AppUser ou Usuario, eh a pessoa que pode registrar e fazer login no site, dentre
    outras funcionalidades destinadas a ele, aqui se apresenta sua abstracao como classe
    objeto*/
    public class AppUser
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        //Atributo Birthday ou Data de Nascimento, usado para fins de censura no site
        public DateTime Birthday { get; set; }

        //Atributo UserName ou Apelido, o identificador pessoal de cada usuario
        public string UserName { get; set; }

        /*A classe Usuario aqui presente possui o atributo InterestAreas ou Areas de Interesse,
        este atributo eh uma lista de InterestArea, a outra classe que guardara todas as areas
        de interesse. Por ser uma lista, este atributo se transformara numa relacao de 1 (um)
        para * (muitos), ou seja, um usuario pode ter varias areas de interesse, quando se usar
        o entity framework ele criara duas tabelas no banco que se relacionarao por chaves
        estrangeiras*/
        public List<InterestArea> InterestAreas { get; set; }

        /*Atributos Password usados para encriptacao de senha pelo metodo hash, onde a senha eh
        encriptada como sequencias de caracteres em byte*/
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public int GetAge()
        {
            return Birthday.CalculateAge();
        }

        public IEnumerable<AppUserProposal> ProposalsIamIn { get; set; }
    }
}