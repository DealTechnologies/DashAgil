import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { EChartOption } from 'echarts';
import { ChartsConfigurationService, OverviewService } from 'src/app/core/services';

@Component({
  selector: 'app-overview',
  templateUrl: './overview.component.html',
  styleUrls: ['./overview.component.scss']
})
export class OverviewComponent implements OnInit {

  optionsDemandsVsSquad: EChartOption;
  optionsInExecution: EChartOption;
  project: FormControl;

  optionsRadar: EChartOption;

  constructor(private _overviewService: OverviewService, private chartsConfiguration: ChartsConfigurationService) { }

  ngOnInit() {
    this.project = new FormControl('1');

    this.project.valueChanges.subscribe(projectId => {
      console.log(projectId);
    });

    this._overviewService.getDemandsOverview(1).subscribe(demands => {
      console.log(demands);
    });

    this.optionsDemandsVsSquad = this.chartsConfiguration.demandsVsSquad(null);
    this.optionsInExecution = this.chartsConfiguration.inExecution();

    this.optionsRadar = this.chartsConfiguration.radar();
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


