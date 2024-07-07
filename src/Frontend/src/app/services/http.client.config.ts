import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class HttpClientConfig {

  private apiUrl = 'http://127.0.0.1:7130';

  constructor() {}

Auth(): string{
  return `${this.apiUrl}/api/Auth`
}

Smtp(): string{
  return `${this.apiUrl}/api/smtp`
}

Usuario(): string{
  return `${this.apiUrl}/api/smtp`
}



}
