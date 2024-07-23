import { Injectable } from '@angular/core';
import { BrigadeFilter } from '../../../module/brigada/models/brigada-filter.interface';
import { Observable, map } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { ToolsService } from '../../../services/tools.service';
import { BrigadeDto } from '../../../module/brigada/interfaces/brigade-dto';
import { ResultList } from '../../../core/interfaces/result';
import { environment } from '../../../../environments/environment';
import { CommunicationConstants } from '../../../core/constants/communication';
const API_MAIN = environment.serverAma;
@Injectable({
  providedIn: 'root'
})
export class BrigadeDialogService {

  private URL : string = API_MAIN + "api/Brigada";

	constructor(private _http: HttpClient,
    private tools: ToolsService
    ){}

	getPaginated(request : BrigadeFilter) : Observable<any>{
	 const params = this.tools.getHttpParams(request);
		return this._http
      .get<ResultList<BrigadeDto>>(this.URL, { params: params})
      .pipe(
        map((res: ResultList<BrigadeDto>) => {
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
