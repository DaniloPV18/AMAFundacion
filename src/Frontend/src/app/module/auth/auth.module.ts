import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AuthRouteModule } from './auth.route.module';
import { CommonModule } from '@angular/common';
import { AuthService } from '../../services/auth/auth.service';
import { HttpClientModule } from '@angular/common/http';
import { LoginComponent } from './login/login.component';
import { SmtpConfigurationService } from '../../services/configuracion/smtp.service';
import { ResetPasswordComponent } from './reset-password/reset-password.component';
import { ConfirmationPasswordComponent } from './confirmation-password/confirmation-password.component';
import { AppModule } from '../../app.module';

@NgModule({
  declarations:[
     LoginComponent,
     ResetPasswordComponent,
     ConfirmationPasswordComponent
  ],
  imports: [
    CommonModule,
     ReactiveFormsModule,
    FormsModule,
    // NgModule,
    AuthRouteModule,
    HttpClientModule,

  ],
  exports: [
    AuthRouteModule
  ],
providers:[AuthService,SmtpConfigurationService]

})
export class AuthModule {}
