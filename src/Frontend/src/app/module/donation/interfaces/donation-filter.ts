export interface DonationFilter {
  name?: string;
  donationTypeId?: number;
  id?: number;
  personId?: number;
  brigadeId?: number;
  offset: number;
  take: number;
  sort: string;
}
