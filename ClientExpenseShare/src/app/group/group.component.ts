import { Component, OnInit, TemplateRef } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { groupEntity } from '../_types/Entities/group-entity';
import { GroupsService } from '../_services/groups.service';
import { paths } from '../_constants';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { userEntity } from '../_types/Entities/user-entity';
import { expenseEntityToBeCreated } from '../_types/Entities/expense-entity';
import { GroupMembersService } from '../_services/group-members.service';

type userEmailInput = {
  userEmail: string;
};
@Component({
  selector: 'app-group',
  templateUrl: './group.component.html',
  styleUrls: ['./group.component.css'],
})
export class GroupComponent implements OnInit {
  group: groupEntity = {
    id: 0,
    name: '',
    users: [],
  };

  paidUser: userEntity | undefined;
  expenseToBeCreated: expenseEntityToBeCreated = {
    amount: undefined,
    groupId: 0,
    paidByUserId: 0,
  };

  groupMemberToBeAdded: userEmailInput = {
    userEmail: '',
  };

  constructor(
    private route: ActivatedRoute,
    private groupService: GroupsService,
    private router: Router,
    private _modalService: NgbModal,
    private groupMemberService: GroupMembersService
  ) {}

  ngOnInit(): void {
    this.route.queryParams.subscribe({
      next: (qParam: any) => {
        this.group.id = qParam.group_id;
        if (!this.group.id) this.router.navigate([paths['404']]);

        this.expenseToBeCreated.groupId = this.group.id;

        this.groupService.getGroup(qParam.group_id).subscribe({
          next: (resp) => {
            this.group.name = resp.name;
            this.group.users = resp.users;
          },
          error: (err) => {
            this.router.navigate([paths['404']]);
            console.log(err);
          },
        });
      },
      error: (err) => console.log(err),
    });
  }

  openModal(content: TemplateRef<any>) {
    this._modalService.open(content);
  }

  setPaidUser(user: userEntity) {
    this.paidUser = user;
  }

  getGroupId() {
    return this.group.id;
  }

  createExpense() {
    if (!this.paidUser) return;
    this.expenseToBeCreated.paidByUserId = this.paidUser.id;
    console.log('====================================');
    console.log(this.expenseToBeCreated);
    console.log('====================================');
    this.paidUser = undefined;
    this.expenseToBeCreated.amount = 0;
    this._modalService.dismissAll();
  }

  addGroupMember() {
    this.groupMemberService
      .createGroupMember({
        userEmail: this.groupMemberToBeAdded.userEmail,
        groupId: this.group.id,
      })
      .subscribe({
        next: (resp) => {
          this.group.users = resp.users;
          this.groupMemberToBeAdded.userEmail = '';
          this._modalService.dismissAll();
        },
        error: (err) => {
          console.log(err);
        },
      });
  }

  removeGroupMember(user_id: number) {
    this.groupMemberService
      .deleteGroupMember({
        userId: user_id,
        groupId: this.group.id,
      })
      .subscribe({
        next: (value) => {
          this.group.users = value.users;
        },
        error(err) {
          console.log(err);
        },
      });
  }
}
