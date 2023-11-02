import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { paths } from '../_constants';

@Component({
  selector: 'app-logout',
  templateUrl: './logout.component.html',
  styleUrls: ['./logout.component.css'],
})
export class LogoutComponent implements OnInit {
  constructor(private router: Router) {}

  ngOnInit(): void {
    this.router.navigate([paths.login]);
  }
}
