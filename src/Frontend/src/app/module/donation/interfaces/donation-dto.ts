export interface DonationDto {
  id: number;
  donationType: string;
  name: string;
  donationTypeId: number;
  price: number;
  total: number;
  amount?: number;
  personId: number;
  assignedAt:Date;
  brigadeId: number;
  status: string;
  nameBrigade?: string;
  identificationPerson?: string;
  nameCompletedPerson?: string;
}


