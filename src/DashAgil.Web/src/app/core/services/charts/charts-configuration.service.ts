import { Injectable } from '@angular/core';
import { EChartOption } from 'echarts';
import { Overview } from '../../models';

@Injectable()
export class ChartsConfigurationService {

  constructor() { }

  demandsVsSquad(overview: Overview) {

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

  inExecution() {

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

  squad() {
    const chartOptions: EChartOption = {
      tooltip: {
        trigger: 'axis',
        axisPointer: {
          type: 'line'
        }
      },
      legend: {
        data: [
          { name: 'Concluído' },
          { name: 'Desenvolvimento Concluído' },
          { name: 'Homologação' },
          { name: 'Em Andamento' },
          { name: 'Remanescente' },
        ],
        textStyle: {
          color: 'rgba(255, 255, 255, 1)'
        },
        bottom: 0
      },
      grid: {
        top: '3%',
        left: '3%',
        right: '4%',
        bottom: '10%',
        containLabel: true
      },
      xAxis: {
        type: 'value',
        max: 100,
        position: 'top',
        axisLabel: {
          formatter: '{value}%',
          color: 'rgba(255, 255, 255, 1)'
        },
        axisLine: { show: false },
        axisTick: { show: false }
      },
      yAxis: {
        type: 'category',
        data: [
          'Monitoramento de Auditoria',
          'Donload de Documentos',
          'Consulta de Documentos',
          'Cadastro de Documentos',
          'Tratamento das Requisições pelo Sistema de Câmbio',
          'Estruturação do Projeto'
        ],
        axisLine: { show: false },
        axisTick: { show: false },
        axisLabel: {
          color: 'rgba(255, 255, 255, 1)'
        },
      },
      series: [
        {
          name: 'Concluído',
          type: 'bar',
          barWidth: '35%',
          stack: '1',
          itemStyle: {
            color: 'rgb(0, 176, 80)'
          },
          label: {
            show: true,
            position: 'inside',
            formatter: '{c}%'
          },
          data: []
        }, 
        {
          name: 'Desenvolvimento Concluído',
          type: 'bar',
          barWidth: '35%',
          stack: '1',
          itemStyle: {
            color: 'rgb(169, 209, 142)'
          },
          label: {
            show: true,
            position: 'inside',
            formatter: '{c}%'
          },
          data: [30, 40, 50, 60, 70, 80, 90]
        },
        {
          name: 'Homologação',
          type: 'bar',
          barWidth: '35%',
          itemStyle: {
            color: 'rgb(0, 176, 240)'
          },
          stack: '1',
          label: {
            show: true,
            position: 'inside',
            formatter: '{c}%'
          },
          data: [70, 60, 50, 40, 30, 20, 10]
        },
        {
          name: 'Em Andamento',
          type: 'bar',
          barWidth: '35%',
          stack: '1',
          itemStyle: {
            color: 'rgb(255, 192, 0)'
          },
          label: {
            show: true,
            position: 'inside',
            formatter: '{c}%'
          },
          data: []
        },
        {
          name: 'Remanescente',
          type: 'bar',
          barWidth: '35%',
          stack: '1',
          itemStyle: {
            color: 'rgb(166, 166, 166)'
          },
          label: {
            show: true,
            position: 'inside',
            formatter: '{c}%'
          },
          data: []
        },
      ]
    };

    return chartOptions;
  }

  sprint() {
    const chartOptions: EChartOption = {
      legend: {
        icon: 'roundRect',
        data: [
          { name: 'Velocidade Ideal' },
          { name: 'Velocidade da Sprint' },
        ],
        textStyle: {
          color: 'rgba(255, 255, 255, 1)'
        },
        bottom: 0
      },
      grid: {
        top: '3%',
      },
      xAxis: {
        type: 'category',
        data: ['1', '2', '3', '4', '5', '6', '7', '8'],
        axisLabel: {
          color: 'rgba(255, 255, 255, 1)'
        },
        axisLine: {
          lineStyle: {
            color: 'rgba(255, 255, 255, 1)'
          }
        }
      },
      yAxis: {
        type: 'value',
        axisLine: {
          lineStyle: {
            color: 'rgba(255, 255, 255, 1)'
          }
        },
        axisTick: {
          show: false
        },
        splitLine: {
          show: true,
          lineStyle: {
            type: 'dashed'
          }
        }
      },
      series: [{
        name: 'Velocidade Ideal',
        data: [90, 80, 40, 55, 30, 28, 15, 0],
        type: 'line',
        symbol: 'none',
        lineStyle: {
          color: 'rgb(190, 75, 72)',
          width: 3,
        },
      },
      {
        name: 'Velocidade da Sprint',
        data: [90, 90, 50, 42, 27, 30, 20, 0],
        type: 'line',
        symbol: 'none',
        lineStyle: {
          color: 'rgb(125, 95, 160)',
          width: 3,
        },
      },
      ]
    };

    return chartOptions;
  }

}
