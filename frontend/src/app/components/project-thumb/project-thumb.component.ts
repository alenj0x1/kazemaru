import { Component, Input, OnInit } from '@angular/core';
import IProject from '../../interfaces/IProject';
import { NgIconComponent, provideIcons } from '@ng-icons/core';
import { tablerClockPlay, tablerClockShare } from '@ng-icons/tabler-icons';
import { ProjectStatusComponent } from '../project-status/project-status.component';
import { RouterLink } from '@angular/router';
import { projectBanner } from '../../lib/parser';
import { CommonModule } from '@angular/common';
import { IAnimationsState } from '../../interfaces/app/animations-state.interface';
import { DataService } from '../../services/data.service';
import { DEFAULT_STATE_ANIMATIONS } from '../../lib/consts.lib';

@Component({
  selector: 'project-thumb',
  standalone: true,
  imports: [NgIconComponent, ProjectStatusComponent, RouterLink, CommonModule],
  templateUrl: './project-thumb.component.html',
  styleUrl: './project-thumb.component.css',
  viewProviders: [provideIcons({ tablerClockPlay, tablerClockShare })],
})
export class ProjectThumbComponent implements OnInit {
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
  public animations: IAnimationsState = DEFAULT_STATE_ANIMATIONS

  constructor(private readonly data: DataService) {}

  ngOnInit(): void {
    this.data.animations$.subscribe(data => this.animations = data);
  }
}
