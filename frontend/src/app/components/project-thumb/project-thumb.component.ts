import { Component, Input } from '@angular/core';
import IProject from '../../interfaces/IProject';
import { NgIconComponent, provideIcons } from '@ng-icons/core';
import { tablerClockPlay, tablerClockShare } from '@ng-icons/tabler-icons';
import { ProjectStatusComponent } from '../project-status/project-status.component';
import { RouterLink } from '@angular/router';
import { projectBanner } from '../../lib/parser';

@Component({
  selector: 'project-thumb',
  standalone: true,
  imports: [NgIconComponent, ProjectStatusComponent, RouterLink],
  templateUrl: './project-thumb.component.html',
  styleUrl: './project-thumb.component.css',
  viewProviders: [provideIcons({ tablerClockPlay, tablerClockShare })],
})
export class ProjectThumbComponent {
  @Input({ required: true })
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
  public lib = {
    projectBanner,
  };
}
