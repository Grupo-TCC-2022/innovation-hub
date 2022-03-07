import { Injectable } from '@angular/core';
import { interestAreaEnum } from '../_enums/interestAreaEnum';

@Injectable({
  providedIn: 'root'
})
export class InterestAreaService {

  constructor() { }

  getInterestAreaName(enumNumber: number) {
    switch (enumNumber) {
      case 0:
        return interestAreaEnum.Arte_e_Cultura;
        break;
      case 1:
        return interestAreaEnum.Musica_e_Entretenimento;
        break;
      case 2:
        return interestAreaEnum.Automoveis_e_Veiculos;
        break;
      case 3:
        return interestAreaEnum.Informatica_e_Eletronica;
        break;
      case 4:
        return interestAreaEnum.Educacao;
        break;
      case 5:
        return interestAreaEnum.Vida;
        break;
      case 6:
        return interestAreaEnum.Familia;
        break;
      case 7:
        return interestAreaEnum.Negocios_e_Empreendedorismo;
        break;
      case 8:
        return interestAreaEnum.Culinaria_e_Gastronomia;
        break;
      case 9:
        return interestAreaEnum.Saude_e_Bem_Estar;
        break;
      case 10:
        return interestAreaEnum.Esporte;
        break;
      case 11:
        return interestAreaEnum.Viagem_e_Turismo;
        break;
      case 12:
        return interestAreaEnum.Economia_e_Financas;
        break;
      case 13:
        return interestAreaEnum.Politica_e_Mundo;
        break;
      case 14:
        return interestAreaEnum.Ciencia_e_Tecnologia;
        break;
      case 16:
        return interestAreaEnum.Trabalho_e_Carreira;
        break;
      case 17:
        return interestAreaEnum.Psicologia_e_Sociedade;
        break;
      case 18:
        return interestAreaEnum.Meio_Ambiente;
        break;
      default:
        break;
    }
  }
}
