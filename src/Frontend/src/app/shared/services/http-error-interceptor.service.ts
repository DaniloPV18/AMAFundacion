import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MessageService } from 'primeng/api';
import { Observable, catchError, tap, throwError } from 'rxjs';

@Injectable()
export class HttpErrorInterceptorService implements HttpInterceptor {

  constructor(private messageService: MessageService) { }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const handleRequest = (req: HttpRequest<any>) => next.handle(req);

    const handleError = (error: HttpErrorResponse) => {

      let message: string = (error.status == 0) ?
        'Error de conexión. Por favor, verifica tu conexión a Internet.'
        :
        error.error && error.error.ErrorMessage ? error.error.ErrorMessage : 'Error';

      const severity = (error.status >= 500 || error.status <= 0) ? 'error' : (error.status >= 400 ? 'warn' : 'info');
      this.messageService.add({ severity: severity, summary: error.status >= 500 ? 'Error' : 'Error', detail: message });

      return throwError(error);
    };

    const handleSuccess = (event: HttpEvent<any>) => {
      if (request.method != 'GET')
        if (event instanceof HttpResponse && event.status >= 200 && event.status < 400) {
          const message = event.body && event.body.message ? event.body.message : 'Éxito';
          this.messageService.add({ severity: 'success', summary: 'Éxito', detail: message });
        }
      return event;
    };

    return handleRequest(request).pipe(
      catchError(handleError),
      tap(handleSuccess)
    );
  }

}
