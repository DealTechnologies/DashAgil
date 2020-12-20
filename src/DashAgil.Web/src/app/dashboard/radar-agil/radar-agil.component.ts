import { AfterViewInit, Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { EChartOption, ECharts } from 'echarts';
import { ChartsConfigurationService, OverviewService } from 'src/app/core/services';

let echarts = require('echarts');

@Component({
  selector: 'app-radar-agil',
  templateUrl: './radar-agil.component.html',
  styleUrls: ['./radar-agil.component.scss'],
})
export class RadarAgilComponent implements OnInit, AfterViewInit {

  @ViewChild('radar') radar: ElementRef;
  optionsRadar: EChartOption;
  radarChart: ECharts;
  series = [];

  constructor(private chartsConfiguration: ChartsConfigurationService) { }

  ngOnInit() {
    this.series = [
      { value: 0, type: 1, index: 1, name: '1. Entrega de valor ao cliente', itemStyle: {} },
      { value: 0, type: 1, index: 2, name: '2. Satisfação do cliente', itemStyle: {} },
      { value: 0, type: 1, index: 3, name: '3. Cycle Time de histórias', itemStyle: {} },
      { value: 0, type: 1, index: 4, name: '4. Product Backlog', itemStyle: {} },
      { value: 0, type: 1, index: 5, name: '5. Sprint Backlog', itemStyle: {} },
      { value: 0, type: 2, index: 1, name: '1. Práticas DevOps', itemStyle: {} },
      { value: 0, type: 2, index: 2, name: '2. A execução de testes automatizados faz cobertura dos principais cenários?', itemStyle: {} },
      { value: 0, type: 2, index: 3, name: '3. Clean Code', itemStyle: {} },
      { value: 0, type: 2, index: 4, name: '4. Código Sustentável (Refactoring)', itemStyle: {} },
      { value: 0, type: 2, index: 5, name: '5. Volume de defeitos dentro das Sprints', itemStyle: {} },
      { value: 0, type: 3, index: 1, name: '1. Producção de Baclogs (SLA >= 2.0)', itemStyle: {} },
      { value: 0, type: 3, index: 2, name: '2. Velocidade da Equipe (SLA >= 1.0)', itemStyle: {} },
      { value: 0, type: 3, index: 3, name: '3. Qualidade da Entrega (SLA <= 5%)', itemStyle: {} },
      { value: 0, type: 3, index: 4, name: '4. Eficácia dos Testes (SLA <= 10%)', itemStyle: {} },
      { value: 0, type: 3, index: 5, name: '5. Índice dos Testes (SLA <= 20%)', itemStyle: {} },
      { value: 0, type: 4, index: 1, name: '1. Ferramentas e Documentação', itemStyle: {} },
      { value: 0, type: 4, index: 2, name: '2. Cerimônias', itemStyle: {} },
      { value: 0, type: 4, index: 3, name: '3. Scrum Master', itemStyle: {} },
      { value: 0, type: 4, index: 4, name: '4. Product Owner', itemStyle: {} },
      { value: 0, type: 4, index: 5, name: '5. Líder Técnic', itemStyle: {} },
    ];

    this.optionsRadar = this.chartsConfiguration.radar(this.series);
  }

  ngAfterViewInit(): void {
    this.radarChart = echarts.init(this.radar.nativeElement);
  }

  change(serie: any) {
    serie.itemStyle.color = this.selectColor(serie.value);
    this.radarChart.setOption(this.chartsConfiguration.radar(this.series));
  }

  selectColor(value: string) {
    switch (value) {
      case '1':
        return 'rgb(247, 74, 77)';
      case '2':
        return 'rgb(245, 130, 93)';
      case '3':
        return 'rgb(252, 178, 96)';
      case '4':
        return 'rgb(255, 231, 105)';
      case '5':
        return 'rgb(61, 168, 89)';

    }
  }

  taskClick(task, nav: any): void {
    nav.open();
  }

  closeSlider(nav: any) {
    if (nav.open()) {
      nav.close();
    }
  }

  onChartEvent(event: any, type: string) {
    alert(event.name);
  }

}
