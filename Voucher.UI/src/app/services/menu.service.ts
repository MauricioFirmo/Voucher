import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Menu } from '../shared/model/menu.model';

@Injectable({
  providedIn: 'root'
})
export class MenuService {

  menu: Menu = new Menu();

  public shouldUpdateMenu: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);

  constructor() { }

  getMenuList(groups: string[]): Menu {
    this.menu = {
      items: [
        {
          label: 'Autorização de Vouchers',
          route: '/autorizacao-voucher',
          icon: 'fact_check',
          canShow: groups.includes('DL AUTORIZAR VOUCHER')
        },
        {
          label: 'Emitir Vouchers',
          route: '/emissao-voucher',
          icon: 'receipt',
          canShow: groups.includes('DL EMITIR VOUCHER')
        },
        {
          label: 'Relatórios',
          route: '/inicio',
          icon: 'assignment',
          canShow: true
        },
      ],
      expansibleItems: [
        {
          title: 'Cadastro',
          icon: 'inventory_2',
          canShow: groups.includes('DL CADASTROS VOUCHER'),
          items: [
            {
              label: 'Hoteis',
              route: '/cadastro-hoteis/listar',
              icon: 'room_service',
              canShow: groups.includes('DL CADASTROS VOUCHER'),
            },
            {
              label: 'Modelo Cartas Hoteis',
              route: '/modelo-cartas/listar',
              icon: 'mail_outline',
              canShow: groups.includes('DL CADASTROS VOUCHER'),
            },
            {
              label: 'Alimentação',
              route: '/cadastro-alimentacao/listar',
              icon: 'restaurant',
              canShow: groups.includes('DL CADASTROS VOUCHER'),
            },
            {
              label: 'Transporte',
              route: '/cadastro-transporte/listar',
              icon: 'commute',
              canShow: groups.includes('DL CADASTROS VOUCHER'),
            }
          ]
        },
      ]
    }
    return this.menu;
  }

  setMenu() {

  }



}
