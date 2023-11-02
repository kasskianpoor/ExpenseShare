import { Component, OnInit } from '@angular/core';
import { UserCredentials } from '../_types/UserCredentials';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  userCredentials: UserCredentials = {
    email: '',
    password: '',
  };
  loggedIn = false;

  constructor(private accountService: AccountService) {}

  ngOnInit(): void {}

  login(): void {
    console.log('====================================');
    console.log(this.userCredentials.email);
    console.log(this.userCredentials.password, 'password');
    console.log('====================================');
    this.accountService.login(this.userCredentials).subscribe({
      next: (resp) => {
        console.log('====================================');
        console.log('resp', resp);
        console.log('====================================');
      },
      error: (error) => {
        console.log('====================================');
        console.log(error, 'errrrrrr');
        console.log('====================================');
      },
    });
  }
}
