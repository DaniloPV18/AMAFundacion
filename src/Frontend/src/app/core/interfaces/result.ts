export interface Result {
    error: string;
    message: string;
    statusCode: string;
    success: boolean;
 
}
  
export interface ResultData<T> extends Result { 
    result: T;
}
export interface ResultList<T> extends Result {
    result: T[];
    pageNumber: number;
    pageSize: number;
    length: number;
    totalPages: number;
    hasPrevious: boolean;
    hasNext: boolean;
}
    
export interface ResultPaged<T> extends Result {
    result: T[];
    pageNumber: number;
    pageSize: number;
    length: number;
    totalPages: number;
    hasPrevious: boolean;
    hasNext: boolean;
}