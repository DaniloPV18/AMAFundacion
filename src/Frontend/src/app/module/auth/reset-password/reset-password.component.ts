import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { AuthService } from '../../../services/auth/auth.service';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-reset-password',
  templateUrl: './reset-password.component.html',
  styleUrl: './reset-password.component.sass'
})

export class ResetPasswordComponent {
  Identification: string = '';
  errorMessage:string = '';
  errorOccured: boolean = false;

  constructor(private router: Router, private authService: AuthService, private http: HttpClient) { }

  sendCodeResetPass(): void {

    const sendCodeRequest = {
      Identification: this.Identification.toString()
    };


    this.authService.SendCodeToResetPassword(sendCodeRequest).subscribe({
      next: (response) => {
        this.router.navigate(['/auth/confirmation-password']);

      },
      error: (error) => {
        
        console.error('Error del servidor:', error);
        this.errorOccured = true;
      }
    });

  }

  onBack(): void{

    this.router.navigate(['/login']);
  }

  isValidEmail(email: string): boolean {
    // Simple email validation regex
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return emailRegex.test(email);
}

}
