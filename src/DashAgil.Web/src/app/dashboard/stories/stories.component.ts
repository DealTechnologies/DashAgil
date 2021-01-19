import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Client, Demand } from 'src/app/core/models';
import { AuthService, OverviewService } from 'src/app/core/services';

@Component({
  selector: 'app-stories',
  templateUrl: './stories.component.html',
  styleUrls: ['./stories.component.scss']
})
export class StoriesComponent implements OnInit {

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;

  clients: Client[];
  controlSquad: FormControl;
  dataSource: MatTableDataSource<Demand>;
  displayedColumns: string[];

  constructor(
    private overviewService: OverviewService,
    private authService: AuthService,
  ) { }

  ngOnInit(): void {
    this.dataSource = new MatTableDataSource<Demand>();

    this.displayedColumns = [
      'id',
      'workItemType',
      'description',
      'status',
    ];

    this.controlSquad = new FormControl();
    this.valueChanges();

    this.clients = this.authService.clients;

    if (this.clients.length && this.clients[0].squads.length) {
      const squadId = this.clients[0].squads[0].id;
      this.controlSquad.setValue(squadId);
    }
  }

  loadData(clientId: number, squadId: number) {
    this.overviewService.getDemandList(clientId, squadId, this.authService.userId).subscribe(demands => {
      this.dataSource = new MatTableDataSource<Demand>(demands);
      this.dataSource.paginator = this.paginator;
    });
  }

  valueChanges() {
    this.controlSquad.valueChanges.subscribe(squadId => {
      const client = this.clients.find(item => item.squads.some(squad => squad.id == this.controlSquad.value));
      this.loadData(client.id, squadId);
    });
  }

  defineStatusColor(item: string) {
    switch (item) {
      case 'Remanescente':
        return 'col-remanescente';

      case 'Em Desenvolvimento':
        return 'col-desenvolvimento';

      case 'Desenvolvimento Concluído':
        return 'col-desenvolvimento-concluido';

      case 'Em Homologação':
        return 'col-homologacao';

      case 'Homologado':
        return 'col-homologado';

      case 'Concluído':
        return 'col-concluido';
    }
  }
}
