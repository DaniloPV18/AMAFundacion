export interface PersonDto {
    id: number;
    firstName: string;
    secondName?: string;
    lastName: string;
    secondLastName?: string;
    nameCompleted?: string;
    email: string;
    donor: boolean;
    valunteer: boolean;
    identificationTypeId: string;
    identification: string;
    phone: string;

}
