import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';
import { PaginatedListWithOffset } from '../../../core/interfaces/paginated-list-offset';
import { Result, ResultData, ResultList } from '../../../core/interfaces/result';

import { environment } from '../../../../environments/environment';
import { CommunicationConstants } from '../../../core/constants/communication';

import { PersonDto } from '../../../module/person/interfaces/person-dto';
import { PersonFilter } from '../../../module/person/interfaces/person-filter';
import { ToolsService } from '../../../services/tools.service';
const API_MAIN = environment.serverAma;
@Injectable({
  providedIn: 'root'
})
export class PersonaDialogService {

  private URL : string = API_MAIN + "api/person";

	constructor(private _http: HttpClient,
    private tools: ToolsService
    ){}

	getPaginated(request : PersonFilter) : Observable<any>{
	 const params = this.tools.getHttpParams(request);
		return this._http
      .get<ResultList<PersonDto>>(this.URL, { params: params})
      .pipe(
        map((res: ResultList<PersonDto>) => {
          const [codigosCom, mensajesCom] = CommunicationConstants;
          if (res === null){
              throw new Error(`${codigosCom.ERRORSRV}||${mensajesCom.MSGDATAVACIOSRV}`);
          }
          if(!res.success){
              throw new Error(`${res.statusCode}||${res.message}`);
          }
          return res;
        })
      );
	}
}
