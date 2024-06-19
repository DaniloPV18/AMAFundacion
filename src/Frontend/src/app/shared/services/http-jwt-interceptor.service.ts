import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AuthService } from '../../services/auth/auth.service';

@Injectable()

export class HttpJwtInterceptorService implements HttpInterceptor {

  constructor(private authService: AuthService) {}

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    if (!request.headers.has('Authorization')){
      const bearer = request.headers.set('Authorization', `Bearer ${this.authService.getAuthToken()}`);
      request = request.clone({ headers: bearer });
    }
        return next.handle(request);
    }
  }
