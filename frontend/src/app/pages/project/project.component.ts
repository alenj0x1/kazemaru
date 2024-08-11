import { Component, OnInit } from '@angular/core';
import IProject from '../../interfaces/IProject';
import { NgIconComponent, provideIcons } from '@ng-icons/core';
import { ActivatedRoute, Router } from '@angular/router';
import { DataService } from '../../services/data.service';
import { ProjectStatusComponent } from '../../components/project-status/project-status.component';
import ITask from '../../interfaces/ITask';
import { tablerClockPlay, tablerClockShare } from '@ng-icons/tabler-icons';

@Component({
  selector: 'app-project',
  standalone: true,
  imports: [NgIconComponent, ProjectStatusComponent],
  templateUrl: './project.component.html',
  styleUrl: './project.component.css',
  viewProviders: [provideIcons({ tablerClockPlay, tablerClockShare })],
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

  constructor(private route: ActivatedRoute, private data: DataService, private router: Router) {
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
}
