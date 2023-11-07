import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AccountService } from './account.service';
import { mainBackendUrl } from '../_constants';
import { SplitResponseJSON } from '../_types/SplitResponse';

@Injectable({
  providedIn: 'root',
})
export class SplitService {
  constructor(
    private http: HttpClient,
    private accountService: AccountService
  ) {}

  split(input: { groupId: number }) {
    return this.http.post<SplitResponseJSON>(
      `${mainBackendUrl}/api/split`,
      input,
      {
        headers: { Authorization: `Bearer ${this.accountService.token}` },
      }
    );
  }
}
