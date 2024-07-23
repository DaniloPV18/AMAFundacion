export interface DonationForm {
    name: string;
    donationTypeId: number;
    price: number;
    total: number;
    amount?: number;
    personId: number;
    brigadeId: number;
    assignedAt:Date;
    id?: number;
    donationType?: string;
    nameBrigade?: string;
    identificationPerson?: string;
    nameCompletedPerson?: string;
}
