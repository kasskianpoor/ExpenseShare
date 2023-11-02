import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { LoginComponent } from './login/login.component';
import { SignupComponent } from './signup/signup.component';
import { paths } from './_constants';
import { LogoutComponent } from './logout/logout.component';

const routes: Routes = [
  { path: paths.dashboard, component: DashboardComponent, pathMatch: 'full' },
  { path: paths.login, component: LoginComponent, pathMatch: 'full' },
  { path: paths.logout, component: LogoutComponent, pathMatch: 'full' },
  { path: paths.signup, component: SignupComponent, pathMatch: 'full' },
  { path: paths[404], component: DashboardComponent, pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
