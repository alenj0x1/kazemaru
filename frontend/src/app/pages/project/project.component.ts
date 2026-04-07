import { Component, OnInit } from '@angular/core';
import IProject from '../../interfaces/IProject';
import { NgIconComponent, provideIcons } from '@ng-icons/core';
import { ActivatedRoute, Router } from '@angular/router';
import { DataService } from '../../services/data.service';
import { ProjectStatusComponent } from '../../components/project-status/project-status.component';
import ITask from '../../interfaces/ITask';
import {
  tablerClockPlay,
  tablerClockShare,
  tablerTrash,
  tablerEdit,
  tablerPlus,
} from '@ng-icons/tabler-icons';
import { ModalComponent } from '../../components/modal-form/modal.component';
import { HttpService } from '../../services/http.service';
import { MessageTypeEnum } from '../../interfaces/IMessage';
import { projectBanner } from '../../lib/parser';
import { CommonModule } from '@angular/common';
import { IAnimationsState } from '../../interfaces/app/animations-state.interface';
import { DEFAULT_STATE_ANIMATIONS } from '../../lib/consts.lib';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import IAppInfo from '../../interfaces/IAppInfo';

@Component({
  selector: 'app-project',
  standalone: true,
  imports: [
    NgIconComponent,
    ProjectStatusComponent,
    ModalComponent,
    CommonModule,
    ReactiveFormsModule,
  ],
  templateUrl: './project.component.html',
  styleUrl: './project.component.css',
  viewProviders: [
    provideIcons({ tablerClockPlay, tablerClockShare, tablerTrash, tablerEdit, tablerPlus }),
  ],
})
export class ProjectComponent implements OnInit {
  public project: IProject = {
    projectid: '',
    name: '',
    description: '',
    status: {
      projectstatusid: 0,
      name: '',
      description: '',
      namecolor: '',
      backgroundcolor: '',
    },
    tags: [],
    banner: null,
    createdat: '',
    updatedat: '',
  };
  private projectId: string | null = '';
  public projects: IProject[] = [];
  public tasks: ITask[] = [];
  public deleteModalActive: boolean = false;
  public editModalActive: boolean = false;
  public createTaskModalActive: boolean = false;
  public editTaskModalActive: boolean = false;
  public deleteTaskModalActive: boolean = false;
  public selectedTask: ITask | null = null;
  public editForm: FormGroup;
  public createTaskForm: FormGroup;
  public editTaskForm: FormGroup;
  public appInfo: IAppInfo = { tags: [], projectStatuses: [], taskStatuses: [] };
  public lib = {
    projectBanner,
  };
  public animations: IAnimationsState = DEFAULT_STATE_ANIMATIONS;
  private tasksLoaded: boolean = false;

  constructor(
    private readonly route: ActivatedRoute,
    private readonly data: DataService,
    private readonly http: HttpService,
    private readonly router: Router,
    private readonly formBuilder: FormBuilder
  ) {
    this.editForm = this.formBuilder.group({
      name: ['', [Validators.required, Validators.maxLength(50)]],
      description: [''],
      banner: [''],
      status: [-1, Validators.required],
    });

    this.createTaskForm = this.formBuilder.group({
      name: ['', [Validators.required, Validators.maxLength(50)]],
      description: [''],
      status: [1, Validators.required],
    });

    this.editTaskForm = this.formBuilder.group({
      name: ['', [Validators.required, Validators.maxLength(50)]],
      description: [''],
      status: [null],
    });
  }

  ngOnInit(): void {
    this.projectId = this.route.snapshot.paramMap.get('projectId');

    this.data.appInfo$.subscribe((data) => (this.appInfo = data));
    this.data.animations$.subscribe((data) => (this.animations = data));
    this.loadProjects();
  }

  loadProjects(): void {
    this.data.projects$.subscribe((data) => {
      this.projects = data;

      const gtProject = this.projects.find(
        (prj) => prj.projectid == this.projectId
      );
      if (gtProject) {
        this.project = gtProject;
        this.loadTasks();
        return;
      }

      this.data.loading.emit(true);
      this.http.getProject(this.projectId ?? '').subscribe({
        next: ({ data }) => {
          this.data.loading.emit(false);
          if (data) {
            this.projects.push(data);
            this.data.updateProjects(this.projects);

            this.project = data;
            this.loadTasks();
          }
        },
        error: () => {
          this.data.loading.emit(false);
          this.router.navigate(['projects']);
        },
      });
    });
  }

  loadTasks(): void {
    if (this.tasksLoaded) return;
    this.http.getTasks().subscribe({
      next: ({ data }) => {
        this.tasks = data.filter((t) => t.projectid === this.project.projectid);
        this.data.updateTasks(this.tasks);
        this.tasksLoaded = true;
      },
      error: ({ error }) => {
        this.data.message.emit({
          message: error.message,
          type: MessageTypeEnum.Error,
        });
      },
    });
  }

  clickDelete() {
    this.deleteModalActive = true;
  }

