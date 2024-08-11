import { Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { ProjectsComponent } from './pages/projects/projects.component';
import { NewProjectComponent } from './pages/new/new-project/new-project.component';
import { ProjectComponent } from './pages/project/project.component';
import { NotFoundComponent } from './pages/not-found/not-found.component';

export const routes: Routes = [
  {
    path: '',
    component: HomeComponent,
  },
  {
    path: '404',
    component: NotFoundComponent,
  },
  {
    path: 'projects',
    component: ProjectsComponent,
  },
  {
    path: 'new/project',
    component: NewProjectComponent,
  },
  {
    path: 'project/:projectId',
    component: ProjectComponent,
  },
  {
    path: '**',
    component: NotFoundComponent,
  },
];
