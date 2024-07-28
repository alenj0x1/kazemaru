import { Component, OnInit } from '@angular/core';
import { CardButtonComponent } from "../../components/card-button/card-button.component";
import { HttpService } from '../../services/http.service';
import { DataService } from '../../services/data.service';
import IProject from '../../interfaces/IProject';
import { ProjectThumbComponent } from '../../components/project-thumb/project-thumb.component';

@Component({
  selector: 'app-projects',
  standalone: true,
  imports: [CardButtonComponent, ProjectThumbComponent],
  templateUrl: './projects.component.html',
  styleUrl: './projects.component.css'
})
export class ProjectsComponent implements OnInit {
  public projects: IProject[] = [];
  
  constructor(private http: HttpService, private data: DataService) {}

  ngOnInit(): void {
    this.data.projects$.subscribe(data => this.projects = data)
  }
}
