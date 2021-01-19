import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { EChartOption } from 'echarts';
import { Client } from 'src/app/core/models';
import { AuthService, ChartsConfigurationService, OverviewService } from 'src/app/core/services';
@Component({
  selector: 'app-lead-time',
  templateUrl: './lead-time.component.html',
  styleUrls: ['./lead-time.component.scss']
})
export class LeadTimeComponent implements OnInit {

  clients: Client[];
  controlSquad: FormControl;
  velocity: EChartOption;
  cumulativeFlow: EChartOption;

  constructor(
    private overviewService: OverviewService,
    private authService: AuthService,
    private chartsConfiguration: ChartsConfigurationService) { }

  ngOnInit(): void {
    this.controlSquad = new FormControl();
    this.valueChanges();
    this.cumulativeFlow = this.chartsConfiguration.cumulativeFlow();

    this.clients = this.authService.clients;

    if (this.clients.length && this.clients[0].squads.length) {
      const squadId = this.clients[0].squads[0].id;
      this.controlSquad.setValue(squadId);
    }
  }

  loadData(clientId: number, squadId: number) {
    this.overviewService.getSquadVelocity(clientId, squadId).subscribe(velocity => {
      this.velocity = this.chartsConfiguration.velocity(velocity);
    });
  }

  valueChanges() {
    this.controlSquad.valueChanges.subscribe(squadId => {
      const client = this.clients.find(item => item.squads.some(squad => squad.id == this.controlSquad.value));
      this.loadData(client.id, squadId);
    });
  }
}
