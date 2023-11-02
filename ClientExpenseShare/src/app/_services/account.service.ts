import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UserCredentials } from '../_types/UserCredentials';
import { localStorageItemKeys, mainBackendUrl } from '../_constants';
import { BehaviorSubject, map } from 'rxjs';
import { UserTokenData } from '../_types/UserTokenData';

@Injectable({
  providedIn: 'root',
})
export class AccountService {
  constructor(private http: HttpClient) {}

  private currentUserSource = new BehaviorSubject<UserTokenData | null>(null);
  currentUser$ = this.currentUserSource.asObservable();

  login(userCredentials: UserCredentials) {
    return this.http
      .post<UserTokenData>(
        `${mainBackendUrl}/api/account/login`,
        userCredentials
      )
      .pipe(
        map((response: UserTokenData) => {
          if (response) {
            localStorage.setItem(
              localStorageItemKeys.username,
              response.username
            );
            localStorage.setItem(localStorageItemKeys.token, response.token);
            localStorage.setItem(
              localStorageItemKeys.refreshToken,
              response.token
            );
            // TODO: also set a refreshToken
            this.currentUserSource.next(response);
          }
        })
      );
  }

  setCurrentUser(user: UserTokenData) {
    this.currentUserSource.next(user);
  }

  logout() {
    // TODO: send a request to backend to logout, so the refreshToken doesn't work anymore
    localStorage.removeItem(localStorageItemKeys.username);
    localStorage.removeItem(localStorageItemKeys.token);
    localStorage.removeItem(localStorageItemKeys.refreshToken);
    this.currentUserSource.next(null);
  }
}