  clickEdit() {
    this.editForm.setValue({
      name: this.project.name,
      description: this.project.description ?? '',
      banner: this.project.banner ?? '',
      status: this.project.status.projectstatusid,
    });
    this.editModalActive = true;
  }

  updateProject() {
    const { name, description, banner, status } = this.editForm.value;

    this.data.loading.emit(true);

    this.http
      .updateProject({
        projectId: this.project.projectid,
        name: name || null,
        description: description || null,
        banner: banner || null,
        status: status !== -1 ? +status : null,
      })
      .subscribe({
        next: ({ data, message }) => {
          this.data.loading.emit(false);
          this.data.message.emit({ message, type: MessageTypeEnum.Success });

          this.project = data;
          const projectIndex = this.projects.findIndex(
            (prj) => prj.projectid == data.projectid
          );
          if (projectIndex > -1) {
            this.projects[projectIndex] = data;
            this.data.updateProjects(this.projects);
          }

          this.editModalActive = false;
        },
        error: ({ error }) => {
          this.data.loading.emit(false);
          this.data.message.emit({
            message: error.message,
            type: MessageTypeEnum.Error,
          });
        },
      });
  }

  deleteProject() {
    this.data.loading.emit(true);

    this.http.deleteProject(this.project.projectid).subscribe({
      next: ({ message }) => {
        this.data.loading.emit(false);
        this.data.message.emit({ message, type: MessageTypeEnum.Success });

        const projectIndex = this.projects.findIndex(
          (prj) => prj.projectid == this.project.projectid
        );
        if (projectIndex > -1) {
          this.projects.splice(projectIndex, 1);
          this.data.updateProjects(this.projects);

          this.router.navigate(['/projects']);
        }
      },
      error: ({ error }) => {
        this.data.loading.emit(false);
        this.data.message.emit({
          message: error.message,
          type: MessageTypeEnum.Error,
        });
      },
    });
  }

  clickCreateTask(): void {
    this.createTaskForm.reset({ name: '', description: '', status: 1 });
    this.createTaskModalActive = true;
  }

  createTask(): void {
    const { name, description, status } = this.createTaskForm.value;
    this.data.loading.emit(true);
    this.http
      .createTask({
        name,
        projectId: this.project.projectid,
        description: description || null,
        status: +status,
      })
      .subscribe({
        next: ({ data, message }) => {
          this.data.loading.emit(false);
          this.data.message.emit({ message, type: MessageTypeEnum.Success });
          this.tasks.push(data);
          this.data.updateTasks(this.tasks);
          this.createTaskModalActive = false;
        },
        error: ({ error }) => {
          this.data.loading.emit(false);
          this.data.message.emit({
            message: error.message,
            type: MessageTypeEnum.Error,
          });
        },
      });
  }

  clickEditTask(task: ITask): void {
    this.selectedTask = task;
    this.editTaskForm.setValue({
      name: task.name,
      description: task.description ?? '',
      status: task.status.taskstatusid,
    });
    this.editTaskModalActive = true;
  }

  updateTask(): void {
    if (!this.selectedTask) return;
    const { name, description, status } = this.editTaskForm.value;
    this.data.loading.emit(true);
    this.http
      .updateTask({
        taskId: this.selectedTask.taskid,
        name: name || null,
        projectId: this.project.projectid,
        description: description || null,
        status: status !== null ? +status : null,
      })
      .subscribe({
        next: ({ data, message }) => {
          this.data.loading.emit(false);
          this.data.message.emit({ message, type: MessageTypeEnum.Success });
          const idx = this.tasks.findIndex((t) => t.taskid === data.taskid);
          if (idx > -1) {
            this.tasks[idx] = data;
            this.data.updateTasks(this.tasks);
          }
          this.editTaskModalActive = false;
          this.selectedTask = null;
        },
        error: ({ error }) => {
          this.data.loading.emit(false);
          this.data.message.emit({
            message: error.message,
            type: MessageTypeEnum.Error,
          });
        },
      });
  }

  clickDeleteTask(task: ITask): void {
    this.selectedTask = task;
    this.deleteTaskModalActive = true;
  }

  deleteTask(): void {
    if (!this.selectedTask) return;
    this.data.loading.emit(true);
    this.http.deleteTask(this.selectedTask.taskid).subscribe({
      next: ({ message }) => {
        this.data.loading.emit(false);
        this.data.message.emit({ message, type: MessageTypeEnum.Success });
        const idx = this.tasks.findIndex(
          (t) => t.taskid === this.selectedTask!.taskid
        );
        if (idx > -1) {
          this.tasks.splice(idx, 1);
          this.data.updateTasks(this.tasks);
        }
        this.deleteTaskModalActive = false;
        this.selectedTask = null;
      },
      error: ({ error }) => {
        this.data.loading.emit(false);
        this.data.message.emit({
          message: error.message,
          type: MessageTypeEnum.Error,
        });
      },
    });
  }
}
