import { EventEmitter, Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { HttpService } from './http.service';
import IProject from '../interfaces/IProject';
import IAppInfo from '../interfaces/IAppInfo';
import ITask from '../interfaces/ITask';
import { IMessage } from '../interfaces/IMessage';
import { IAnimationsState } from '../interfaces/app/animations-state.interface';
import { DEFAULT_STATE_ANIMATIONS } from '../lib/consts.lib';

@Injectable({
  providedIn: 'root',
})
export class DataService {
  private readonly appInfoSubject = new BehaviorSubject<IAppInfo>({
    tags: [],
    projectStatuses: [],
    taskStatuses: [],
  });
  public appInfo$ = this.appInfoSubject.asObservable();

  private readonly projSubject = new BehaviorSubject<IProject[]>([]);
  public projects$ = this.projSubject.asObservable();

  private readonly tasksSubject = new BehaviorSubject<ITask[]>([]);
  public tasks$ = this.tasksSubject.asObservable();

  private readonly authSubject = new BehaviorSubject<boolean>(false);
  public auth$ = this.authSubject.asObservable();

  private readonly animationsSubject = new BehaviorSubject<IAnimationsState>(DEFAULT_STATE_ANIMATIONS);
  public animations$ = this.animationsSubject.asObservable();

  public loading = new EventEmitter<boolean>();
  public message = new EventEmitter<IMessage>();

  constructor(private readonly http: HttpService) {
    this.initAnimations();
    this.http.appInfo.subscribe((res) => this.updateAppInfo(res.data));
  }

  public initAnimations() {
    let data = localStorage.getItem('animations');
    if (!data) {
      const firstData: IAnimationsState = DEFAULT_STATE_ANIMATIONS;

      localStorage.setItem('animations', JSON.stringify(firstData));
      data = localStorage.getItem('animations');
    }

    const parsedData = JSON.parse(data as string);
    this.updateAnimations(parsedData);
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

  public updateAuth(data: boolean): void {
    this.authSubject.next(data);
  }

  public updateAnimations(data: IAnimationsState): void {
    localStorage.setItem('animations', JSON.stringify(data));
    this.animationsSubject.next(data);
  }
}
