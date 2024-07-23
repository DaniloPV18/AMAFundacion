
import { Injectable } from '@angular/core';

import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable, map } from 'rxjs';

import { Result, ResultList } from '../core/interfaces/result';
import { TypeIdentification } from '../core/configSystem/typeIdentification';
import { environment } from '../../environments/environment';
import { ToolsService } from '../services/tools.service';
import { TypeDonation } from '../core/configSystem/type-donation';



@Injectable({
  providedIn: 'root'
})

export class ConfSystemServiceService {
  private apiUrl = environment.serverAma;

  constructor(private http: HttpClient
    , private tools:ToolsService
    ) { }
    getTypeIdentification(): Observable<TypeIdentification[]> {
      return this.http.get<ResultList<TypeIdentification>>(this.apiUrl+'api/TypeIdentification')
        .pipe(
          map((response: ResultList<TypeIdentification>) => response.result)
        );
    }
    getTypeDonation(): Observable<TypeDonation[]> {
      return this.http.get<ResultList<TypeDonation>>(this.apiUrl+'api/DonationType')
        .pipe(
          map((response: ResultList<TypeDonation>) => response.result)
        );
    }

}
