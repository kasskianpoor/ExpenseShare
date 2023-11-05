import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AccountService } from './account.service';
import { mainBackendUrl } from '../_constants';
import {
  GroupMemberCreateInput,
  GroupMemberDeleteInput,
} from '../_types/Entities/group-member-entity';
import { groupEntity } from '../_types/Entities/group-entity';

@Injectable({
  providedIn: 'root',
})
export class GroupMembersService {
  constructor(
    private http: HttpClient,
    private accountService: AccountService
  ) {}

  createGroupMember(input: GroupMemberCreateInput) {
    return this.http.post<groupEntity>(
      `${mainBackendUrl}/api/groupmembers`,
      input,
      {
        headers: { Authorization: `Bearer ${this.accountService.token}` },
      }
    );
  }

  deleteGroupMember(input: GroupMemberDeleteInput) {
    console.log(input);
    return this.http.delete<groupEntity>(`${mainBackendUrl}/api/groupmembers`, {
      headers: {
        Authorization: `Bearer ${this.accountService.token}`,
      },
      body: {
        groupId: Number(input.groupId),
        userId: input.userId,
      },
    });
  }
}
