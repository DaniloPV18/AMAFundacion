import { Injectable } from '@angular/core';

import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Result, ResultData, ResultList, ResultPaged } from '../../../core/interfaces/result';
import { PersonDto } from '../interfaces/person-dto';
import { environment as environment } from '../../../../environments/environment';
import { PersonFilter } from '../interfaces/person-filter';
import { ConfSystemServiceService } from '../../../data/conf-system-service.service';
import { ToolsService } from '../../../services/tools.service';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PersonService {
  private apiUrl = environment.serverAma+ 'api/Person';

  constructor(private http: HttpClient,
    private tool: ToolsService,
    private config:ConfSystemServiceService) { }

  getAllPersons(filterrequest:PersonFilter): Observable<ResultPaged<PersonDto>> {
    const params = this.tool.getHttpParams(filterrequest);
    return this.http.get<ResultPaged<PersonDto>>(this.apiUrl, { params:params });
  }

  // getAllPersons(filter: PersonFilter): Observable<ResultPaged<PersonDto>> {
  //   let params = new HttpParams();
  //   if (filter.nombrePersona) {
  //     params = params.set('nombrePersona', filter.nombrePersona);
  //   }
  //   if (filter.identification) {
  //     params = params.set('identificacion', filter.identification.toString());
  //   }
  //   params = params.set('offset', filter.offset.toString());
  //   params = params.set('take', filter.take.toString());
  //   params = params.set('sort', filter.sort);

  //   return this.http.get<ResultPaged<PersonDto>>(this.apiUrl, { params });
  // }


  getPersonById(id: number): Observable<ResultData<PersonDto>> {
    return this.http.get<ResultData<PersonDto>>(`${this.apiUrl}/${id}`);
  }
  createPerson(person: PersonDto): Observable<Result> {
    return this.http.post<Result>(this.apiUrl, person);
  }
  updatePerson(person: PersonDto): Observable<Result> {
    return this.http.put<Result>(`${this.apiUrl}/${person.id}`, person);
  }
  deletePerson(id: number): Observable<Result> {
    return this.http.delete<Result>(`${this.apiUrl}/${id}`);
  }
//lo puse yo
  //getFilteredPersons(filter: PersonFilter): Observable<ResultPaged<PersonDto>> {
    //return this.http.post<ResultPaged<PersonDto>>(`${this.apiUrl}/filter`, filter);
  //}
  //

  private createDonorSource = new Subject<void>();
  createDonor$ = this.createDonorSource.asObservable();
  triggerCreateDonor() {
    this.createDonorSource.next();
  }

}
