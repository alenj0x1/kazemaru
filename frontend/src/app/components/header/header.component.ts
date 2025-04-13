import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { NgIconComponent, provideIcons } from '@ng-icons/core';
import {
  tablerMenu2,
  tablerNote,
  tablerAtom2,
  tablerLogout,
} from '@ng-icons/tabler-icons';
import { heroRectangleStack } from '@ng-icons/heroicons/outline';
import { KazemaruComponent } from '../kazemaru/kazemaru.component';
import { Router, RouterLink } from '@angular/router';
import { HttpService } from '../../services/http.service';
import { AuthService } from '../../services/auth.service';
import { DataService } from '../../services/data.service';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [NgIconComponent, CommonModule, KazemaruComponent, RouterLink],
  templateUrl: './header.component.html',
  styleUrl: './header.component.css',
  viewProviders: [
    provideIcons({
      tablerMenu2,
      tablerNote,
      heroRectangleStack,
      tablerAtom2,
      tablerLogout,
    }),
  ],
})
export class HeaderComponent implements OnInit {
  public hideMenu: boolean = true;
  public authenticated: boolean = false;

  constructor(
    private readonly http: HttpService,
    private readonly data: DataService,
    private readonly auth: AuthService,
    private readonly router: Router
  ) {}

  ngOnInit(): void {
    if (this.auth.token) {
      this.data.updateAuth(true);
    }

    this.data.auth$.subscribe((data) => (this.authenticated = data));
  }

  onShowMenu() {
    this.hideMenu = !this.hideMenu;
  }

  onLogout() {
    this.data.loading.emit(true);

    this.http.logoutAuth().subscribe({
      next: () => {
        this.data.loading.emit(false);
        this.auth.remove();
        this.data.updateAuth(false);

        this.router.navigate(['login']);
      },
      error: (err) => {
        console.log(err);
        this.data.loading.emit(false);
      },
    });
  }
}
