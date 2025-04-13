import { HttpErrorResponse, HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { catchError, switchMap, throwError } from 'rxjs';
import { Router } from '@angular/router';

export const httpInterceptor: HttpInterceptorFn = (req, next) => {
  const auth = inject(AuthService);
  const router = inject(Router);
  const token = auth.token;

  const request = req.clone({
    headers: req.headers.append(
      'Authorization',
      token !== null ? `Bearer ${token}` : ''
    ),
  });

  return next(request).pipe(
    catchError((err: HttpErrorResponse) => {
      if (err.status === 401 && !err.error) {
        auth.remove();
        router.navigate(['login']);
      }

      return throwError(() => err);
    })
  );
};
