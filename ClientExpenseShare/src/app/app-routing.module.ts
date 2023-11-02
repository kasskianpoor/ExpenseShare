import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { LoginComponent } from './login/login.component';
import { SignupComponent } from './signup/signup.component';

export const paths = {
  dashboard: 'dashboard',
  login: 'login',
  signup: 'signup',
  404: '**',
};

const routes: Routes = [
  { path: paths.dashboard, component: DashboardComponent, pathMatch: 'full' },
  { path: paths.login, component: LoginComponent, pathMatch: 'full' },
  { path: paths.signup, component: SignupComponent, pathMatch: 'full' },
  { path: paths[404], component: DashboardComponent, pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
