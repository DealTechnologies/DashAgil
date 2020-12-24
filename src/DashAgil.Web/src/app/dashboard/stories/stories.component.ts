import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Demand } from 'src/app/core/models';
import { OverviewService } from 'src/app/core/services';

@Component({
  selector: 'app-stories',
  templateUrl: './stories.component.html',
  styleUrls: ['./stories.component.scss']
})
export class StoriesComponent implements OnInit {

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  dataSource = new MatTableDataSource<Demand>();
  displayedColumns = [
    'id',
    'workItemType',
    'description',
    'status',
  ];

  constructor(private overviewService: OverviewService) { }

  ngOnInit(): void {
    this.overviewService.getDemandList(1, 9).subscribe(demands => {
      this.dataSource = new MatTableDataSource<Demand>(demands);
      this.dataSource.paginator = this.paginator;
    });
  }
}
