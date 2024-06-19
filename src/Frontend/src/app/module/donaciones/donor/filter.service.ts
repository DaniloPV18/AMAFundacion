// filter.service.ts

import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class FilterService {
  private filtroSubject = new BehaviorSubject<any>({});
  filtro$: Observable<any> = this.filtroSubject.asObservable();

  actualizarFiltro(filtro: any) {
    this.filtroSubject.next(filtro);
  }
}
