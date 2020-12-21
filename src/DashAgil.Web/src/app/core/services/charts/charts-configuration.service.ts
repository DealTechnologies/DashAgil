import { Injectable } from '@angular/core';
import { EChartOption } from 'echarts';
import * as moment from 'moment';
import { EmailCount, OverviewDemand, OverviewFeature } from '../../models';

interface ChartData {
  value: number | string;
  name?: string;
  id?: string
}

@Injectable()
export class ChartsConfigurationService {

  constructor() { }

  demandsVsSquad(overview: OverviewDemand): EChartOption {

    const legends: string[] = overview.listaEstoriasPorSquad.map(item => item.squadNome);
    const data: ChartData[] = overview.listaEstoriasPorSquad.map(item => ({ name: item.squadNome, value: item.quantidade }));

    const chartOptions: EChartOption = {
      tooltip: {
        trigger: 'item',
        formatter: '{b}: {c} demandas'
      },
      legend: {
        orient: 'vertical',
        type: 'scroll',
        left: '60%',
        align: 'left',
        textStyle: {
          color: '#fff'
        },
        data: legends,
      },
      series: [
        {
          type: 'pie',
          radius: ['38%', '70%'],
          center: [200, '50%'],
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
          data: data
        }
      ]
    };

    return chartOptions;
  }

  inExecution(overview: OverviewDemand): EChartOption {

    const data: ChartData[] = [{ value: overview.totalGeralEstorias }];

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
          data: data
        }
      ]
    };

    return chartOptions;
  }

  squad(overview: OverviewFeature): EChartOption {

    const legends: string[] = overview.ListaFeaturesEstagio.map(item => item.featureDescricao);

    const remanescente = overview.ListaFeaturesEstagio.map(item => item.remanescente);
    const emAndamento = overview.ListaFeaturesEstagio.map(item => item.emAndamento);
    const desenvolvimentoConcluido = overview.ListaFeaturesEstagio.map(item => item.desenvolvimentoConcluido);
    const homologacao = overview.ListaFeaturesEstagio.map(item => item.homologacao);
    const homologado = overview.ListaFeaturesEstagio.map(item => item.homologado);
    const concluido = overview.ListaFeaturesEstagio.map(item => item.concluido);

    const formatter = (params: any) => {
      return params.value > 0 ? params.value + '%' : '';
    }

    const chartOptions: EChartOption = {
      tooltip: {
        trigger: 'axis',
        axisPointer: {
          type: 'line',
          label: {
            backgroundColor: '#6a7985'
          }
        },
      },
      legend: {
        type: 'scroll',
        data: [
          { name: 'Concluído' },
          { name: 'Desenvolvimento Concluído' },
          { name: 'Homologação' },
          { name: 'Homologado' },
          { name: 'Em Andamento' },
          { name: 'Remanescente' },
        ],
        textStyle: {
          color: 'rgba(255, 255, 255, 1)'
        },
        bottom: 0
      },
      grid: {
        top: 5,
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
        data: legends,
        axisLine: { show: false },
        axisTick: { show: false },
        axisLabel: {
          color: 'rgba(255, 255, 255, 1)'
        },
      },
      dataZoom: [
        {
          show: true,
          type: 'slider',
          minValueSpan: 4,
          maxValueSpan: 4,
          yAxisIndex: [0],
          handleSize: 0,
          orient: 'vertical',
          borderColor: "rgba(43,48,67,.8)",
          fillerColor: '#33384b',
          start: 100,
          textStyle: {
            color: 'rgba(255, 255, 255, 1)'
          },
          left: '97%',
          right: 15,
        },
        {
          type: 'inside',
          show: true,
          yAxisIndex: [0]
        },
      ],
      series: [
        {
          name: 'Concluído',
          type: 'bar',
          barWidth: '20px',
          stack: '1',
          itemStyle: {
            color: 'rgb(0, 176, 80)'
          },
          label: {
            show: true,
            position: 'inside',
            formatter: formatter
          },
          data: concluido
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
            formatter: formatter
          },
          data: desenvolvimentoConcluido
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
            formatter: formatter
          },
          data: homologacao
        },
        {
          name: 'Homologado',
          type: 'bar',
          barWidth: '35%',
          itemStyle: {
            color: 'rgb(0, 190, 240)'
          },
          stack: '1',
          label: {
            show: true,
            position: 'inside',
            formatter: formatter
          },
          data: homologado
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
            formatter: formatter
          },
          data: emAndamento
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
            formatter: formatter
          },
          data: remanescente
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

    if (overview.SprintBurndown) {
      const start = moment(overview.SprintBurndown.dataInicio).format('DD/MMM');
      const end = moment(overview.SprintBurndown.dataFim).format('DD/MMM');
      title = `${start} - ${end}`;

      categories = overview.SprintBurndown.demandasHistoricos.map(item => moment(item.dia).format('DD/MM/YYYY'));
      seriesTotal = overview.SprintBurndown.demandasHistoricos.map(item => ({ name: moment(item.dia).format('DD/MM/YYYY'), value: item.pontosTotalDia }));
      seriesComplete = overview.SprintBurndown.demandasHistoricos.map(item => ({ name: moment(item.dia).format('DD/MM/YYYY'), value: item.pontosConcluidosDia }));
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
      tooltip: {
        trigger: 'axis',
        axisPointer: {
          type: 'cross',
          label: {
            backgroundColor: '#6a7985'
          }
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

  velocity(velocity: { [key: string]: number }): EChartOption {

    const sprints = Object.keys(velocity);
    const data: ChartData[] = sprints.map(item => ({ name: item, value: velocity[item] })).reverse();

    const interval = Math.trunc(data.reduce((a, b) => a + Number(b.value), 0) / data.length / 2);
    const max = Math.max(...data.map(item => Number(item.value))) + interval;

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
          data: sprints,
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
          interval: interval,
          max: max,
          axisLine: {
            lineStyle: {
              color: 'transparent'
            }
          },
          axisLabel: {
            color: 'rgba(255, 255, 255, 1)'
          },
        }
      ],
      series: [
        {
          type: 'bar',
          boundaryGap: ['0%'],
          barWidth: 15,
          itemStyle: {
            color: 'rgb(79, 129, 189)'
          },
          // markLine: {
          //   lineStyle: {
          //     type: 'dashed'
          //   },
          //   data: [
          //     //@ts-ignore
          //     [{ type: 'min' }, { type: 'max' }]
          //   ]
          // },
          data: data,
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
        data: ['31 nov', '30 jan', '31 mar', '31 mai', '31 jul', '31 set', '31 nov', '30 nov', '18 dez'],
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

  radar(data: any): EChartOption {
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

  emails(emailCount: EmailCount): EChartOption {
    const legends = ['Criado', 'Enviado', 'Entregue', 'Rejeitado', 'Lixo', 'Aberto', 'Clicado'];
    const data = legends.map(key => ({ name: key, value: emailCount[key.toLowerCase()] || '-' }));

    const chartOptions: EChartOption = {
      tooltip: {
        trigger: 'item',
        formatter: '{b}: {c} demandas'
      },
      legend: {
        orient: 'vertical',
        align: 'left',
        type: 'scroll',
        left: '5%',
        top: '10%',
        textStyle: {
          color: '#fff'
        },
        data: legends,
      },
      series: [
        {
          type: 'pie',
          radius: ['38%', '70%'],
          center: ['50%', '50%'],
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
          data: data
        }
      ]
    };

    return chartOptions;
  }
}
