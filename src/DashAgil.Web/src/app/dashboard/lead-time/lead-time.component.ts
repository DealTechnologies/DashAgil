import { SelectionModel } from '@angular/cdk/collections';
import { Component, OnInit } from '@angular/core';
import { EChartOption } from 'echarts';
import { ChartsConfigurationService } from 'src/app/core/services';

@Component({
  selector: 'app-lead-time',
  templateUrl: './lead-time.component.html',
  styleUrls: ['./lead-time.component.scss']
})
export class LeadTimeComponent implements OnInit {

  velocity: EChartOption;
  cumulativeFlow: EChartOption;

  constructor(private chartsConfiguration: ChartsConfigurationService) { }

  ngOnInit(): void {
    this.velocity = this.chartsConfiguration.velocity();
    this.cumulativeFlow = this.chartsConfiguration.cumulativeFlow();
  }
}
