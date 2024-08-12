import { Component, OnInit } from '@angular/core';
import IProject from '../../interfaces/IProject';
import { NgIconComponent, provideIcons } from '@ng-icons/core';
import { ActivatedRoute, Router } from '@angular/router';
import { DataService } from '../../services/data.service';
import { ProjectStatusComponent } from '../../components/project-status/project-status.component';
import ITask from '../../interfaces/ITask';
import { tablerClockPlay, tablerClockShare, tablerTrash } from '@ng-icons/tabler-icons';
import { ModalComponent } from '../../components/modal-form/modal.component';
import { HttpService } from '../../services/http.service';
import { MessageTypeEnum } from '../../interfaces/IMessage';

@Component({
  selector: 'app-project',
  standalone: true,
  imports: [NgIconComponent, ProjectStatusComponent, ModalComponent],
  templateUrl: './project.component.html',
  styleUrl: './project.component.css',
  viewProviders: [provideIcons({ tablerClockPlay, tablerClockShare, tablerTrash })],
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
    createdat: '',
    updatedat: '',
  };
  private projectId: string | null = '';
  public projects: IProject[] = [];
  public tasks: ITask[] = [];
  public deleteModalActive: boolean = false;

  constructor(
    private route: ActivatedRoute,
    private data: DataService,
    private http: HttpService,
    private router: Router
  ) {
    this.route;
  }

  ngOnInit(): void {
    this.projectId = this.route.snapshot.paramMap.get('projectId');

    this.loadProjects();

    if (this.project.projectid !== '') {
      this.data.tasks$.subscribe((data) => (this.tasks = data));
    }
  }

  loadProjects(): void {
    this.data.projects$.subscribe((data) => {
      this.projects = data;

      const gtProject = this.projects.find((prj) => prj.projectid == this.projectId);
      if (gtProject) {
        this.project = gtProject;
        return;
      }

      this.router.navigate(['/404']);
    });
  }

  clickDelete() {
    this.deleteModalActive = true;
  }

  deleteProject() {
    this.data.loading.emit(true);

    this.http.deleteProject(this.project.projectid).subscribe({
      next: ({ message }) => {
        this.data.loading.emit(false);
        this.data.message.emit({ message, type: MessageTypeEnum.Success });

        const projectIndex = this.projects.findIndex((prj) => prj.projectid == this.project.projectid);
        if (projectIndex > -1) {
          this.projects.splice(projectIndex, 1);
          this.data.updateProjects(this.projects);

          this.router.navigate(['/projects']);
        }
      },
      error: ({ error }) => {
        this.data.loading.emit(false);
        this.data.message.emit({ message: error.message, type: MessageTypeEnum.Error });
      },
    });
  }
}
