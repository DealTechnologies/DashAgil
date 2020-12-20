import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { EChartOption } from 'echarts';
import { Client, OverviewFeature } from 'src/app/core/models';
import { AuthService, ChartsConfigurationService, OverviewService } from 'src/app/core/services';

@Component({
  selector: 'app-squad',
  templateUrl: './squad.component.html',
  styleUrls: ['./squad.component.scss']
})
export class SquadComponent implements OnInit {

  squadName: string;
  overviewFeature: OverviewFeature;
  percentFeatures: { isProd: boolean, value: number };

  squad: FormControl;

  optionsSquad: EChartOption;
  optionsSprint: EChartOption;

  clients: Client[];

  constructor(
    private overviewService: OverviewService,
    private authService: AuthService,
    private route: ActivatedRoute,
    private chartsConfiguration: ChartsConfigurationService) {
  }

  ngOnInit(): void {
    this.percentFeatures = { isProd: false, value: 0 };

    this.route.queryParams.subscribe(params => {
      this.squadName = params.squadName;
    });

    if (!this.squadName)
      this.squadName = 'Projetos';

    this.clients = this.authService.currentUserValue.provedores.map(item => item.clientes).reduce((x, y) => x.concat(y), []);

    const squad = this.clients.map(client => client.squads).reduce((x, y) => x.concat(y), []).find(squad => squad.nome == this.squadName);
    this.squad = new FormControl(squad.id);

    this.squadName = squad.nome;

    const client = this.clients.find(item => item.squads.some(squadItem => squadItem.id == squad.id));

    this.loadData(client.id, squad.id, 50);
    this.clients = this.authService.currentUserValue.provedores.map(item => item.clientes).reduce((x, y) => x.concat(y), []);

    this.valueChanges();
  }

  valueChanges() {
    this.squad.valueChanges.subscribe(id => {
      const client = this.clients.find(item => item.squads.some(squad => squad.id == id));
      const squad = client.squads.find(item => item.id == id);
      this.squadName = squad.nome;
      this.loadData(client.id, squad.id, 50);
    });
  }

  loadData(clientId: number, squadId: number, sprintId?: number) {
    this.overviewService.getOverviewFeatures(clientId, squadId, 50).subscribe(overviewFeature => {
      this.overviewFeature = overviewFeature;
      this.definePercent(overviewFeature);
      this.optionsSquad = this.chartsConfiguration.squad(overviewFeature);
      this.optionsSprint = this.chartsConfiguration.sprint(overviewFeature);
    });
  }

  definePercent(overviewFeature: OverviewFeature) {
    this.percentFeatures = overviewFeature.ListaPercentual.PercentualFeaturesConclusao > 0
      ? { isProd: true, value: overviewFeature.ListaPercentual.PercentualFeaturesConclusao }
      : { isProd: false, value: overviewFeature.ListaPercentual.PercentualFeaturesHomologacao || 0 }
  }

}
