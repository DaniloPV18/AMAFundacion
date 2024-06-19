export interface Donaciones {
    id?: string;
    nombre_donacion: string;
    tipo_donacion: string;
    valor: string;
    total: string;
    donante: string;
    fecha_donacion: string;
  }
  
  export interface ResponseResult {

    message: string;
    statusCode: string;
    success: boolean;
  }
  export interface ResponseResultGeneric<T> extends ResponseResult {
    result: T;
  }
  
  export interface ResponseResultList<T> extends ResponseResult {
    result: T[];
  }
  export interface DonacionesResponse {
    pageNumber: number;
    pageSize: number;
    length: number;
    totalPages: number;
    hasPrevious: boolean;
    hasNext: boolean;
   
  }

  export interface Donacion {
    id: number;
    name: string;
    status: string;
  }
  export interface DonacionRequest {
    name: string;
    donationTypeId: number;
    price: number;
    total: number;
    personId: number;
    brigadeId: number;
    status: string;
  }
