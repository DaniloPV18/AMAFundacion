interface DonorListResponse {
  pageNumber: number;
  pageSize: number;
  totalPages: number;
  hasPrevious: boolean;
  hasNext: boolean;
  length: number;
  result: Donor[];
  message: string;
  statusCode: string;
  success: boolean;
  }
  interface Person {
    id: number;
    donor: boolean;
    email: string;
    firstName: string;
    identification: string;
    identificationTypeId: number;
    lastName: string;
    nameCompleted: string;
    phone: string;
    secondLastName: string;
    secondName: string;
    status: string;
    volunteer: boolean;
  }
  
  interface Donor {
    id: number;
    person: Person;
    personId: number;
    identificacion: string;
    nombreCompleto: string;
    phone: string;
    email: string;
    status: string;
  }
  
