interface VoluntarioListResponse {
    pageNumber: number;
    pageSize: number;
    totalPages: number;
    hasPrevious: boolean;
    hasNext: boolean;
    length: number;
    result: Volunteer[];
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
      interface Volunteer {
        id: number;
        person: Person;
        personId: number;
        gender:string;
        address:string;
        status:string;
        availability:boolean;
        startDate:Date;
        endDate:Date;
        activityTypeId:number;
      }
