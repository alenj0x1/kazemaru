import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { AuthService } from '../services/auth.service';

export const authGuard: CanActivateFn = (route, state) => {
  const auth = inject(AuthService);
  const router = inject(Router);
  const currentPath = route.url.toString();

  if (auth.token && ['login', ''].includes(currentPath)) {
    router.navigate(['projects']).then(() => true);
  }

  if (auth.token) return true;

  if (!auth.token && currentPath === 'login') {
    return true;
  } else {
    router.navigate(['login']);
  }

  return true;
};
