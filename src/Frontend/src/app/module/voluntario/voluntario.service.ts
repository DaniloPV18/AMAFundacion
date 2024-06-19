// donor.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable,Subject, catchError, mergeMap, throwError } from 'rxjs';
import { environment as environment } from '../../../environments/environment';
import { Result, ResultData, ResultList, ResultPaged } from '../../core/interfaces/result';

@Injectable({
  providedIn: 'root',
})

export class VoluntarioService {

  private apiUrl =environment.serverAma+'api/volunteer';


  constructor(private http: HttpClient) {}

  getVoluntarioList(): Observable<VoluntarioListResponse> {
    return this.http.get<VoluntarioListResponse>(this.apiUrl).pipe(
      catchError((error) => {
        console.error('Error al obtener la lista de donantes:', error);
        return throwError(error);
      })
    );
  }

  postVoluntario(voluntarioData: any): Observable<any> {

 // private apiUrl = 'http://localhost:3000/api/voluntario';
    const apiUrl = 'assets/voluntario.json';

  
    return this.http.post(apiUrl, voluntarioData).pipe(
      catchError((error) => {
        console.error('Error al agregar el voluntario:', error);
        throw error;
      })
    );
  }
  
/*
  postVoluntario(voluntarioData: any): Observable<any> {
    //const  apiUrl = 'http://localhost:3000/api/voluntario';
    const  apiUrl = 'assets/voluntario.json';

    return this.http.post(apiUrl, voluntarioData).pipe(
      catchError((error) => {
        console.error('Error al agregar el voluntario:', error);
        throw error; 
      })
    );
  }*/
  
  updateVoluntario(donorId: number, donorData: any): Observable<any> {
    const apiUrl = `${this.apiUrl}/${donorId}`;
    return this.http.put(apiUrl, donorData).pipe(
      catchError((error) => {
        console.error('Error al actualizar el voluntario:', error);
        throw error; 
      })
    );
  }
  deleteVoluntario(id: number): Observable<Result> {
    return this.http.delete<Result>(`${this.apiUrl}/${id}`);
  }
  
}