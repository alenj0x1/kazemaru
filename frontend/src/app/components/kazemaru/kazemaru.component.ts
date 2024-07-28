import { Component } from '@angular/core';
import { NgIconComponent, provideIcons } from '@ng-icons/core';
import { tablerAtom2 } from '@ng-icons/tabler-icons'

@Component({
  selector: 'kazemaru',
  standalone: true,
  imports: [NgIconComponent],
  templateUrl: './kazemaru.component.html',
  styleUrl: './kazemaru.component.css',
  viewProviders: [provideIcons({ tablerAtom2 })]
})
export class KazemaruComponent {

}
