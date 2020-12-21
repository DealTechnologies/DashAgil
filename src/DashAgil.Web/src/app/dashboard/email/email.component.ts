import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Email } from 'src/app/core/models';
import { AuthService, EmailService } from 'src/app/core/services';

@Component({
  selector: 'app-email',
  templateUrl: './email.component.html',
  styleUrls: ['./email.component.scss']
})
export class EmailComponent implements OnInit {

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  dataSource = new MatTableDataSource<Email>();
  displayedColumns = [
    'assunto',
    'conteudo',
    'remetente',
    'destinatario',
    'dataCriacao',
    'dataEnvio',
    'entregues',
    'lixo',
    'rejeitados',
    'abertos',
    'status',
  ];

  constructor(
    private emailService: EmailService
  ) { }

  ngOnInit(): void {
    this.emailService.getAll().subscribe(emails => {
      this.dataSource = new MatTableDataSource<Email>(emails.map(o => new Email(o)));
    });

    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  emailTabChange(source) {
    if (source = "Detalhes") {
      this.emailService.getAll().subscribe(emails => {
        this.dataSource = new MatTableDataSource<Email>(emails.map(o => new Email(o)));
      });
      return;
    }

    this.emailService.getCount().subscribe(count => {
      console.log(count);
    });
  }

}
