import { Component } from '@angular/core';
import { DataService } from '../../services/data.service';
import { AnimationProperty, IAnimationsState } from '../../interfaces/app/animations-state.interface';
import { DEFAULT_STATE_ANIMATIONS } from '../../lib/consts.lib';

@Component({
  selector: 'app-configuration',
  standalone: true,
  imports: [],
  templateUrl: './configuration.component.html',
  styleUrl: './configuration.component.css',
})
export class ConfigurationComponent {
  public animations: IAnimationsState = DEFAULT_STATE_ANIMATIONS

  constructor(private readonly data: DataService) {
    this.data.animations$.subscribe(data => this.animations = data);
  }

  get animationsProperties(): AnimationProperty[] {
    return Object.keys(this.animations) as AnimationProperty[];
  }
 
  public getAnimationsProperty(key: AnimationProperty) {
    return this.animations[key];
  }

  public onToggleAnimationProperty(key: AnimationProperty) {
    this.animations[key].state = !this.animations[key].state
    this.data.updateAnimations(this.animations);
  }
}
