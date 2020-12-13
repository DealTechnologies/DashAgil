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

  options3: EChartOption;

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

    this.chart3();
  }

  private chart3() {
    this.options3 = {
      angleAxis: {
        type: 'category',
        data: [1, 2, 3, 4, 5, 1, 2, 3, 4, 5, 1, 2, 3, 4, 5, 1, 2, 3, 4, 5],
        min: 0,
        max: 19,
        axisLine: {
          show: true,
          lineStyle: {
            color: 'rgba(255, 255, 255, 1)'
          }
        },
        axisTick: {
          show: true,
          length: 20
        }
      },
      radiusAxis: {
        min: 0,
        max: 5,
        axisLine: {
          lineStyle: {
            color: 'transparent'
          },
        }
      },
      polar: {
      },
      tooltip: {
      },
      itemStyle: {
        borderWidth: 0.5,
        borderColor: 'black'
      },
      series: [
        {
          type: 'bar',
          showBackground: true,
          //@ts-ignore
          barWidth: '100%',
          backgroundStyle: {
            color: 'transparent',
            borderWidth: 0.5,
            borderColor: 'rgba(255, 255, 255, 1)'
          },
          coordinateSystem: 'polar',
          data: [
            { value: 1, name: 'rose1', itemStyle: { color: 'rgb(254, 0, 0)' } },
            { value: 2, name: 'rose2', itemStyle: { color: 'rgb(254, 0, 0)' } },
            { value: 3, name: 'rose3', itemStyle: { color: 'rgb(255, 255, 0)' } },
            { value: 4, name: 'rose4', itemStyle: { color: 'rgb(0, 255, 1)' } },
            { value: 5, name: 'rose5', itemStyle: { color: 'rgb(0, 255, 1)' } },
            { value: 4, name: 'rose6', itemStyle: { color: 'rgb(0, 255, 1)' } },
            { value: 2, name: 'rose7', itemStyle: { color: 'rgb(254, 0, 0)' } },
            { value: 1, name: 'rose8', itemStyle: { color: 'rgb(254, 0, 0)' } },
            { value: 5, name: 'rose9', itemStyle: { color: 'rgb(0, 255, 1)' } },
            { value: 2, name: 'rose10', itemStyle: { color: 'rgb(254, 0, 0)' } },
            { value: 3, name: 'rose11', itemStyle: { color: 'rgb(255, 255, 0)' } },
            { value: 4, name: 'rose12', itemStyle: { color: 'rgb(0, 255, 1)' } },
            { value: 5, name: 'rose13', itemStyle: { color: 'rgb(0, 255, 1)' } },
            { value: 4, name: 'rose14', itemStyle: { color: 'rgb(0, 255, 1)' } },
            { value: 3, name: 'rose15', itemStyle: { color: 'rgb(255, 255, 0)' } },
            { value: 4, name: 'rose16', itemStyle: { color: 'rgb(0, 255, 1)' } },
            { value: 5, name: 'rose17', itemStyle: { color: 'rgb(0, 255, 1)' } },
            { value: 2, name: 'rose18', itemStyle: { color: 'rgb(254, 0, 0)' } },
            { value: 3, name: 'rose19', itemStyle: { color: 'rgb(255, 255, 0)' } },
            { value: 4, name: 'rose20', itemStyle: { color: 'rgb(0, 255, 1)' } },
          ]
        },
      ],
    };
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


