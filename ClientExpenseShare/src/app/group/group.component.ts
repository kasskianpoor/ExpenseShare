import {
  Component,
  Input,
  OnChanges,
  OnInit,
  SimpleChanges,
  TemplateRef,
} from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { groupEntity } from '../_types/Entities/group-entity';
import { GroupsService } from '../_services/groups.service';
import { paths } from '../_constants';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { userEntity } from '../_types/Entities/user-entity';
import {
  expenseEntity,
  expenseEntityToBeCreated,
} from '../_types/Entities/expense-entity';
import { GroupMembersService } from '../_services/group-members.service';
import { ExpensesService } from '../_services/expenses.service';
import { SplitService } from '../_services/split.service';
import { SplitResponseJSON } from '../_types/SplitResponse';

type userEmailInput = {
  userEmail: string;
};

// type expenseEditInput = {

// }
@Component({
  selector: 'app-group',
  templateUrl: './group.component.html',
  styleUrls: ['./group.component.css'],
})
export class GroupComponent implements OnInit {
  expenses: expenseEntity[] = [];
  splitResultTexts: string[] = [];
  group: groupEntity = {
    id: 0,
    name: '',
    users: [],
  };

  paidUser: userEntity | undefined;
  expenseToBeCreated: expenseEntityToBeCreated = {
    amount: undefined,
    groupId: 0,
    userId: 0,
  };

  expenseToBeEdited: expenseEntity | undefined;

  groupMemberToBeAdded: userEmailInput = {
    userEmail: '',
  };

  total: number = 0;
  updateTotal() {
    this.total = 0;
    for (const expense of this.expenses) {
      this.total += expense.amount;
    }
  }

  constructor(
    private route: ActivatedRoute,
    private groupService: GroupsService,
    private router: Router,
    private _modalService: NgbModal,
    private groupMemberService: GroupMembersService,
    private expenseService: ExpensesService,
    private splitService: SplitService
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

        this.expenseService.getExpenses({ id: this.group.id }).subscribe({
          next: (resp) => {
            this.expenses = resp.data;
            this.updateTotal();
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

  openExpenseEditModal(
    content: TemplateRef<any>,
    expenseToEdit: expenseEntity
  ) {
    this.expenseToBeEdited = { ...expenseToEdit };
    this._modalService.open(content);
  }

  editExpense() {
    if (!this.expenseToBeEdited) return;
    this.expenseService.editExpense(this.expenseToBeEdited).subscribe({
      next: (resp) => {
        for (const expense of this.expenses) {
          if (expense.id === resp.id) expense.amount = resp.amount;
        }
        this.updateTotal();
        this._modalService.dismissAll();
      },
      error: (err) => {
        console.log(err);
      },
    });
  }

  setPaidUser(user: userEntity) {
    this.paidUser = user;
  }

  createExpense() {
    if (!this.paidUser) return;
    this.expenseToBeCreated.userId = this.paidUser.id;
    console.log(this.expenseToBeCreated);

    this.expenseService.createExpense(this.expenseToBeCreated).subscribe({
      next: (resp) => {
        this.expenses.push(resp);
        this.updateTotal();
      },
      error: (err) => {
        console.log(err);
      },
    });
    this.paidUser = undefined;
    this.expenseToBeCreated.amount = 0;
    this._modalService.dismissAll();
  }

  deleteExpense(expense_id: number) {
    this.expenseService.deleteExpense({ id: expense_id }).subscribe({
      next: (resp) => {
        this.expenses = this.expenses.filter((expense) => {
          console.log(expense, 'expense');
          console.log(resp, 'resp');
          return expense.id !== resp.id;
        });
        this.updateTotal();
      },
      error: (err) => {
        console.log(err);
      },
    });
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

  split() {
    console.log(this.group.id);
    this.splitService.split({ groupId: this.group.id }).subscribe({
      next: (resp) => {
        if (!this.group.users) return;
        if (resp) {
          for (const res of resp) {
            const currUser = this.group.users.find(
              (user) => user.id == res.userId
            );
            if (res.shouldPay > 0) {
              this.splitResultTexts.push(
                `${currUser?.userName || currUser?.email} should pay $${
                  res.shouldPay
                }`
              );
            } else if (res.shouldPay == 0) {
              this.splitResultTexts.push(
                `${currUser?.userName || currUser?.email} shouldn't do anything`
              );
            } else {
              this.splitResultTexts.push(
                `${
                  currUser?.userName || currUser?.email
                } shouldn receive $${Math.abs(res.shouldPay)}`
              );
            }
          }
        } else {
          console.log('something went terribly wrong');
        }
      },
      error: (err) => {
        console.log(err);
      },
    });
  }
}
