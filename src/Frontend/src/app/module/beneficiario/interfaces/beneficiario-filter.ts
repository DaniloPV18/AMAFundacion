import { RequestPaginated } from '../../../core/interfaces/menu-item';

export interface beneficiarioFilter extends RequestPaginated {
  Identification?: string;
  PersonId?:number|null;
  Name?:string;
  Email?:string;
}
