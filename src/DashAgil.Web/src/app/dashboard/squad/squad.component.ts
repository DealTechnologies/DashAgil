import { Component, OnInit } from '@angular/core';
import { EChartOption } from 'echarts';
import { OverviewFeature } from 'src/app/core/models';
import { ChartsConfigurationService, OverviewService } from 'src/app/core/services';

@Component({
  selector: 'app-squad',
  templateUrl: './squad.component.html',
  styleUrls: ['./squad.component.scss']
})
export class SquadComponent implements OnInit {

  squadName: string;
  overviewFeature: OverviewFeature;

  optionsSquad: EChartOption;
  optionsSprint: EChartOption;

  constructor(private overviewService: OverviewService, private chartsConfiguration: ChartsConfigurationService) { }

  ngOnInit(): void {
    this.squadName = 'Terror By Night';
    this.loadData();
  }

  loadData() {
    this.overviewService.getOverviewFeatures(1, 1, 1).subscribe(response => {
      this.overviewFeature = response;
      this.optionsSquad = this.chartsConfiguration.squad(response);
      this.optionsSprint = this.chartsConfiguration.sprint(response);
    });
  }

}