import { Component } from '@angular/core';
import { AccountService } from '../_services/account.service';
import { UserSignUpInfo } from '../_types/UserSignUpInfo';
import { Router } from '@angular/router';
import { paths } from '../_constants';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css'],
})
export class SignupComponent {
  userSignupInfo: UserSignUpInfo = {
    username: '',
    email: '',
    password: '',
  };
  confirmedPassword = '';

  constructor(private accountService: AccountService, private router: Router) {}

  signUp() {
    console.log(this.userSignupInfo);
    console.log(this.confirmedPassword);
    if (this.userSignupInfo.password === this.confirmedPassword) {
      this.accountService.signup(this.userSignupInfo).subscribe({
        next: () => {
          this.router.navigate([paths.dashboard]);
        },
        error: (err) => console.log(err),
      });
    }
  }
}
