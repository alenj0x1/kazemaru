import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import IApiResponse from '../interfaces/IApiResponse';
import IProject from '../interfaces/IProject';

@Injectable({
  providedIn: 'root'
})
export class HttpService {
  constructor(private http: HttpClient) { }

  get projects() {
    return this.http.get<IApiResponse<IProject[]>>('http://localhost:5149/api/projects/all');
  }
}
