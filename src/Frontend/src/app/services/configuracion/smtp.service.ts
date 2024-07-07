// smtp-configuration.service.ts
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

import { environment } from '../../../environments/environment';
import { AuthService } from '../auth/auth.service';


@Injectable({
  providedIn: 'root',
})
export class SmtpConfigurationService {
  constructor(private http: HttpClient, private auth: AuthService) {}

  getAllConfigurations(data:any): Observable<any> {

    const headers = new HttpHeaders().set('Authorization', `Bearer ${this.auth.getAuthToken()}`);
    return this.http.get(environment.serverAma+'api/SmtpConfiguration',{ headers });
  }

  addSmtpConfig(dataUser: any):Observable<any>{

    const headers = new HttpHeaders().set('Authorization', `Bearer ${this.auth.getAuthToken()}`);
    return this.http.post(environment.serverAma+'api/SmtpConfiguration',dataUser,{ headers});

  }

  updateSmtpConfig(id:number,dataUser: any):Observable<any>{
    const headers = new HttpHeaders().set('Authorization', `Bearer ${this.auth.getAuthToken()}`);
      return this.http.put(`${environment.serverAma}api/SmtpConfiguration/${id}`,dataUser,{ headers});
  }

  updateSmtpPassword(id:number,password: string):Observable<any>{
    var headers = new HttpHeaders();
    headers=headers.delete('Content-Type');
     headers=headers.set('Authorization', `Bearer ${this.auth.getAuthToken()}`);
     headers=headers.set('Content-Type','application/json')

      return this.http.put(`${environment.serverAma}api/SmtpConfiguration/password/${id}`,`"${password}"`,{ headers});

  }


}
