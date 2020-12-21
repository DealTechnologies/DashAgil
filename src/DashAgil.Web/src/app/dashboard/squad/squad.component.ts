import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { EChartOption } from 'echarts';
import { Client, OverviewFeature, Sprint } from 'src/app/core/models';
import { AuthService, ChartsConfigurationService, OverviewService, SprintService } from 'src/app/core/services';

@Component({
  selector: 'app-squad',
  templateUrl: './squad.component.html',
  styleUrls: ['./squad.component.scss']
})
export class SquadComponent implements OnInit {

  squadName: string;
  overviewFeature: OverviewFeature;
  percentFeatures: { isProd: boolean, value: number };

  controlSquad: FormControl;
  controlSprint: FormControl;

  optionsSquad: EChartOption;
  optionsSprint: EChartOption;

  clients: Client[];
  sprints: Sprint[];

  constructor(
    private overviewService: OverviewService,
    private sprintService: SprintService,
    private authService: AuthService,
    private route: ActivatedRoute,
    private chartsConfiguration: ChartsConfigurationService) {
  }

  get currentClient() {
    return this.clients.find(item => item.squads.some(squad => squad.id == this.controlSquad.value));
  }

  get currentSquad() {
    return this.currentClient.squads.find(item => item.id == this.controlSquad.value);
  }

  get currentSprint() {
    return this.sprints.find(item => item.id == this.controlSprint.value);
  }

  ngOnInit(): void {
    this.controlSprint = new FormControl();
    this.controlSquad = new FormControl();
    this.valueChanges();

    this.percentFeatures = { isProd: false, value: 0 };

    this.route.queryParams.subscribe(params => {
      this.squadName = params.squadName;
    });

    if (!this.squadName) {
      this.squadName = this.authService.currentUserValue.provedores[0].clientes[0].squads[0].nome;
    }

    this.clients = this.authService.currentUserValue.provedores.map(item => item.clientes).reduce((x, y) => x.concat(y), []);

    const squad = this.clients.map(client => client.squads).reduce((x, y) => x.concat(y), []).find(squad => squad.nome == this.squadName);

    this.squadName = squad.nome;

    this.controlSquad.setValue(squad.id);

    this.clients = this.authService.currentUserValue.provedores.map(item => item.clientes).reduce((x, y) => x.concat(y), []);

  }

  valueChanges() {
    this.controlSquad.valueChanges.subscribe(async squadId => {
      await this.loadSprints(squadId);

      this.squadName = this.currentSquad.nome;

      if (this.sprints.length) {
        this.controlSprint.setValue(this.sprints[0].id);
      }
    });

    this.controlSprint.valueChanges.subscribe(sprintId => {
      this.loadData(this.currentClient.id, this.currentSquad.id, sprintId);
    });
  }

  async loadSprints(squadId: number) {
    await this.sprintService.getSprintsBySquad(squadId).toPromise().then(sprints => {
      this.sprints = sprints;
    });
  }

  loadData(clientId: number, squadId: number, sprintId: number) {
    this.overviewService.getOverviewFeatures(clientId, squadId, sprintId).subscribe(overviewFeature => {
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
