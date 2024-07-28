import { Component, Input } from '@angular/core';
import IProject from '../../interfaces/IProject';
import { getProjectStatus } from '../../lib/parse';
import { NgIconComponent, provideIcons } from '@ng-icons/core';
import { tablerClockPlay, tablerClockShare } from '@ng-icons/tabler-icons'

@Component({
  selector: 'project-thumb',
  standalone: true,
  imports: [NgIconComponent],
  templateUrl: './project-thumb.component.html',
  styleUrl: './project-thumb.component.css',
  viewProviders: [provideIcons({ tablerClockPlay, tablerClockShare })]
})
export class ProjectThumbComponent {
  @Input({ required: true })
  public project: IProject = {
    projectId: '',
    name: '',
    description: '',
    status: 0,
    tags: [],
    createdAt: '',
    updatedAt: ''
  }
  public gtProjStatus = getProjectStatus;
}
