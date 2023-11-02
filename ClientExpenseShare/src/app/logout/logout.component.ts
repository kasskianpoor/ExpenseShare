import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { paths } from '../_constants';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-logout',
  templateUrl: './logout.component.html',
  styleUrls: ['./logout.component.css'],
})
export class LogoutComponent implements OnInit {
  constructor(private router: Router, public accountService: AccountService) {}

  ngOnInit(): void {
    this.accountService.logout();
    this.router.navigate([paths.login]);
  }
}
