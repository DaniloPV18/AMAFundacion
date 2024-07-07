import { Injectable } from '@angular/core';

import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Result, ResultData, ResultList, ResultPaged } from '../../../core/interfaces/result';
import { beneficiarioDto } from '../interfaces/beneficiario-dto';
import { environment as environment } from '../../../../environments/environment';
import { beneficiarioFilter } from '../interfaces/beneficiario-filter';
import { ConfSystemServiceService } from '../../../data/conf-system-service.service';
import { ToolsService } from '../../../services/tools.service';

@Injectable({
  providedIn: 'root'
})
export class beneficiarioService {
  private apiUrl = environment.serverAma+ 'api/Beneficiary';
  // private apiUrl = environment.serverAma+ 'api/Person';

  constructor(private http: HttpClient,
    private tool: ToolsService,
    private config:ConfSystemServiceService) { }

  getAllbeneficiarios(filterrequest:beneficiarioFilter): Observable<ResultPaged<beneficiarioDto>> {
    const params = this.tool.getHttpParams(filterrequest);
    return this.http.get<ResultPaged<beneficiarioDto>>(this.apiUrl, { params:params });
  }
  getbeneficiarioById(id: number): Observable<ResultData<beneficiarioDto>> {
    return this.http.get<ResultData<beneficiarioDto>>(`${this.apiUrl}/${id}`);
  }
  createbeneficiario(beneficiario: beneficiarioDto): Observable<Result> {
    return this.http.post<Result>(this.apiUrl, beneficiario);
  }
  updatebeneficiario(beneficiario: beneficiarioDto): Observable<Result> {
    return this.http.put<Result>(`${this.apiUrl}/${beneficiario.id}`, beneficiario);
  }
  deletebeneficiario(id: number): Observable<Result> {
    return this.http.delete<Result>(`${this.apiUrl}/?id=${id}`);
  }
}
