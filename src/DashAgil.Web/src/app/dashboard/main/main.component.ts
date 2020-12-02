import { Component, OnInit } from '@angular/core';
import { ChartOptions } from 'chart.js';
import { EChartOption } from 'echarts';
import {
  ApexAxisChartSeries,
  ApexChart,
  ApexTooltip,
  ApexPlotOptions,
  ApexDataLabels,
  ApexYAxis,
  ApexXAxis,
  ApexNonAxisChartSeries,
  ApexLegend,
  ApexResponsive
} from 'ng-apexcharts';

export type smallBarChart = {
  series: ApexAxisChartSeries;
  chart: ApexChart;
  plotOptions: ApexPlotOptions;
  tooltip: ApexTooltip;
};

export type smallAreaChart = {
  series: ApexAxisChartSeries;
  chart: ApexChart;
  yaxis: ApexYAxis;
  xaxis: ApexXAxis;
};
export type smallPieChart = {
  series: ApexNonAxisChartSeries;
  chart: ApexChart;
  legend: ApexLegend;
  dataLabels: ApexDataLabels;
  responsive: ApexResponsive[];
  labels: any;
};

export type smallLineChart = {
  series: ApexAxisChartSeries;
  chart: ApexChart;
  yaxis: ApexYAxis;
  xaxis: ApexXAxis;
};

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.scss']
})
export class MainComponent implements OnInit {

  options: EChartOption;

  constructor() { }

  ngOnInit() {
    this.chart1();
  }

  private chart1() {
    this.options = {
      tooltip: {
        trigger: 'item',
        formatter: '{a} <br/>{b}: {c}'
      },
      legend: {
        orient: 'vertical',
        right: 20,
        textStyle: {
          color: "#fff"
        },
        data: [
          'Squad 1',
          'Squad 2',
          'Squad 3',
          'Squad 4',
          'Squad 5',
          'Squad 6',
          'Squad 7',
          'Squad 8',
          'Squad 9',
          'Squad 10']
      },
      series: [
        {
          name: 'Demandas',
          type: 'pie',
          radius: ['38%', '70%'],
          label: {
            show: true,
            color: '#fff',
          },
          emphasis: {
            label: {
              show: true,
              fontSize: 25,
              fontWeight: 'bold',
            }
          },
          labelLine: {
            show: true
          },
          data: [
            { value: 335, name: 'Squad 1' },
            { value: 310, name: 'Squad 2' },
            { value: 234, name: 'Squad 3' },
            { value: 135, name: 'Squad 4' },
            { value: 1200, name: 'Squad 5' },
            { value: 548, name: 'Squad 6' },
            { value: 25, name: 'Squad 7' },
            { value: 85, name: 'Squad 8' },
            { value: 200, name: 'Squad 9' },
            { value: 12, name: 'Squad 10' },
          ]
        }
      ]
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
