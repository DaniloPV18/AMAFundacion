export interface BrigadeDto {
    description: string;
    end: Date;
    name: string;
    start: Date;
    companyId: number;
    personId: number;
    id: number;
    identificationPerson?: string;
    nameCompletedPerson?: string;
    status?: string;
}
