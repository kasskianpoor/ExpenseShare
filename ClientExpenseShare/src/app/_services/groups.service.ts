import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { mainBackendUrl } from '../_constants';
import { AccountService } from './account.service';
import { groupEntity } from '../_types/Entities/group-entity';
import { IPaginatedData } from '../_interfaces/paginated-data';

type CreateGroupInput = {
  groupName: string;
};

@Injectable({
  providedIn: 'root',
})
export class GroupsService {
  constructor(
    private http: HttpClient,
    private accountService: AccountService
  ) {}

  createGroup(input: CreateGroupInput) {
    return this.http.post<any>(`${mainBackendUrl}/api/groups`, input, {
      headers: { Authorization: `Bearer ${this.accountService.token}` },
    });
  }

  getGroups() {
    return this.http.get<IPaginatedData<groupEntity[]>>(
      `${mainBackendUrl}/api/groups`,
      {
        headers: {
          Authorization: `Bearer ${this.accountService.token}`,
        },
      }
    );
  }

  getGroup(group_id: number) {
    return this.http.get<groupEntity>(
      `${mainBackendUrl}/api/groups/${group_id}/members`,
      {
        headers: {
          Authorization: `Bearer ${this.accountService.token}`,
        },
      }
    );
  }
}
