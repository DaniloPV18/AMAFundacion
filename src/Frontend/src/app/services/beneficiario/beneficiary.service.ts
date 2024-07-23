import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

import { AuthService } from '../auth/auth.service'
import { BeneficiaryDTO } from '../../models/beneficiario/beneficiary.interfaz';
import {environment } from '../../../environments/environment'

@Injectable({
  providedIn: 'root',
})

export class BeneficiarioService {
  constructor(private http: HttpClient, private authService: AuthService) {}

  getUsers(filter: any): Observable<BeneficiaryDTO[]> {
    const headers = new HttpHeaders().set('Authorization', `Bearer ${this.authService.getAuthToken()}`);
    return this.http.get<BeneficiaryDTO[]>(`${environment.serverAma}/api/User`, { headers, params: filter });
  }
}

