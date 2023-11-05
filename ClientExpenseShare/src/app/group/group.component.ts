import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { groupEntity } from '../_types/Entities/group-entity';
import { GroupsService } from '../_services/groups.service';

type queryParamType = {
  group_id: number;
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
  };

  constructor(
    private route: ActivatedRoute,
    private groupService: GroupsService
  ) {}

  ngOnInit(): void {
    this.route.queryParams.subscribe({
      next: (qParam: any) => {
        console.log('EVEN HERE');
        this.group.id = qParam.group_id;

        this.groupService.getGroup(qParam.group_id).subscribe({
          next: (resp) => {
            console.log(resp, 'this is resp');
            this.group.name = resp.name;
          },
          error: (err) => console.log(err),
        });
      },
      error: (err) => console.log(err),
    });
  }
}
