import { HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ToolsService {

  constructor() { }

  public getHttpParams(params: any, prefix = ''): HttpParams {
    let httpParams = new HttpParams();
  
    for (const key in params) {
      if (params.hasOwnProperty(key)) {
        const value = params[key];
  
        if (value !== undefined && value !== null) {
          const paramKey = prefix ? `${prefix}.${key}` : key;
  
          if (typeof value === 'object' && !Array.isArray(value)) {
            httpParams = this.getHttpParams(value, paramKey);
          } else if (Array.isArray(value)) {
            for (const item of value) {
              httpParams = httpParams.append(paramKey, item.toString());
            }
          } else {
            httpParams = httpParams.set(paramKey, value.toString());
          }
        }
      }
    }
  
    return httpParams;
  }

}
