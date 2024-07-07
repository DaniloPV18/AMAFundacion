export interface beneficiarioForm {
  description: string;
  person: {
    email: string;
    firstName: string;
    identification: string;
    identificationTypeId?: string;
    lastName: string;
    nameCompleted?: string;
    phone: string;
    secondLastName: string;
    secondName: string;
    status?: string;
  }
}
