import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MessageService } from 'primeng/api';
import { Observable, catchError, tap, throwError } from 'rxjs';

@Injectable()
export class HttpErrorInterceptorService implements HttpInterceptor {

  constructor(private messageService: MessageService) { }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(request).pipe(
      catchError((error: HttpErrorResponse) => {
        let message: string;
        if (error.status === 409) {
          message = error.error?.message || 'Error de conflicto';
        } else {
          message = error.error?.message || 'Error';
        }
        
        const severity = (error.status >= 500 || error.status <= 0) ? 'error' : 
                          (error.status >= 400 ? 'warn' : 'info');
        this.messageService.add({ severity: severity, summary: 'Error', detail: message });
        
        return throwError(() => error);
      }),
      tap((event: HttpEvent<any>) => {
        if (request.method !== 'GET' && event instanceof HttpResponse && event.status >= 200 && event.status < 300) {
          const message = event.body?.message || 'Éxito';
          this.messageService.add({ severity: 'success', summary: 'Éxito', detail: message });
        }
        return event;
      })
    );
  }

}
