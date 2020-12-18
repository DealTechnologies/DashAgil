import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Demand } from 'src/app/core/models';
import { OverviewService } from 'src/app/core/services';

@Component({
  selector: 'app-stories-squad',
  templateUrl: './stories-squad.component.html',
  styleUrls: ['./stories-squad.component.scss']
})
export class StoriesSquadComponent implements OnInit {

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  dataSource = new MatTableDataSource<Demand>();
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

  constructor(private overviewService: OverviewService) { }

  ngOnInit(): void {
    const data = [
      {
        squad: 'Terror By Night',
        emBacklog: 8,
        emDesenvolvimento: 9,
        desenvolvimentoConcluido: 80,
        emHomologacao: 0,
        homologado: 0,
        concluido: 582,
        totalGeral: 679,
      },
      {
        squad: 'Squad 3',
        emBacklog: 5,
        emDesenvolvimento: 2,
        desenvolvimentoConcluido: 0,
        emHomologacao: 0,
        homologado: 0,
        concluido: 16,
        totalGeral: 23,
      }
    ];

    this.dataSource = new MatTableDataSource<any>(data);
    this.dataSource.paginator = this.paginator;
  }
}
