import { Injectable } from '@angular/core';
import { HttpService } from './http.service';
import { jwtDecode, JwtPayload } from 'jwt-decode';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  constructor(private readonly http: HttpService) {}

  create(token: string) {
    localStorage.setItem('token', token);
    return token;
  }

  remove() {
    localStorage.removeItem('token');
  }

  get token() {
    return localStorage.getItem('token');
  }

  get decoded() {
    const token = this.token;
    if (!token) return null;

    return jwtDecode(token);
  }

  expired(jwt: JwtPayload) {
    if (!jwt.exp) return 0;
    return jwt.exp * 1000 - new Date().getTime();
  }

  checkRenew(): void {
    const decoded = this.decoded;
    if (!decoded) return;

    const expired = this.expired(decoded);

    if (expired > 0) {
      setTimeout(() => {
        this.renew();
      }, expired - 10000);

      return;
    }

    this.renew();
  }

  renew() {
    this.http.renewAuth.subscribe({
      next: ({ data }) => {
        this.create(data);
        this.checkRenew();
      },
    });
  }
}
