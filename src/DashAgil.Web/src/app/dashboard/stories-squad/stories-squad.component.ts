import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { SquadStory } from 'src/app/core/models';
import { AuthService, OverviewService } from 'src/app/core/services';

@Component({
  selector: 'app-stories-squad',
  templateUrl: './stories-squad.component.html',
  styleUrls: ['./stories-squad.component.scss']
})
export class StoriesSquadComponent implements OnInit {

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;

  dataSource = new MatTableDataSource<SquadStory>();

  displayedColumns = [
    'squad',
    'emBacklog',
    'emDesenvolvimento',
    'desenvolvimentoConcluido',
    'emHomologacao',
    'homologado',
    'concluido',
    'totalGeral',
  ];

  total: SquadStory;

  constructor(
    private overviewService: OverviewService,
    private authService: AuthService,
  ) { }

  ngOnInit(): void {
    this.overviewService.getSquadStories(1, this.authService.userId).subscribe(stories => {
      this.total= stories.pop();
      this.dataSource = new MatTableDataSource<any>(stories);
      this.dataSource.paginator = this.paginator;
    });
  }
}
