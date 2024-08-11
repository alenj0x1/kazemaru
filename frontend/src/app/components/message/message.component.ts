import { Component, OnInit } from '@angular/core';
import { IMessage, MessageTypeEnum } from '../../interfaces/IMessage';
import { DataService } from '../../services/data.service';
import { CommonModule } from '@angular/common';
import { tablerRobotOff, tablerRobot, tablerSnowflake } from '@ng-icons/tabler-icons';
import { NgIconComponent, provideIcons } from '@ng-icons/core';

@Component({
  selector: 'app-message',
  standalone: true,
  imports: [CommonModule, NgIconComponent],
  templateUrl: './message.component.html',
  styleUrl: './message.component.css',
  viewProviders: [provideIcons({ tablerRobotOff, tablerRobot, tablerSnowflake })],
})
export class MessageComponent implements OnInit {
  private time: number = 2000;
  public active: boolean = false;
  public message: IMessage = {
    type: MessageTypeEnum.Error,
    message: '',
  };

  constructor(private data: DataService) {}

  ngOnInit(): void {
    this.data.message.subscribe((message) => {
      this.message = message;
      this.active = true;

      setTimeout(() => (this.active = false), this.time);
    });
  }

  get icon() {
    switch (this.message.type) {
      case MessageTypeEnum.Success:
        return 'tablerRobot';
      case MessageTypeEnum.Error:
        return 'tablerRobotOff';
      default:
        return 'tablerSnowflake';
    }
  }
}
