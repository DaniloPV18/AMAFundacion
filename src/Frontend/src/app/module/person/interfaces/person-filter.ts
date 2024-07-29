import { RequestPaginated } from "../../../core/interfaces/menu-item";

export interface PersonFilter extends RequestPaginated {
  identification?: string;
  firstName?: string;
  lastName?: string;
  nombrePersona?: string;
  //identificacion?: number;
  offset: number;
  take: number;
  sort: string;
}
