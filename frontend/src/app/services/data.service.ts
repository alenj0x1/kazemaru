import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { HttpService } from './http.service';
import IProject from '../interfaces/IProject';

@Injectable({
  providedIn: 'root',
})
export class DataService {
  private projSubject = new BehaviorSubject<IProject[]>([]);
  public projects$ = this.projSubject.asObservable();

  constructor(private http: HttpService) {
    this.http.getProjects().subscribe((res) => this.updateProjects(res.data));
  }

  public updateProjects(data: IProject[]): void {
    this.projSubject.next(data);
  }
}
