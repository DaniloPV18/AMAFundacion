
import {Component, HostBinding, OnInit, Renderer2} from '@angular/core';
import { CommonModule } from '@angular/common';
import { Observable } from 'rxjs';
import {Store} from '@ngrx/store';
import { UiState } from '../../../store/ui/state'; //TODO: Normalizar
import { AppState } from '../../../store/state'; //TODO: Normalizar
import { ToggleSidebarMenu } from '../../../store/ui/actions';//TODO: Normalizar
import { RouterModule } from '@angular/router';
import { HeaderComponent } from './header/header.component';

@Component({
  //selector: 'app-main',
  //standalone: true,
  //imports:[LayoutModule],
  //imports: [CommonModule,RouterModule,HeaderComponent,MenuSidebarComponent],
  templateUrl: './main.component.html',
  styleUrl: './main.component.sass'
})
export class MainComponent implements OnInit {
  @HostBinding('class') class = 'wrapper';
  public ui!: Observable<UiState>;

  constructor(private renderer: Renderer2, private store: Store<AppState>) {}

  ngOnInit() {
      this.ui = this.store.select('ui');
      this.renderer.removeClass(
          document.querySelector('app-root'),
          'login-page'
      );
      this.renderer.removeClass(
          document.querySelector('app-root'),
          'register-page'
      );
      this.renderer.addClass(
          document.querySelector('app-root'),
          'layout-fixed'
      );

      this.ui.subscribe(
          ({menuSidebarCollapsed, controlSidebarCollapsed, darkMode}) => {
              if (menuSidebarCollapsed) {
                  this.renderer.removeClass(
                      document.querySelector('app-root'),
                      'sidebar-open'
                  );
                  this.renderer.addClass(
                      document.querySelector('app-root'),
                      'sidebar-collapse'
                  );
              } else {
                  this.renderer.removeClass(
                      document.querySelector('app-root'),
                      'sidebar-collapse'
                  );
                  this.renderer.addClass(
                      document.querySelector('app-root'),
                      'sidebar-open'
                  );
              }

              if (controlSidebarCollapsed) {
                  this.renderer.removeClass(
                      document.querySelector('app-root'),
                      'control-sidebar-slide-open'
                  );
              } else {
                  this.renderer.addClass(
                      document.querySelector('app-root'),
                      'control-sidebar-slide-open'
                  );
              }

              if (darkMode) {
                  this.renderer.addClass(
                      document.querySelector('app-root'),
                      'dark-mode'
                  );
              } else {
                  this.renderer.removeClass(
                      document.querySelector('app-root'),
                      'dark-mode'
                  );
              }
          }
      );
  }

  onToggleMenuSidebar() {
      this.store.dispatch(new ToggleSidebarMenu());
  }
}
