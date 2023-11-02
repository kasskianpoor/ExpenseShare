import { Component, OnInit } from '@angular/core';
import { UserCredentials } from '../_types/UserCredentials';
import { AccountService } from '../_services/account.service';
import { Router } from '@angular/router';
import { paths } from '../_constants';

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

  constructor(private accountService: AccountService, private router: Router) {}

  ngOnInit(): void {}

  login(): void {
    this.accountService.login(this.userCredentials).subscribe({
      next: (resp) => {
        console.log('====================================');
        console.log('resp', resp);
        console.log('====================================');
        this.router.navigate([paths.dashboard]);
      },
      error: (error) => {
        console.log('====================================');
        console.log(error, 'errrrrrr');
        console.log('====================================');
      },
    });
  }
}
