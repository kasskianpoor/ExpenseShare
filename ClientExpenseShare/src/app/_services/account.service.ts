import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UserCredentials } from '../_types/UserCredentials';
import { mainBackendUrl } from '../_constants';

@Injectable({
  providedIn: 'root',
})
export class AccountService {
  constructor(private http: HttpClient) {}

  login(userCredentials: UserCredentials) {
    console.log('heellloo');

    return this.http.post(
      `${mainBackendUrl}/api/account/login`,
      userCredentials
    );
  }
}
