import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import IApiResponse from '../interfaces/IApiResponse';
import IProject from '../interfaces/IProject';
import IProjectCreateRequest from '../interfaces/requests/projects/IProjectCreateRequest';
import IProjectUpdateRequest from '../interfaces/requests/projects/IProjectUpdateRequest';
import IProjectStatusCreateRequest from '../interfaces/requests/projects/status/IProjectStatusCreateRequest';
import IProjectStatusUpdateRequest from '../interfaces/requests/projects/status/IProjectStatusUpdateRequest';
import ITaskStatusCreateRequest from '../interfaces/requests/tasks/status/ITaskStatusCreateRequest';
import ITask from '../interfaces/ITask';
import INote from '../interfaces/INote';
import INoteCreateRequest from '../interfaces/requests/notes/INoteCreateRequest';
import IProjectStatus from '../interfaces/IProjectStatus';
import ITaskStatus from '../interfaces/ITaskStatus';
import ITaskStatusUpdateRequest from '../interfaces/requests/tasks/status/ITaskStatusUpdateRequest';
import IAppInfo from '../interfaces/IAppInfo';

@Injectable({
  providedIn: 'root',
})
export class HttpService {
  private baseURL: string = 'http://localhost:5149/api';

  constructor(private http: HttpClient) {}

  // POST
  createProject(body: IProjectCreateRequest) {
    return this.http.post<IApiResponse<IProject>>(`${this.baseURL}/projects`, body);
  }

  createProjectStatus(body: IProjectStatusCreateRequest) {
    return this.http.post<IApiResponse<IProjectStatus>>(`${this.baseURL}/projects/status`, body);
  }

  createNote(body: INoteCreateRequest) {
    return this.http.post<IApiResponse<INote>>(`${this.baseURL}/notes`, body);
  }

  createTask(body: IProjectCreateRequest) {
    return this.http.post<IApiResponse<ITask>>(`${this.baseURL}/tasks`, body);
  }

  createTaskStatus(body: ITaskStatusCreateRequest) {
    return this.http.post<IApiResponse<ITaskStatus>>(`${this.baseURL}/tasks/status`, body);
  }

  // GET
  get appInfo() {
    return this.http.get<IApiResponse<IAppInfo>>(`${this.baseURL}/app/info`);
  }

  getProject(id: string) {
    return this.http.get<IApiResponse<IProject | null>>(`${this.baseURL}/projects/${id}`);
  }

  getProjects() {
    return this.http.get<IApiResponse<IProject[]>>(`${this.baseURL}/projects`);
  }

  getNote(id: string) {
    return this.http.get<IApiResponse<INote | null>>(`${this.baseURL}/notes/${id}`);
  }

  getNotes() {
    return this.http.get<IApiResponse<INote[]>>(`${this.baseURL}/notes`);
  }

  getTask(id: string) {
    return this.http.get<IApiResponse<ITask | null>>(`${this.baseURL}/tasks/${id}`);
  }

  getTasks() {
    return this.http.get<IApiResponse<ITask[]>>(`${this.baseURL}/tasks`);
  }

  // PUT
  updateProject(body: IProjectUpdateRequest) {
    return this.http.put<IApiResponse<IProject>>(`${this.baseURL}/projects`, body);
  }

  updateProjectStatus(body: IProjectStatusUpdateRequest) {
    return this.http.put<IApiResponse<IProjectStatus>>(`${this.baseURL}/projects/status`, body);
  }

  updateNote(body: IProjectUpdateRequest) {
    return this.http.put<IApiResponse<INote>>(`${this.baseURL}/notes`, body);
  }

  updateTask(body: IProjectUpdateRequest) {
    return this.http.put<IApiResponse<ITask>>(`${this.baseURL}/tasks`, body);
  }

  updateTaskStatus(body: ITaskStatusUpdateRequest) {
    return this.http.put<IApiResponse<ITaskStatus>>(`${this.baseURL}/tasks/status`, body);
  }

  // DELETE
  deleteProject(id: string) {
    return this.http.delete<IApiResponse<boolean>>(`${this.baseURL}/projects/${id}`);
  }

  deleteProjectStatus(id: string) {
    return this.http.delete<IApiResponse<boolean>>(`${this.baseURL}/projects/status/${id}`);
  }

  deleteNote(id: string) {
    return this.http.delete<IApiResponse<boolean>>(`${this.baseURL}/notes/${id}`);
  }

  deleteTask(id: string) {
    return this.http.delete<IApiResponse<boolean>>(`${this.baseURL}/tasks/${id}`);
  }

  deleteTaskStatus(id: string) {
    return this.http.delete<IApiResponse<boolean>>(`${this.baseURL}/tasks/status/${id}`);
  }
}
