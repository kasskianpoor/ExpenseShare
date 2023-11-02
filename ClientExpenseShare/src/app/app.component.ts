import { Component, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { AccountService } from './_services/account.service';
import { localStorageItemKeys } from './_constants';

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
    const username = localStorage.getItem(localStorageItemKeys.username);
    const token = localStorage.getItem(localStorageItemKeys.token);
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
