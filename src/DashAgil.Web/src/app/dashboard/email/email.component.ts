import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { NotifierService } from 'angular-notifier';
import { EChartOption } from 'echarts';
import { Email } from 'src/app/core/models';
import { ChartsConfigurationService, ClientService, EmailService } from 'src/app/core/services';

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

  optionsEmail: EChartOption;

  constructor(
    private clientService: ClientService,
    private emailService: EmailService,
    private notifier: NotifierService,
    private chartsConfiguration: ChartsConfigurationService
  ) { }

  ngOnInit(): void {
    this.emailService.getAll().subscribe(emails => {
      this.dataSource = new MatTableDataSource<Email>(emails.map(o => new Email(o)));
    });

    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;

    this.loadEmailsCount();
  }

  loadEmailsCount() {
    this.emailService.getCount().subscribe(count => {
      this.optionsEmail = this.chartsConfiguration.emails(count);
    });
  }

  sendEmail() {
    this.clientService.sendEmail().subscribe(() => {
      this.notifier.notify('success', 'E-mail enviado com sucesso');
      this.loadEmailsCount();
    }, () => {
      this.notifier.notify('error', 'Não foi possível enviar o e-mail');
    });
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

  defineStatusColor(item: string) {
    switch (item) {
      case 'criado':
        return 'col-criado';

      case 'enviado':
        return 'col-enviado';

      case 'entregue':
        return 'col-entregue';

      case 'rejeitado':
        return 'col-rejeitado';

      case 'lixo':
        return 'col-lixo';

      case 'aberto':
        return 'col-aberto';

      case 'clicado':
        return 'col-clicado';
    }
  }
}
