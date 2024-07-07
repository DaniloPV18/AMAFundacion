import { Component, HostBinding, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Observable } from 'rxjs';
import { UiState } from '../../../../store/ui/state';
import { AppService } from '../../../../services/app.service';
import { AppState } from '../../../../store/state';
import { UntypedFormControl, UntypedFormGroup } from '@angular/forms';
import { ToggleControlSidebar, ToggleSidebarMenu } from '../../../../store/ui/actions';
import { Store } from '@ngrx/store';
import { throws } from 'assert';

const BASE_CLASSES = 'main-header navbar navbar-expand';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrl: './header.component.sass'
})
export class HeaderComponent implements OnInit {
  @HostBinding('class') classes: string = BASE_CLASSES;
  public ui!: Observable<UiState>;
  public searchForm!: UntypedFormGroup;

  constructor(
      private appService: AppService,
      private store: Store<AppState>
  ) {}

  ngOnInit() {
      this.ui = this.store.select('ui');
      this.ui.subscribe((state: UiState) => {
          this.classes = `${BASE_CLASSES} ${state.navbarVariant}`;
      });
      this.searchForm = new UntypedFormGroup({
          search: new UntypedFormControl(null)
      });
  }

  logout() {
      // this.appService.logout();
  }

  onToggleMenuSidebar() {
    //alert('click');
      this.store.dispatch(new ToggleSidebarMenu());
  }

  onToggleControlSidebar() {
      this.store.dispatch(new ToggleControlSidebar());
  }
}
