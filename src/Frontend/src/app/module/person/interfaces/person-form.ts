export interface PersonForm {
    Id?:number;
    firstName: string;
    secondName?: string;
    lastName: string;
    secondLastName?: string;
    nameCompleted?: string;
    email: string;
    donor?: boolean;
    volunteer?: boolean;
    identificationTypeId: string;
    identification: string;
    phone: string;
}
