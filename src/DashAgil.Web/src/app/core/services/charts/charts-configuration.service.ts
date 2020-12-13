import { Injectable } from '@angular/core';
import { EChartOption } from 'echarts';
import { Overview } from '../../models';

@Injectable()
export class ChartsConfigurationService {

  constructor() { }

  demandsVsSquad(overview: Overview): EChartOption {

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

  inExecution(): EChartOption {

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

  squad(): EChartOption {
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
        top: 0,
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

  sprint(): EChartOption {
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
        height: '70%'
      },
      xAxis: {
        type: 'category',
        data: [
          '29/09/2020',
          '30/09/2020',
          '01/10/2020',
          '02/10/2020',
          '03/10/2020',
          '04/10/2020',
          '05/10/2020',
          '06/10/2020',
          '07/10/2020',
          '08/10/2020',
          '09/10/2020',
          '10/10/2020',
          '11/10/2020',
          '12/10/2020',
          '13/10/2020',
        ],
        axisLabel: {
          color: 'rgba(255, 255, 255, 1)',
          rotate: 55,
          fontSize: 8
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
        data: [95, 95, 82, 70, 60, 58, 55, 40, 38, 35, 28, 22, 18, 10, 0],
        type: 'line',
        symbol: 'none',
        lineStyle: {
          color: 'rgb(190, 75, 72)',
          width: 3,
        },
      },
      {
        name: 'Velocidade da Sprint',
        data: [95, 95, 95, 80, 75, 70, 52, 35, 28, 42, 30, 20, 15, 15, 0],
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

  velocity(): EChartOption {
    const chartOptions: EChartOption = {
      tooltip: {
        trigger: 'axis',
        axisPointer: {
          type: 'line'
        }
      },
      legend: {
        textStyle: {
          color: 'rgba(255, 255, 255, 1)'
        }
      },
      grid: {
        top: '3%',
        left: '3%',
        right: '2%',
        bottom: '3%',
        containLabel: true
      },
      xAxis: [
        {
          type: 'category',
          data: [
            'Sprint 1',
            'Sprint 2',
            'Sprint 3',
            'Sprint 4',
            'Sprint 5',
            'Sprint 6',
            'Sprint 7',
            'Sprint 8',
            'Sprint 9',
            'Sprint 10',
            'Sprint 11',
            'Sprint 12',
            'Sprint 13',
            'Sprint 14',
            'Sprint 15',
            'Sprint 16',
            'Sprint 17',
            'Sprint 18',
            'Sprint 19',
          ],
          axisLine: {
            lineStyle: {
              color: 'rgba(255, 255, 255, 1)'
            }
          },
          axisLabel: {
            color: 'rgba(255, 255, 255, 1)',
            rotate: 55,
            fontSize: 10
          },
          axisTick: {
            show: false
          }
        }
      ],
      yAxis: [
        {
          type: 'value',
          axisLine: {
            lineStyle: {
              color: 'transparent'
            }
          },
          axisLabel: {
            color: 'rgba(255, 255, 255, 1)'
          },
          interval: 50,
          max: 300
        }
      ],
      series: [
        {
          type: 'bar',
          boundaryGap: '0%',
          barWidth: 15,
          itemStyle: {
            color: 'rgb(79, 129, 189)'
          },
          data: [18, 32, 47, 33, 88, 56, 63, 67, 94, 106, 158, 143, 231, 147, 125, 113, 90, 111, 252],
          markLine: {
            lineStyle: {
              type: 'dashed'
            },
            data: [
              //@ts-ignore
              [{ type: 'min' }, { type: 'max' }]
            ]
          }
        }
      ]
    };

    return chartOptions;
  }

  cumulativeFlow(): EChartOption {
    const chartOptions: EChartOption = {
      grid: {
        top: '3%',
        left: '7%',
        right: '2%',
        bottom: 100,
      },
      tooltip: {
        trigger: 'axis',
        axisPointer: {
          type: 'cross',
          animation: false,
          label: {
            backgroundColor: '#505765'
          }
        }
      },
      legend: {
        icon: 'roundRect',
        data: [
          'Em Backlog',
          'Priorizado',
          'Análise de Viabilidade',
          'Especificação',
          'Backlog Desenvolvimento',
          'Em Desenvolvimento',
          'Em GC',
          'Pacote Liberado',
          'Em Homologação',
          'Fila de Produção',
          'Concluído',
          'Promover na Main',
        ],
        textStyle: {
          color: 'rgba(255, 255, 255, 1)'
        },
        bottom: 0
      },
      dataZoom: [
        {
          show: false,
          realtime: true,
          start: 1,
          end: 100,
          dataBackground: {
            areaStyle: {
              color: 'rgb(136, 136, 136)',
              opacity: 1
            }
          },
        },
        {
          type: 'inside',
          realtime: true,
          start: 1,
          end: 100
        },
      ],
      xAxis:
      {
        type: 'category',
        boundaryGap: false,
        data: [1, 2, 3, 4, 5, 6, 7, 8, 9, 10],
        axisLine: {
          lineStyle: {
            color: 'rgba(255, 255, 255, 1)'
          }
        },
      },
      yAxis:
      {
        type: 'value',
        max: 300,
        axisLine: {
          lineStyle: {
            color: 'rgba(255, 255, 255, 1)'
          }
        },
      },
      series: [
        {
          name: 'Em Backlog',
          type: 'line',
          symbol: 'none',
          zlevel: 10,
          areaStyle: {
            color: 'rgb(136, 136, 136)',
            opacity: 1
          },
          lineStyle: {
            width: 0
          },
          data: [0, 5, 50, 20, 10, 15, 20, 8, 5, 5]
        },
        {
          name: 'Priorizado',
          type: 'line',
          symbol: 'none',
          zlevel: 9,
          areaStyle: {
            color: 'rgb(246, 139, 30)',
            opacity: 1
          },
          lineStyle: {
            width: 0
          },
          data: [0, 5, 50, 30, 20, 25, 32, 15, 12, 8]
        },
        {
          name: 'Análise de Viabilidade',
          type: 'line',
          symbol: 'none',
          zlevel: 8,
          areaStyle: {
            color: 'rgb(0, 122, 204)',
            opacity: 1
          },
          lineStyle: {
            width: 0
          },
          data: [0, 5, 50, 40, 50, 45, 40, 60, 30, 20]
        },
        {
          name: 'Especificação',
          type: 'line',
          symbol: 'none',
          zlevel: 7,
          areaStyle: {
            color: 'rgb(156, 195, 178)',
            opacity: 1
          },
          lineStyle: {
            width: 0
          },
          data: [0, 5, 50, 80, 90, 110, 90, 100, 50, 80]
        },
        {
          name: 'Backlog Desenvolvimento',
          type: 'line',
          symbol: 'none',
          zlevel: 6,
          areaStyle: {
            color: 'rgb(127, 23, 37)',
            opacity: 1
          },
          lineStyle: {
            width: 0
          },
          data: [0, 5, 50, 80, 90, 200, 230, 115, 150, 110]
        },
        {
          name: 'Em Desenvolvimento',
          type: 'line',
          symbol: 'none',
          zlevel: 5,
          areaStyle: {
            color: 'rgb(136, 136, 136)',
            opacity: 1
          },
          lineStyle: {
            width: 0
          },
          data: [0, 5, 50, 100, 120, 230, 270, 150, 200, 180]
        },
        {
          name: 'Em GC',
          type: 'line',
          symbol: 'none',
          zlevel: 5,
          areaStyle: {
            color: 'rgb(136, 136, 136)',
            opacity: 1
          },
          lineStyle: {
            width: 0
          },
          data: [0, 5, 50, 100, 120, 230, 270, 150, 200, 180]
        },
        {
          name: 'Pacote Liberado',
          type: 'line',
          symbol: 'none',
          zlevel: 5,
          areaStyle: {
            color: 'rgb(136, 136, 136)',
            opacity: 1
          },
          lineStyle: {
            width: 0
          },
          data: [0, 5, 50, 100, 120, 230, 270, 150, 200, 180]
        },
        {
          name: 'Em Homologação',
          type: 'line',
          symbol: 'none',
          zlevel: 5,
          areaStyle: {
            color: 'rgb(136, 136, 136)',
            opacity: 1
          },
          lineStyle: {
            width: 0
          },
          data: [0, 5, 50, 100, 120, 230, 270, 150, 200, 180]
        },
        {
          name: 'Fila de Produção',
          type: 'line',
          symbol: 'none',
          zlevel: 5,
          areaStyle: {
            color: 'rgb(136, 136, 136)',
            opacity: 1
          },
          lineStyle: {
            width: 0
          },
          data: [0, 5, 50, 100, 120, 230, 270, 150, 200, 180]
        },
        {
          name: 'Concluído',
          type: 'line',
          symbol: 'none',
          zlevel: 5,
          areaStyle: {
            color: 'rgb(136, 136, 136)',
            opacity: 1
          },
          lineStyle: {
            width: 0
          },
          data: [0, 5, 50, 100, 120, 230, 270, 150, 200, 180]
        },
        {
          name: 'Promover na Main',
          type: 'line',
          symbol: 'none',
          zlevel: 5,
          areaStyle: {
            color: 'rgb(136, 136, 136)',
            opacity: 1
          },
          lineStyle: {
            width: 0
          },
          data: [0, 5, 50, 100, 120, 230, 270, 150, 200, 180]
        },
      ]
    };

    return chartOptions;
  }

  radar(): EChartOption {
    const chartOptions: EChartOption = {
      angleAxis: {
        type: 'category',
        data: [1, 2, 3, 4, 5, 1, 2, 3, 4, 5, 1, 2, 3, 4, 5, 1, 2, 3, 4, 5,
          // { value: '1. Entrega de valor ao cliente', },
          // { value: '2. Satisfação do cliente', },
          // { value: '3. Cycle Time de histórias', },
          // { value: '4. Product Backlog', },
          // { value: '5. Sprint Backlog', },
          // { value: '1. Práticas DevOps', },
          // { value: '2. A execução de testes automatizados faz cobertura dos principais cenários?', },
          // { value: '3. Clean Code', },
          // { value: '4. Código Sustentável (Refactoring)', },
          // { value: '5. Volume de defeitos dentro das Sprints', },
          // { value: '1. Producção de Baclogs (SLA >= 2.0)', },
          // { value: '2. Velocidade da Equipe (SLA >= 1.0)', },
          // { value: '3. Qualidade da Entrega (SLA <= 5%)', },
          // { value: '4. Eficácia dos Testes (SLA <= 10%)', },
          // { value: '5. Índice dos Testes (SLA <= 20%)', },
          // { value: '1. Ferramentas e Documentação', },
          // { value: '2. Cerimônias', },
          // { value: '3. Scrum Master', },
          // { value: '4. Product Owner', },
          // { value: '5. Líder Técnico', }
        ],
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
        },
        axisLabel: {
          //show: false
        },

      },
      grid: {
        top: 0,
        bottom: 0,
        right: 0,
        left: 0,
      },
      xAxis: {
        min: -1,
        max: 1,
        zlevel: 20,
        axisLine: {
          show: true,
          lineStyle: {
            color: "rgba(6, 6, 6, 1)",
            width: 3
          }
        },
        axisTick: {
          show: false
        },
        axisLabel: {
          show: false
        },
        splitLine: {
          show: false
        }
      },
      yAxis: {
        min: -1,
        max: 1,
        zlevel: 20,
        axisLine: {
          show: true,
          lineStyle: {
            color: "rgba(6, 6, 6, 1)",
            width: 3
          }
        },
        axisLabel: {
          show: false
        },
        axisTick: {
          show: false
        },
        splitLine: {
          show: false
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

    return chartOptions;
  }
}
