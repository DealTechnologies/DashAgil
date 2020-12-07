import { Component, OnInit } from '@angular/core';
import { EChartOption } from 'echarts';
import { OverviewService } from 'src/app/core/services';

@Component({
  selector: 'app-overview',
  templateUrl: './overview.component.html',
  styleUrls: ['./overview.component.scss']
})
export class OverviewComponent implements OnInit {

  options1: EChartOption;
  options2: EChartOption;
  options3: EChartOption;
  options4: EChartOption;
  options5: EChartOption;
  options6: EChartOption;

  constructor(private _overviewService: OverviewService) { }

  ngOnInit() {
    this._overviewService.getDemandsOverview().subscribe(demands => {
      console.log(demands);      
    });

    this.chart1();
    this.chart2();
    this.chart3();
    this.chart4();
    this.chart5();
    this.chart6();
  }

  private chart1() {
    this.options1 = {
      tooltip: {
        trigger: 'item',
        formatter: '{a} <br/>{b}: {c}'
      },
      legend: {
        orient: 'vertical',
        right: 20,
        textStyle: {
          color: '#fff'
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

  private chart2() {
    this.options2 = {
      legend: {
        icon: 'roundRect',
        data: ['1', '2'],
        textStyle: {
          color: 'rgba(255, 255, 255, 1)'
        }
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
        name: '1',
        data: [90, 80, 40, 55, 30, 28, 15, 0],
        type: 'line',
        symbol: 'none',
        lineStyle: {
          color: 'rgb(190, 75, 72)',
          width: 3,
        },
      },
      {
        name: '2',
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

  private chart4() {
    this.options4 = {
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
        left: '3%',
        right: '4%',
        bottom: '3%',
        containLabel: true
      },
      xAxis: [
        {
          type: 'category',
          data: [
            'Sprint 0',
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
            'Sprint 12'
          ],
          axisLine: {
            lineStyle: {
              color: 'rgba(255, 255, 255, 1)'
            }
          },
        }
      ],
      yAxis: [
        {
          type: 'value',
          axisLine: {
            lineStyle: {
              color: 'rgba(255, 255, 255, 1)'
            }
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
          data: [18, 32, 47, 33, 88, 56, 62, 67, 94, 106, 158, 143, 231],
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
  }

  private chart5() {
    this.options5 = {
      tooltip: {
        trigger: 'axis',
        axisPointer: {
          type: 'line'
        }
      },
      legend: {
        data: ['1', '2'],
        textStyle: {
          color: 'rgba(255, 255, 255, 1)'
        }
      },
      grid: {
        left: '3%',
        right: '4%',
        bottom: '3%',
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
        data: ['1', '2', '3', '4', '5', '6'],
        axisLine: { show: false },
        axisTick: { show: false },
        axisLabel: {
          color: 'rgba(255, 255, 255, 1)'
        },
      },
      series: [
        {
          name: '1',
          type: 'bar',
          barWidth: '35%',
          stack: '1',
          itemStyle: {
            color: 'rgb(169, 209, 142)'
          },
          label: {
            show: true,
            position: 'inside'
          },
          data: [30, 40, 50, 60, 70, 80, 90]
        },
        {
          name: '2',
          type: 'bar',
          barWidth: '35%',
          itemStyle: {
            color: 'rgb(0, 176, 240)'
          },
          stack: '1',
          label: {
            show: true,
            position: 'inside'
          },
          data: [70, 60, 50, 40, 30, 20, 10]
        },
      ]
    };
  }

  private chart6() {
    this.options6 = {
      grid: {
        bottom: 80
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
        data: ['1', '2'],
        left: 10,        
        textStyle: {
          color: 'rgba(255, 255, 255, 1)'
        }
      },
      dataZoom: [
        {
          show: true,
          realtime: true,
          start: 1,
          end: 100,
          dataBackground: {
            areaStyle: {
              color: 'rgb(136, 136, 136)',
              opacity: 1
            }
          }
        },
        {
          type: 'inside',
          realtime: true,
          start: 1,
          end: 100
        }
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
          name: '1',
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
          name: '2',
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


