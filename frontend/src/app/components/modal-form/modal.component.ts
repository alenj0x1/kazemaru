import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { NgIconComponent, provideIcons } from '@ng-icons/core';
import { tablerCarrot, tablerCheck } from '@ng-icons/tabler-icons';

@Component({
  selector: 'app-modal',
  standalone: true,
  imports: [NgIconComponent, CommonModule],
  templateUrl: './modal.component.html',
  styleUrl: './modal.component.css',
  viewProviders: [provideIcons({ tablerCarrot, tablerCheck })],
})
export class ModalComponent {
  @Input({ required: true })
  public title: string = '';
  @Input({ required: true })
  public active: boolean = false;
  @Output()
  public next = new EventEmitter<boolean>();
  @Output()
  public activeChange = new EventEmitter<boolean>();

  onCancel() {
    this.active = !this.active;
    this.activeChange.emit(this.active);
  }

  onNext() {
    this.next.emit(true);
  }
}
