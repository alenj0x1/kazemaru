import { Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { ProjectsComponent } from './pages/projects/projects.component';
import { NewProjectComponent } from './pages/new/new-project/new-project.component';
import { ProjectComponent } from './pages/project/project.component';
import { NotFoundComponent } from './pages/not-found/not-found.component';
import { LoginComponent } from './pages/login/login.component';
import { authGuard } from './guards/auth.guard';
import { ConfigurationComponent } from './pages/configuration/configuration.component';

export const routes: Routes = [
  {
    path: '',
    component: HomeComponent,
  },
  {
    path: 'login',
    canActivate: [authGuard],
    component: LoginComponent,
  },
  {
    path: 'home',
    canActivate: [authGuard],
    component: HomeComponent,
  },
  {
    path: '404',
    component: NotFoundComponent,
  },
  {
    path: 'projects',
    canActivate: [authGuard],
    component: ProjectsComponent,
  },
  {
    path: 'new/project',
    canActivate: [authGuard],
    component: NewProjectComponent,
  },
  {
    path: 'project/:projectId',
    canActivate: [authGuard],
    component: ProjectComponent,
  },
    {
    path: 'configuration',
    canActivate: [authGuard],
    component: ConfigurationComponent,
  },
  {
    path: '**',
    component: NotFoundComponent,
  },
];
