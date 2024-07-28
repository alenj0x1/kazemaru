import { Component } from '@angular/core';
import { NgIconComponent, provideIcons } from '@ng-icons/core';
import { tablerDeviceGamepad } from '@ng-icons/tabler-icons';

@Component({
  selector: 'app-new-project',
  standalone: true,
  imports: [NgIconComponent],
  templateUrl: './new-project.component.html',
  styleUrl: './new-project.component.css',
  viewProviders: [provideIcons({ tablerDeviceGamepad })],
})
export class NewProjectComponent {}
