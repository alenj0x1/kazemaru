import { Component, Input } from '@angular/core';
import { RouterLink } from '@angular/router';
import { NgIconComponent, provideIcons } from '@ng-icons/core';
import { tablerAtom2 } from '@ng-icons/tabler-icons'

@Component({
  selector: 'kazemaru',
  standalone: true,
  imports: [NgIconComponent, RouterLink],
  templateUrl: './kazemaru.component.html',
  styleUrl: './kazemaru.component.css',
  viewProviders: [provideIcons({ tablerAtom2 })]
})
export class KazemaruComponent {
  @Input()
  public redirect: boolean = false;
}
