import { Component, Input } from '@angular/core';
import IProjectStatus from '../../interfaces/IProjectStatus';

@Component({
  selector: 'app-project-status',
  standalone: true,
  imports: [],
  templateUrl: './project-status.component.html',
  styleUrl: './project-status.component.css',
})
export class ProjectStatusComponent {
  @Input({ required: true })
  public projectStatus: IProjectStatus = {
    projectstatusid: 0,
    name: '',
    namecolor: '',
    backgroundcolor: '',
    description: '',
  };
}
