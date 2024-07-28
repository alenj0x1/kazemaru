import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { NgIconComponent, provideIcons } from '@ng-icons/core';
import { tablerMenu2, tablerNote, tablerAtom2 } from '@ng-icons/tabler-icons'
import { heroRectangleStack } from '@ng-icons/heroicons/outline'
import { KazemaruComponent } from '../kazemaru/kazemaru.component';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [NgIconComponent, CommonModule, KazemaruComponent, RouterLink],
  templateUrl: './header.component.html',
  styleUrl: './header.component.css',
  viewProviders: [provideIcons({ tablerMenu2, tablerNote, heroRectangleStack, tablerAtom2 })]
})
export class HeaderComponent { 
  public hideMenu: boolean = true;

  onShowMenu() {
    this.hideMenu = !this.hideMenu;
  }
}
