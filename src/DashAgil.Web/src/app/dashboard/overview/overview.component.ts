import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { EChartOption } from 'echarts';
import { Client, OverviewDemand, Provider } from 'src/app/core/models';
import { AuthService, ChartsConfigurationService, ClientService, OverviewService, ProviderService } from 'src/app/core/services';

@Component({
  selector: 'app-overview',
  templateUrl: './overview.component.html',
  styleUrls: ['./overview.component.scss']
})
export class OverviewComponent implements OnInit {

  optionsDemandsVsSquad: EChartOption;
  optionsInExecution: EChartOption;
  overview: OverviewDemand;
  provider: FormControl;
  client: FormControl;
  providers: Provider[];
  clients: Client[];

  optionsRadar: EChartOption;

  constructor(
    private overviewService: OverviewService,
    private chartsConfiguration: ChartsConfigurationService,
    private clientService: ClientService,
    private providerService: ProviderService,
    private authService: AuthService) { }

  ngOnInit() {
    this.overview = new OverviewDemand();
    this.provider = new FormControl();
    this.client = new FormControl();

    this.provider.valueChanges.subscribe(providerId => {
      this.loadClients(providerId);
    });

    this.client.valueChanges.subscribe(clientId => {
      this.loadDemands(clientId);
    });

    this.loadProviders();

    this.optionsRadar = this.chartsConfiguration.radar();
  }

  loadProviders() {
    this.providers = this.authService.currentUserValue.provedores;

    if (this.providers.length) {
      const provider = this.providers[0];
      this.provider.setValue(provider.id);

      this.clients = this.clients = provider.clientes;
    }
  }

  loadClients(providerId: number) {
    const provider = this.providers.find(item => item.id == providerId);
    this.clients = provider.clientes;

    if (this.clients.length) {
      this.client.setValue(this.clients[0].id);
    }
  }

  loadDemands(clientId: number) {
    this.overviewService.getOverviewDemands(clientId).subscribe(overview => {
      this.overview = overview;
      this.optionsDemandsVsSquad = this.chartsConfiguration.demandsVsSquad(overview);
      this.optionsInExecution = this.chartsConfiguration.inExecution(overview);
    });
  }

  getIcon(providerId: number) {
    switch (providerId) {
      case 1:
        return 'devops';
        break;
      case 2:
        return 'jira';
        break;
      case 3:
        return 'trello';
        break;
    }
  }

  onChartEvent(event: any, type: string) {
    alert(event.name);
  }

  public chartClicked({ event, active }: { event: MouseEvent, active: {}[] }): void {
    console.log(event, active);
  }

  public chartHovered({ event, active }: { event: MouseEvent, active: {}[] }): void {
    console.log(event, active);
  }
}

