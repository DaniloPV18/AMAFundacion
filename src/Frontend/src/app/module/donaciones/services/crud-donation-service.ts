import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../environments/environment';
import { Donacion, DonacionRequest, ResponseResultList } from '../../../models/donaciones/donaciones.interfaz';

@Injectable({
    providedIn: 'root'
})
export class CrudDonationService {
    private apiUrl = environment.serverAma + 'api/donations';

    constructor(private http: HttpClient) { }

    getDonations(): Observable<ResponseResultList<Donacion>> {
        return this.http.get<any>(this.apiUrl);
    }

    createDonation(donation: DonacionRequest): Observable<DonacionRequest> {
        return this.http.post<DonacionRequest>(this.apiUrl, donation);
    }

    updateDonation(id: number, donation: DonacionRequest): Observable<DonacionRequest> {
        const url = `${this.apiUrl}/${id}`;
        return this.http.put<DonacionRequest>(url, donation);
    }

    deleteDonation(id: DonacionRequest): Observable<DonacionRequest> {
        const url = `${this.apiUrl}/${id}`;
        return this.http.delete<DonacionRequest>(url);
    }
}
