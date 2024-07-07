import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
//import { ReactiveFormsModule } from '@angular/forms';
import { /*CommonModule,*/ DatePipe } from '@angular/common';
import { FooterComponent } from './main/footer/footer.component';
import { HeaderComponent } from './main/header/header.component';
import {BrowserModule} from '@angular/platform-browser';
//import { LayoutRouteModule } from './layout.route.module';
import { MainComponent } from './main/main.component';
import { StoreModule } from '@ngrx/store';
import { uiReducer } from '../../store/ui/reducer';
import { AppService } from '../../services/app.service';
import { HeaderModule } from './main/header/header.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LoginContainerComponent } from './login-container/login-container.component';
import { MenuSidebarModule } from './main/menu-sidebar/menu-sidebar.module';
import { SharedModule } from '../../shared/shared.module';

@NgModule({
  declarations:[
    MainComponent,
    LoginContainerComponent,
    FooterComponent,
  ],
  imports: [
    RouterModule,
    //BrowserModule,
    BrowserAnimationsModule,
    MenuSidebarModule,
    HeaderModule,
    SharedModule,
    //LayoutRouteModule,

    //CommonModule,


    StoreModule.forRoot({ui: uiReducer})
  ],
  exports: [
    //RouterModule,
     MainComponent,
     //HeaderComponent,
     //MenuSidebarModule
  ],
  providers:[DatePipe,AppService]
})
export class LayoutModule {}
