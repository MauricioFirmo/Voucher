
import { Injectable, NgModule } from '@angular/core';
import { HttpEvent, HttpInterceptor, HttpHandler, HttpRequest, HttpResponse } from '@angular/common/http';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Router } from '@angular/router';
import { User } from '../shared/model/user.model';

@Injectable()
export class HttpsRequestInterceptor implements HttpInterceptor {

    constructor() { }

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        let user: User = JSON.parse(localStorage.getItem('user'));
        // let headers = request.headers.set('Content-Type', 'application/json').set('Authorization', user.token);
        let headers = request.headers.set('Content-Type', 'application/json');
        const cloneReq = request.clone({ headers });

        return next.handle(cloneReq);
    }

};

@Injectable()
export class HttpsResponseInterceptor implements HttpInterceptor {

    constructor() { }

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        return next.handle(request).pipe(map(event => {
            return event;
        }));
    }
};

@NgModule({
    providers: [
        { provide: HTTP_INTERCEPTORS, useClass: HttpsRequestInterceptor, multi: true },
        { provide: HTTP_INTERCEPTORS, useClass: HttpsResponseInterceptor, multi: true }
    ]
})
export class InterceptorModule { }
