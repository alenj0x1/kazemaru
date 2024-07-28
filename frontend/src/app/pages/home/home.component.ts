import { Component } from '@angular/core';
import { KazemaruComponent } from "../../components/kazemaru/kazemaru.component";

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [KazemaruComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {

}
