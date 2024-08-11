import { EventEmitter, Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { HttpService } from './http.service';
import IProject from '../interfaces/IProject';
import IAppInfo from '../interfaces/IAppInfo';
import ITask from '../interfaces/ITask';
import { IMessage } from '../interfaces/IMessage';

@Injectable({
  providedIn: 'root',
})
export class DataService {
  private appInfoSubject = new BehaviorSubject<IAppInfo>({
    tags: [],
    projectStatuses: [],
    taskStatuses: [],
  });
  public appInfo$ = this.appInfoSubject.asObservable();

  private projSubject = new BehaviorSubject<IProject[]>([]);
  public projects$ = this.projSubject.asObservable();

  private tasksSubject = new BehaviorSubject<ITask[]>([]);
  public tasks$ = this.tasksSubject.asObservable();

  public loading = new EventEmitter<boolean>();
  public message = new EventEmitter<IMessage>();

  constructor(private http: HttpService) {
    this.http.appInfo.subscribe((res) => this.updateAppInfo(res.data));
    this.http.getProjects().subscribe((res) => this.updateProjects(res.data));
  }

  public updateAppInfo(data: IAppInfo): void {
    this.appInfoSubject.next(data);
  }

  public updateProjects(data: IProject[]): void {
    this.projSubject.next(data);
  }

  public updateTasks(data: ITask[]): void {
    this.tasksSubject.next(data);
  }
}
