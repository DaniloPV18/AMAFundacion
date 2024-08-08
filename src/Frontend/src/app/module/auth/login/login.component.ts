import { Component, Input } from '@angular/core';
import { AuthService } from '../../../services/auth/auth.service';
import { Router } from '@angular/router';
import { AuthRequest } from '../../../models/authentication/auth-request';
 
@Component({
  template:'',
  templateUrl: './login.component.html',
  styleUrl: './login.component.sass'
})
export class LoginComponent {
  authRequest: AuthRequest = {
    User: '',
    Password: '',
  };


  constructor(private authService: AuthService, private router: Router) {}

  onLoginButtonClick() {
    this.authService.login(this.authRequest).subscribe({
      next: (authDTO) => {

        this.authService.saveAuthToken(authDTO.token,authDTO.date??new Date());

        this.router.navigate(['/']);
      },
      error: (error) => {

        alert('Error al autenticar');

      },
    });
  }
}
