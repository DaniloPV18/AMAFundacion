import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { DonationDto } from '../interfaces/donation-dto';
import { DonationFilter } from '../interfaces/donation-filter';
import { Result, ResultData, ResultPaged } from '../../../core/interfaces/result';
import { Observable } from 'rxjs';
import { environment } from '../../../../environments/environment';
import { ConfSystemServiceService } from '../../../data/conf-system-service.service';
import { ToolsService } from '../../../services/tools.service';

@Injectable({
  providedIn: 'root'
})
export class DonationService {
  private apiUrl = environment.serverAma+ 'api/donation';

  constructor(private http: HttpClient,
    private tools:ToolsService,
    private config:ConfSystemServiceService) { }

  GetAlldonations(filterrequest:DonationFilter): Observable<ResultPaged<DonationDto>> {
    const params = this.tools.getHttpParams(filterrequest);
    return this.http.get<ResultPaged<DonationDto>>(this.apiUrl, { params:params });
  }
  GetdonationById(id: number): Observable<ResultData<DonationDto>> {
    return this.http.get<ResultData<DonationDto>>(`${this.apiUrl}/${id}`);
  }
  createdonation(donation: DonationDto): Observable<Result> {
    return this.http.post<Result>(this.apiUrl, donation);
  }
  updatedonation(donation: DonationDto): Observable<Result> {
    return this.http.put<Result>(`${this.apiUrl}/${donation.id}`, donation);
  }
  deletedonation(id: number): Observable<Result> {
    return this.http.delete<Result>(`${this.apiUrl}/${id}`);
  }
}
