import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  title = 'ExpenseShare';
  isLoginSelected = true;
  cardTitle = this.isLoginSelected ? 'Login' : 'Sign up';
}
