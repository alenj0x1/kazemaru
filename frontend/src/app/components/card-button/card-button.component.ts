import { Component, Input } from '@angular/core';
import { RouterLink } from '@angular/router';
import { NgIconComponent, provideIcons } from '@ng-icons/core';
import { heroPlus } from '@ng-icons/heroicons/outline'

@Component({
  selector: 'card-button',
  standalone: true,
  imports: [NgIconComponent, RouterLink],
  templateUrl: './card-button.component.html',
  styleUrl: './card-button.component.css',
  viewProviders: [provideIcons({ heroPlus })]
})
export class CardButtonComponent {
  @Input({ required: true })
  public title: string = '';
  @Input({ required: true })
  public route: string = '';
  @Input({ required: true })
  public icon:  string = '';
}
