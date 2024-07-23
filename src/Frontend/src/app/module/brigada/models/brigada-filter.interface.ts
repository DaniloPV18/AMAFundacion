export interface BrigadeFilter {
    id?: number | string;
    companyId?: number | string;
    personId?: number | string;
    name?: string;
    descripction?: string;
    start?: Date,
    end?: Date,
    offset: number,
    take: number,
    sort: string,
}
