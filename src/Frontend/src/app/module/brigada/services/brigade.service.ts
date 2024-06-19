import { Injectable } from '@angular/core';
import { environment } from '../../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { ToolsService } from '../../../services/tools.service';
import { ConfSystemServiceService } from '../../../data/conf-system-service.service';
import { BrigadeFilter } from '../models/brigada-filter.interface';
import { BrigadeDto } from '../interfaces/brigade-dto';
import { Result, ResultData, ResultPaged } from '../../../core/interfaces/result';
import { Observable } from 'rxjs';



@Injectable({
  providedIn: 'root'
})
export class BrigadeService {
  private apiUrl = environment.serverAma+ 'api/Brigada';

  constructor(private http: HttpClient,
    private tools:ToolsService,
    private config:ConfSystemServiceService) { }

  getAllBrigades(filterrequest:BrigadeFilter): Observable<ResultPaged<BrigadeDto>> {
    const params = this.tools.getHttpParams(filterrequest);
    return this.http.get<ResultPaged<BrigadeDto>>(this.apiUrl, { params:params });
  }
  getBrigadeById(id: number): Observable<ResultData<BrigadeDto>> {
    return this.http.get<ResultData<BrigadeDto>>(`${this.apiUrl}/${id}`);
  }
  createBrigade(Brigade: BrigadeDto): Observable<Result> {
    return this.http.post<Result>(this.apiUrl, Brigade);
  }
  updateBrigade(Brigade: BrigadeDto): Observable<Result> {
    return this.http.put<Result>(`${this.apiUrl}/${Brigade.id}`, Brigade);
  }
  deleteBrigade(id: number): Observable<Result> {
    return this.http.delete<Result>(`${this.apiUrl}/${id}`);
  }
}
