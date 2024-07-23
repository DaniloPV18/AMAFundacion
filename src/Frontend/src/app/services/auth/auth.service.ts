// smtp-configuration.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';

import { environment } from '../../../environments/environment';
import { AuthRequest } from '../../models/authentication/auth-request';
import { AuthDTO } from '../../models/authentication/interfaces.auth';
 
@Injectable({
  providedIn: 'root'
})

export class AuthService {
  private authTokenKey = 'da8c2771831e4f97aa0291faf4cccee7';
  private authTokenExpiration="e36dc256da2f4d25bdbd45cdc106907e";
  private identificationValue: string = '';


  constructor(private http: HttpClient,private router: Router) {
    console.log(environment);
  }


  setIdentification(value: string): void {
    this.identificationValue = value;
  }

  getIdentification(): string {
    return this.identificationValue;
  }


  SendCodeToResetPassword(sendCodeRequest: any):Observable<any>{
    return this.http.post(environment.serverAma+"api/Auth/SendCodeToResetPassword",sendCodeRequest);
  }
  login(authRequest: AuthRequest): Observable<AuthDTO> {
    return this.http.post<AuthDTO>(`${environment.serverAma}api/Auth`, authRequest);
  }

  ResetPassword(sendCodeRequest: any):Observable<any>{
    return this.http.post(`${environment.serverAma}api/Auth/ResetPassword`,sendCodeRequest);
  }


  saveAuthToken(token: string, expirationDate: Date): void {
    localStorage.setItem(this.authTokenKey, token);

     localStorage.setItem(this.authTokenExpiration,expirationDate.toString());
  }

  getAuthToken(): string | null {
    return localStorage.getItem(this.authTokenKey);
  }

  logout(): void {
    localStorage.removeItem(this.authTokenKey);
    localStorage.removeItem(this.authTokenExpiration);
    this.router.navigate(['/auth/login']);
  }

  isLoggedIn(): boolean {
    const authToken = this.getAuthToken();
    const expirationDate = localStorage.getItem(this.authTokenExpiration);

    if (authToken && expirationDate) {
      const expirationDateTime = new Date(expirationDate).getTime();
      const currentDateTime = new Date().getTime();

      const hasExpired = currentDateTime - expirationDateTime > 24 * 60 * 60 * 1000;

      if (hasExpired) {
        this.logout();
        return false;
      }

      return true;
    }

    return false;
  }

}
