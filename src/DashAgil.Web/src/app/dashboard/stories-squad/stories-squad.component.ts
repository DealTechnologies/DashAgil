import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Client, SquadStory } from 'src/app/core/models';
import { AuthService, OverviewService } from 'src/app/core/services';

@Component({
  selector: 'app-stories-squad',
  templateUrl: './stories-squad.component.html',
  styleUrls: ['./stories-squad.component.scss']
})
export class StoriesSquadComponent implements OnInit {

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;

  dataSource: MatTableDataSource<SquadStory>;
  displayedColumns: string[];
  total: SquadStory;
  clients: Client[];
  controlClient: FormControl;

  constructor(
    private overviewService: OverviewService,
    private authService: AuthService,
  ) { }

  ngOnInit(): void {
    this.dataSource = new MatTableDataSource<SquadStory>();

    this.displayedColumns = [
      'squad',
      'emBacklog',
      'emDesenvolvimento',
      'desenvolvimentoConcluido',
      'emHomologacao',
      'homologado',
      'concluido',
      'totalGeral',
    ];

    this.controlClient = new FormControl();
    this.valueChanges();

    this.clients = this.authService.clients;

    if (this.clients.length) {
      this.controlClient.setValue(this.clients[0].id);
    }
  }

  loadData(clientId: number) {
    this.overviewService.getSquadStories(clientId, this.authService.userId).subscribe(stories => {
      this.total = stories.pop();
      this.dataSource = new MatTableDataSource<SquadStory>(stories);
      this.dataSource.paginator = this.paginator;
    });
  }

  valueChanges() {
    this.controlClient.valueChanges.subscribe(clientId => {
      this.loadData(clientId);
    });
  }
}
