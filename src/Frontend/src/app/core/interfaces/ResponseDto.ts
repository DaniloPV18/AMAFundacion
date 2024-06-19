export default interface ResponseOperation{
    message?: string,
    StatusCode?:number,
    Success:boolean
}
export interface ResponseOperationData<T> extends ResponseOperation{
    data?:T
}
export interface ResponseOperationDataList<T> extends ResponseOperation{
    data?:Array<T>
}