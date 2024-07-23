// donor.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment as environment } from '../../../../environments/environment';
import {
  BehaviorSubject,
  Observable,
  Subject,
  catchError,
  mergeMap,
  throwError,
} from 'rxjs';
import { Result, ResultData, ResultList, ResultPaged } from '../../../core/interfaces/result';
import { PersonDto } from '../../person/interfaces/person-dto';
import { ConfSystemServiceService } from '../../../data/conf-system-service.service';
import { ToolsService } from '../../../services/tools.service';

@Injectable({
  providedIn: 'root',
})
export class DonorService {
  private apiUrl =environment.serverAma+'api/donor';

  private donorListSubject = new BehaviorSubject<any[]>([]);

  constructor(private http: HttpClient) {}

  getDonorList(): Observable<DonorListResponse> {
    return this.http.get<DonorListResponse>(this.apiUrl).pipe(
      catchError((error) => {
        console.error('Error al obtener la lista de donantes:', error);
        return throwError(error);
      })
    );
  }

  postDonor(donorData: any): Observable<any> {
    return this.http.post(this.apiUrl, donorData).pipe(
      catchError((error) => {
        console.error('Error al agregar el donante:', error);
        throw error;
      })
    );
  }

  updateDonor(donorId: number, donorData: any): Observable<any> {
    const apiUrl = `${this.apiUrl}/${donorId}`;
    return this.http.put(apiUrl, donorData).pipe(
      catchError((error) => {
        console.error('Error al actualizar el donante:', error);
        throw error;
      })
    );
  }
  deleteDonor(id: number): Observable<Result> {
    return this.http.delete<Result>(`${this.apiUrl}/${id}`);
  }
}
