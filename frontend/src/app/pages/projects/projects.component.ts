import { AfterViewInit, Component, OnInit } from '@angular/core';
import { HttpService } from '../../services/http.service';
import { DataService } from '../../services/data.service';
import IProject from '../../interfaces/IProject';
import { ProjectThumbComponent } from '../../components/project-thumb/project-thumb.component';
import { tablerPlus } from '@ng-icons/tabler-icons';
import { NgIconComponent, provideIcons } from '@ng-icons/core';
import { ActivatedRoute, RouterLink } from '@angular/router';

@Component({
  selector: 'app-projects',
  standalone: true,
  imports: [ProjectThumbComponent, NgIconComponent, RouterLink],
  templateUrl: './projects.component.html',
  styleUrl: './projects.component.css',
  viewProviders: [provideIcons({ tablerPlus })],
})
export class ProjectsComponent implements OnInit, AfterViewInit {
  public projects: IProject[] = [];
  public fragment: string | null = '';

  constructor(
    private readonly http: HttpService,
    private readonly data: DataService,
    private readonly route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.http.getProjects().subscribe(({ data }) => {
      this.data.updateProjects(data);
    });

    this.data.projects$.subscribe((data) => (this.projects = data));
    this.route.fragment.subscribe((fragment) => (this.fragment = fragment));
  }

  ngAfterViewInit(): void {
    if (this.fragment) {
      document
        .getElementById(this.fragment)
        ?.scrollIntoView({ behavior: 'smooth', block: 'start' });
    }
  }
}
