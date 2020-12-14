import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { EChartOption } from 'echarts';
import { Client, OverviewDemand, Provider } from 'src/app/core/models';
import { ChartsConfigurationService, ClientService, OverviewService, ProviderService } from 'src/app/core/services';

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
    private providerService: ProviderService) { }

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
    this.providerService.getProviders().subscribe(providers => {
      this.providers = providers;

      if (providers.length) {
        this.provider.setValue(providers[0].id);
      }
    });
  }

  loadClients(providerId: number) {
    this.clientService.getClientByProvider(providerId).subscribe(clients => {
      this.clients = clients;

      if (clients.length) {
        this.client.setValue(clients[0].id);
      }
    });
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


