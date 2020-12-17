import { Injectable } from '@angular/core';
import { EChartOption } from 'echarts';
import * as moment from 'moment';
import { OverviewDemand, OverviewFeature } from '../../models';

interface ChartData {
  name?: string;
  value: number | string;
}

@Injectable()
export class ChartsConfigurationService {

  constructor() { }

  demandsVsSquad(overview: OverviewDemand): EChartOption {

    const legends: string[] = overview.listaEstoriasPorSquad.map(item => item.squadNome);
    const series: ChartData[] = overview.listaEstoriasPorSquad.map(item => ({ name: item.squadNome, value: item.quantidade }));

    const chartOptions: EChartOption = {
      tooltip: {
        trigger: 'item',
        formatter: '{b}: {c} demandas'
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
          data: series
        }
      ]
    };

    return chartOptions;
  }

  inExecution(overview: OverviewDemand): EChartOption {

    const series: ChartData[] = [{ value: overview.totalGeralEstorias }];

    const chartOptions: EChartOption = {
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
          data: series
        }
      ]
    };

    return chartOptions;
  }

  squad(overview: OverviewFeature): EChartOption {

    const legends: string[] = []// overview.listaEstoriasPorSquad.map(item => item.squadNome);
    const series: ChartData[] = [] //overview.listaEstoriasPorSquad.map(item => ({ name: item.squadNome, value: item.quantidade }));

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

  sprint(overview: OverviewFeature): EChartOption {

    let title: string;
    let categories: string[];
    let seriesTotal: ChartData[];
    let seriesComplete: ChartData[];

    if (overview.sprintBurndown) {
      const start = moment(overview.sprintBurndown.dataInicio).format('DD/MMM');
      const end = moment(overview.sprintBurndown.dataFim).format('DD/MMM');
      title = `${start} - ${end}`;

      categories = overview.sprintBurndown.demandasHistoricos.map(item => moment(item.dia).format('DD/MM/YYYY'));
      seriesTotal = overview.sprintBurndown.demandasHistoricos.map(item => ({ name: moment(item.dia).format('DD/MM/YYYY'), value: item.pontosTotalDia }));
      seriesComplete = overview.sprintBurndown.demandasHistoricos.map(item => ({ name: moment(item.dia).format('DD/MM/YYYY'), value: item.pontosConcluidosDia }));
    }

    const chartOptions: EChartOption = {
      title: {
        text: title,
        // textAlign: 'center',
        textStyle: {
          color: 'rgba(255, 255, 255, 1)',
          fontSize: 15,
          align: 'center'
        }
      },
      legend: {
        icon: 'roundRect',
        data: ['Velocidade Ideal', 'Velocidade da Sprint'],
        textStyle: {
          color: 'rgba(255, 255, 255, 1)'
        },
        bottom: 0
      },
      grid: {
        top: 45,
        bottom: 80,
      },
      xAxis: {
        type: 'category',
        data: categories,
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
        data: seriesTotal,
        type: 'line',
        symbol: 'none',
        lineStyle: {
          color: 'rgb(190, 75, 72)',
          width: 3,
        },
      },
      {
        name: 'Velocidade da Sprint',
        data: seriesComplete,
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

  radar(data): EChartOption {
    const chartOptions: EChartOption = {
      angleAxis: {
        type: 'category',
        data: [
          { value: '                                 1. Entrega de valor ao cliente', },
          { value: '2. Satisfação do cliente', },
          { value: '3. Cycle Time de histórias', },
          { value: '4. Product Backlog', },
          { value: '5. Sprint Backlog', },
          { value: '1. Práticas DevOps', },
          { value: '2. A execução de testes automatizados \nfaz cobertura dos principais cenários?', },
          { value: '3. Clean Code', },
          { value: '4. Código Sustentável (Refactoring)', },
          { value: '                                               5.Volume de defeitos dentro das Sprints', },
          { value: '1. Producção de Baclogs (SLA >= 2.0)                                               ', },
          { value: '2. Velocidade da Equipe (SLA >= 1.0)', },
          { value: '3. Qualidade da Entrega (SLA <= 5%)', },
          { value: '4. Eficácia dos Testes (SLA <= 10%)', },
          { value: '5. Índice dos Testes (SLA <= 20%)', },
          { value: '1. Ferramentas e Documentação', },
          { value: '2. Cerimônias', },
          { value: '3. Scrum Master', },
          { value: '4. Product Owner', },
          { value: '5. Líder Técnico            ', }
        ],
        min: 0,
        max: 19,
        axisLine: {
          show: true,
          lineStyle: {
            color: 'rgba(255, 255, 255, 1)',

          }
        },
        axisTick: {
          show: true,
          length: 20
        },
        axisLabel: {
          show: true,
          margin: 20
        },

      },
      grid: {
        top: 0,
        bottom: 0,
        left: '25%',
        right: '25%',
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
          //@ts-ignore
          showBackground: true,
          //@ts-ignore
          barWidth: '100%',
          height: '100%',
          backgroundStyle: {
            color: 'transparent',
            borderWidth: 0.5,
            borderColor: 'rgba(255, 255, 255, 1)'
          },
          coordinateSystem: 'polar',
          data: data
        },
      ],
    };

    return chartOptions;
  }
}
