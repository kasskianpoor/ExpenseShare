import { Component, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { AccountService } from './_services/account.service';
import { UserTokenData } from './_types/UserTokenData';
import { Observable, of } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  title = 'ExpenseShare';

  constructor(public accountService: AccountService) {}
  ngOnInit(): void {
    this.setCurrentUser();
  }

  setCurrentUser() {
    const username = localStorage.getItem('username');
    const token = localStorage.getItem('token');
    if (username && token) {
      const user = {
        username,
        token,
      };
      this.accountService.setCurrentUser(user);
    }
    return;
  }
}
