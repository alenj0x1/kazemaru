import { Component, OnInit } from '@angular/core';
import { NgIconComponent, provideIcons } from '@ng-icons/core';
import { tablerDeviceGamepad } from '@ng-icons/tabler-icons';
import IAppInfo from '../../../interfaces/IAppInfo';
import { DataService } from '../../../services/data.service';
import { HttpService } from '../../../services/http.service';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import IProject from '../../../interfaces/IProject';
import { Router } from '@angular/router';
import { MessageTypeEnum } from '../../../interfaces/IMessage';

@Component({
  selector: 'app-new-project',
  standalone: true,
  imports: [NgIconComponent, ReactiveFormsModule],
  templateUrl: './new-project.component.html',
  styleUrl: './new-project.component.css',
  viewProviders: [provideIcons({ tablerDeviceGamepad })],
})
export class NewProjectComponent implements OnInit {
  public appInfo: IAppInfo = {
    tags: [],
    projectStatuses: [],
    taskStatuses: [],
  };
  public projects: IProject[] = [];
  public form: FormGroup;

  constructor(
    private http: HttpService,
    private data: DataService,
    private formBuilder: FormBuilder,
    private router: Router
  ) {
    this.form = this.formBuilder.group({
      name: ['', Validators.required],
      description: [''],
      banner: [''],
      status: [-1, Validators.required],
    });
  }

  ngOnInit(): void {
    this.data.appInfo$.subscribe((data) => (this.appInfo = data));
    this.data.projects$.subscribe((data) => (this.projects = data));
  }

  create() {
    this.form.value.status = +this.form.value.status;

    this.data.loading.emit(true);

    this.http.createProject(this.form.value).subscribe({
      next: ({ data, message }) => {
        this.data.loading.emit(false);
        this.data.message.emit({ message, type: MessageTypeEnum.Success });

        this.projects.push(data);
        this.data.updateProjects(this.projects);

        this.router.navigate(['/projects'], { fragment: data.projectid });
      },
      error: ({ error }) => {
        console.log(error);
        this.data.loading.emit(false);
        this.data.message.emit({ message: error.message, type: MessageTypeEnum.Error });
      },
    });
  }
}
