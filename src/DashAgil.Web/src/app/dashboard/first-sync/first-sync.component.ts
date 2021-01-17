import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, FormBuilder } from '@angular/forms';
import { NgxSpinnerService } from 'ngx-spinner';
import { Client, Provider} from 'src/app/core/models';
import { ClientService, ProviderService, AuthService } from 'src/app/core/services';
import { IntegracaoService } from 'src/app/core/services/api/integracao.service';

@Component({
  selector: 'app-first-sync',
  templateUrl: './first-sync.component.html',
  styleUrls: ['./first-sync.component.scss']
})
export class FirstSyncComponent implements OnInit {
  clients: Client[];
  providers: Provider[];
  provider: FormControl;
  token: FormControl;
  client: FormControl;

  constructor(
    private clientService: ClientService,
    private providerService: ProviderService,
    private integracao: IntegracaoService,
    private spinner: NgxSpinnerService,
    private authService: AuthService) {
  }

  ngOnInit() {
    this.client = new FormControl();
    this.provider = new FormControl();
    this.token = new FormControl();

    this.client.valueChanges.subscribe(clientId => { });


    this.provider.valueChanges.subscribe(providerId => {
      this.loadClients(providerId);
    });

    this.loadProviders();

  }

  loadProviders() {
    this.providers = this.authService.currentUserValue.provedores;

    if (this.providers.length) {
      const provider = this.providers[0];
      this.provider.setValue(provider.id);
    }
  }

  sendSync(){

    if(this.client.value == 1){
      this.integracao.syncInicialDevops(
         this.client.value,
         this.providers.find(f => f.id == this.provider.value).descricao,
         this.token.value
      ).subscribe(result => {
        this.spinner.hide();
        alert(result.Message)
      },
      err => {this.spinner.hide(); alert('Ocorreu um erro ao efetuar sync com devops')} )
      return;
    }

    this.integracao.syncInicialJira(
      this.client.value,
      this.provider.value,
      this.token.value
    ).subscribe(result => {
      this.spinner.hide();
      alert(result.Message)
    },
    err => {this.spinner.hide(); alert('Ocorreu um erro ao efetuar sync com hira')} )

  }

  loadClients(providerId: number) {
    const provider = this.providers.find(item => item.id == providerId);
    this.clients = provider.clientes;

    if (this.clients.length) {
      this.client.setValue(this.clients[0].id);
    }
  }

  getIcon(providerId: number) {
    switch (providerId) {
      case 1:
        return 'devops';
      case 2:
        return 'jira';
      case 3:
        return 'trello';
    }
  }
}
