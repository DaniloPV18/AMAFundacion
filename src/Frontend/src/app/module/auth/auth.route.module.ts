// auth.module.ts
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { ResetPasswordComponent } from './reset-password/reset-password.component';
import { ConfirmationPasswordComponent } from './confirmation-password/confirmation-password.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'reset-password', component: ResetPasswordComponent },
  { path: 'confirmation-password', component: ConfirmationPasswordComponent },
  //{ path: '', redirectTo: '/auth/login', pathMatch: 'full' },
  //{ path: '**', redirectTo: '/auth/login', pathMatch: 'full' },
];

@NgModule({
  imports: [ RouterModule.forChild(routes)]
})
export class AuthRouteModule {}
