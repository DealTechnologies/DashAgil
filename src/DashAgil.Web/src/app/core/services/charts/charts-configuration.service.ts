import { Injectable } from '@angular/core';
import { EChartOption } from 'echarts';
import { Overview } from '../../models';

@Injectable()
export class ChartsConfigurationService {

  constructor() { }

  public contructDemandsVsSquad(overview: Overview) {

    const legends =
      ['Squad 1', 'Squad 2', 'Squad 3', 'Squad 4', 'Squad 5', 'Squad 6', 'Squad 7', 'Squad 8', 'Squad 9', 'Squad 10'];

    const seriesData = [
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
    ];

    const chartOptions: EChartOption = {
      tooltip: {
        trigger: 'item',
        formatter: '{b}: {c}'
      },
      grid: {
      },
      legend: {
        orient: 'vertical',
        right: 20,
        textStyle: {
          color: '#fff'
        },
        data: legends
      },
      series: [
        {
          type: 'pie',
          radius: ['38%', '70%'],
          center: ['40%', '50%'],
          height: 320,
          label: {
            show: true,
            color: '#fff',
            formatter: '{c}',
            backgroundColor: 'black',
            padding: 3,
            align: 'left',
            borderWidth: 1,
            borderRadius: 4,
          },
          labelLine: {
            show: true,
            length: 20,
            length2: 15
          },
          emphasis: {
            label: {
              show: true,
              fontSize: 25,
              fontWeight: 'bold',
            }
          },
          data: seriesData
        }
      ]
    };

    return chartOptions;
  }

  public contructInExecution() {

    const legends =
      ['Squad 1', 'Squad 2', 'Squad 3', 'Squad 4', 'Squad 5', 'Squad 6', 'Squad 7', 'Squad 8', 'Squad 9', 'Squad 10'];

    const seriesData = [
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
    ];

    const chartOptions: EChartOption = {
      // title: {
      //   text: 'Demandas',
      //   textStyle: {
      //     color: 'white'
      //   },
      //   textAlign: 'left'
      // },
      tooltip: {
      },
      grid: {
        left: 10
      },
      xAxis: {
        show: false
      },
      yAxis: {
        type: 'category',
        axisLine: {
          lineStyle: {
            color: 'white'
          }
        },
        axisTick: {
          show: false
        },
      },
      series: [
        {
          type: 'bar',
          label: {
            show: true,
            position: 'right',
            formatter: '{c}',
            color: 'white'
          },
          itemStyle: {
            color: 'rgb(91, 155, 213)'
          },
          barWidth: 20,
          data: [2342]
        }
      ]
    };

    return chartOptions;
  }
}
