
import { Component, HostBinding, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { UiState } from '../../../../store/ui/state';
import { AppService } from '../../../../services/app.service';
import { AppState } from '../../../../store/state';
import { openCloseAnimation, rotateAnimation } from './menu-item/menu-item.animation';
import { AuthService } from './../../../../services/auth/auth.service';
import { IMenuItem } from '../../../../core/interfaces/menu-item';
const BASE_CLASSES = 'main-sidebar elevation-4';

@Component({
  selector: 'app-menu-sidebar',
  //standalone: true,
  // imports: [CommonModule],
  templateUrl: './menu-sidebar.component.html',
  styleUrl: './menu-sidebar.component.sass'
  //animations: [openCloseAnimation, rotateAnimation]
})

export class MenuSidebarComponent implements OnInit {
  @HostBinding('class') classes: string = BASE_CLASSES;
  public ui!: Observable<UiState>;
  // public user;
  public menu = MENU;

  constructor(
    public appService: AppService,
    private authService: AuthService,
    private store: Store<AppState>,

  ) { }

  ngOnInit() {
    this.ui = this.store.select('ui');
    this.ui.subscribe((state: UiState) => {
      this.classes = `${BASE_CLASSES} ${state.sidebarSkin}`;
    });
    // this.user = this.appService.user;
  }

  logout(): void {
    this.authService.logout();
  }
}

export const MENU : IMenuItem[] = [
  {
    name: 'Inicio',
    iconClasses: 'fas fa-home',
    path: ['/']
  },
  {
    name: 'Brigadas',
    iconClasses: 'fas fa-users',
    path: ['/brigate/index']
  },
  {
    name: 'Donaciones',
    iconClasses: 'fas fa-donate',
    path: ['/donaciones/donacion/index']
  },
  {
    name: 'Personas',
    iconClasses: 'fas fa-users',
    children: [
      {
        name: 'Personas',
        iconClasses: 'fas fa-user',
        path: ['/configuracion/person']
      },
      {
        name: 'Donantes',
        iconClasses: 'fas fa-donate',
        path: ['/donaciones/crud-donante']
      },
      // {
      //   name: 'Voluntarios',
      //   iconClasses: 'fas fa-hands-helping',
      //   path: ['/donaciones/crud-voluntario']
      // },
      {
        name: 'Beneficiarios',
        iconClasses: 'fas fa-hand-holding-heart',
        path: ['/beneficiario/index']
      }
    ]
  },
  {
    name: 'Configuración',
    iconClasses: 'fas fa-cogs',
    children: [
      {
        name: 'Usuarios',
        iconClasses: 'fas fa-users-cog',
        path: ['/configuracion/users']
      },
      {
        name: 'Correo',
        iconClasses: 'fas fa-envelope',
        path: ['/configuracion/smtp']
      }
    ]
  },
];
