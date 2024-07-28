import { Component, Input } from '@angular/core';
import IProject from '../../interfaces/IProject';
import { NgIconComponent, provideIcons } from '@ng-icons/core';
import { tablerClockPlay, tablerClockShare } from '@ng-icons/tabler-icons';

@Component({
  selector: 'project-thumb',
  standalone: true,
  imports: [NgIconComponent],
  templateUrl: './project-thumb.component.html',
  styleUrl: './project-thumb.component.css',
  viewProviders: [provideIcons({ tablerClockPlay, tablerClockShare })],
})
export class ProjectThumbComponent {
  @Input({ required: true })
  public project: IProject = {
    projectId: '',
    name: '',
    description: '',
    status: {
      projectStatusId: '',
      name: '',
      description: '',
      nameColor: '',
      backgroundColor: '',
    },
    tags: [],
    createdAt: '',
    updatedAt: '',
  };
}
