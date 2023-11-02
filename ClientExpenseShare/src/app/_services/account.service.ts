import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UserCredentials } from '../_types/UserCredentials';
import { localStorageItemKeys, mainBackendUrl } from '../_constants';
import { BehaviorSubject, Observable, map } from 'rxjs';
import { UserTokenData } from '../_types/UserTokenData';
import { UserSignUpInfo } from '../_types/UserSignUpInfo';

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
            this.setCurrentUser(response);
          }
        })
      );
  }

  setCurrentUser(user: UserTokenData | null) {
    this.currentUserSource.next(user);
  }

  getCurrentUser(): Observable<UserTokenData | null> {
    return this.currentUser$;
  }

  logout() {
    // TODO: send a request to backend to logout, so the refreshToken doesn't work anymore
  }

  signup(userSignUpInfo: UserSignUpInfo) {
    return this.http
      .post<UserTokenData>(
        `${mainBackendUrl}/api/account/register`,
        userSignUpInfo
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
            this.setCurrentUser(response);
          }
        })
      );
  }
}
