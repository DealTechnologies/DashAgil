import { Component, OnInit } from '@angular/core';
import { EChartOption } from 'echarts';
import { ChartsConfigurationService } from 'src/app/core/services';

@Component({
  selector: 'app-squad',
  templateUrl: './squad.component.html',
  styleUrls: ['./squad.component.scss']
})
export class SquadComponent implements OnInit {

  optionsSquad: EChartOption;
  optionsSprint: EChartOption;

  constructor(private chartsConfiguration: ChartsConfigurationService) { }

  ngOnInit(): void {
    this.optionsSquad = this.chartsConfiguration.squad();
    this.optionsSprint = this.chartsConfiguration.sprint();
  }

}
