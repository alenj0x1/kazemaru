import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { NgIconComponent, provideIcons } from '@ng-icons/core';
import { tablerAtom2 } from '@ng-icons/tabler-icons';
import { DataService } from '../../services/data.service';

@Component({
  selector: 'app-loading',
  standalone: true,
  imports: [NgIconComponent, CommonModule],
  templateUrl: './loading.component.html',
  styleUrl: './loading.component.css',
  viewProviders: [provideIcons({ tablerAtom2 })],
})
export class LoadingComponent implements OnInit {
  public active: boolean = false;

  constructor(private data: DataService) {}

  ngOnInit(): void {
    this.data.loading.subscribe((state) => (this.active = state));
  }
}
