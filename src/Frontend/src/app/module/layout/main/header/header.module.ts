import {NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { HeaderComponent } from './header.component';
import { BrowserModule } from '@angular/platform-browser';
import { UserComponent } from './user/user.component';

@NgModule({
  declarations:[
    HeaderComponent,
     UserComponent,
  ],
  imports: [
    BrowserModule,
    RouterModule,
     ReactiveFormsModule
  ],
  exports: [
    HeaderComponent
  ],
providers:[]
})
export class HeaderModule {}
