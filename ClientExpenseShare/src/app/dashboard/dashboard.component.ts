import { Component, OnInit } from '@angular/core';

import {
  ModalDismissReasons,
  NgbDatepickerModule,
  NgbModal,
} from '@ng-bootstrap/ng-bootstrap';
import { paths } from '../_constants';
import { Router } from '@angular/router';
import { GroupsService } from '../_services/groups.service';
import { groupEntity } from '../_types/Entities/group-entity';
import { IPaginatedData } from '../_interfaces/paginated-data';

type CreateGroupResp = {
  id: number;
  name: string;
  users: any;
};

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css'],
})
export class DashboardComponent implements OnInit {
  newGroup = {
    groupName: '',
  };
  groups: groupEntity[] = [];

  constructor(
    private modalService: NgbModal,
    private router: Router,
    private groupService: GroupsService
  ) {}

  ngOnInit(): void {
    this.groupService.getGroups().subscribe({
      next: (resp: IPaginatedData<groupEntity[]>) => {
        this.groups = resp.data;
      },
      error: (error) => {
        console.log('====================================');
        console.log(error);
        console.log('====================================');
      },
    });
  }

  openModal(content: any) {
    this.modalService.open(content);
  }

  createGroup() {
    console.log(this.newGroup);
    this.groupService.createGroup(this.newGroup).subscribe({
      next: (resp: CreateGroupResp) => {
        this.router.navigate([paths.group], {
          queryParams: { group_id: resp.id, group_name: resp.name },
        });
        this.modalService.dismissAll();
      },
      error: (error) => {
        console.log('====================================');
        console.log(error);
        console.log('====================================');
      },
    });
  }
}
