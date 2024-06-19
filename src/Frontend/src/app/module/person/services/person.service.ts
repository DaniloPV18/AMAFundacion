import { Injectable } from '@angular/core';

import { HttpClient } from '@angular/common/http';
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

  private createDonorSource = new Subject<void>();
  createDonor$ = this.createDonorSource.asObservable();
  triggerCreateDonor() {
    this.createDonorSource.next();
  }

}
