export interface PaginatedListWithOffset <T> {
    data: T[];
    PageNumber: number;
    totalCount: number;
}