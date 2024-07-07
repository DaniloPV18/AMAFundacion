import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule, DatePipe } from '@angular/common';
// import {BrowserModule} from '@angular/platform-browser';
// import { StoreModule } from '@ngrx/store';
import { MenuItemComponent } from './menu-item/menu-item.component';
import { MenuSidebarComponent } from './menu-sidebar.component';
// import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
// import { uiReducer } from '../../../../store/ui/reducer';
import { AppService } from '../../../../services/app.service';


@NgModule({
  declarations:[
    MenuItemComponent,
    MenuSidebarComponent
  ],
  imports: [
    //BrowserModule,
    CommonModule,
    RouterModule,
    //BrowserAnimationsModule,
    //StoreModule.forRoot({ui: uiReducer})
  ],
  exports:[MenuSidebarComponent],
  providers:[DatePipe,AppService]
})
export class MenuSidebarModule {}
