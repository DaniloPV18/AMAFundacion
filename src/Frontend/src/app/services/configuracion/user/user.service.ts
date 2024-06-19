
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

import { AuthService } from '../../auth/auth.service'

import {environment } from '../../../../environments/environment'
import { UserDTO } from '../../../models/users/user-dto';
import { ToolsService } from '../../../../app/services/tools.service'

@Injectable({
  providedIn: 'root',
})
export class UserService {
  constructor(private http: HttpClient,
    private tools:ToolsService,
    private authService: AuthService) {}

  getUsers(filter: any): Observable<UserDTO[]> {

    return this.http.get<UserDTO[]>(`${environment.serverAma}api/User`, {  params: filter });
  }

  Create(user: any): Observable<UserDTO> {

    return this.http.post<UserDTO>(`${environment.serverAma}api/User`,user);
  }

  Put(user: any): Observable<UserDTO> {

    return this.http.put<UserDTO>(`${environment.serverAma}api/User/${user.id}`,user);
  }
}
