import { AfterViewInit, Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { EChartOption, ECharts } from 'echarts';
import { Client } from 'src/app/core/models';
import { AuthService, ChartsConfigurationService, OverviewService } from 'src/app/core/services';

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
  clients: Client[];
  controlSquad: FormControl;
  series: any[];

  constructor(
    private authService: AuthService,
    private chartsConfiguration: ChartsConfigurationService) { }

  ngOnInit() {
    this.series = [
      { id: 1, value: 0, type: 1, name: '1. Entrega de valor ao cliente', itemStyle: {} },
      { id: 2, value: 0, type: 1, name: '2. Satisfação do cliente', itemStyle: {} },
      { id: 3, value: 0, type: 1, name: '3. Cycle Time de histórias', itemStyle: {} },
      { id: 4, value: 0, type: 1, name: '4. Product Backlog', itemStyle: {} },
      { id: 5, value: 0, type: 1, name: '5. Sprint Backlog', itemStyle: {} },
      { id: 6, value: 0, type: 2, name: '1. Práticas DevOps', itemStyle: {} },
      { id: 7, value: 0, type: 2, name: '2. A execução de testes automatizados faz cobertura dos principais cenários?', itemStyle: {} },
      { id: 8, value: 0, type: 2, name: '3. Clean Code', itemStyle: {} },
      { id: 9, value: 0, type: 2, name: '4. Código Sustentável (Refactoring)', itemStyle: {} },
      { id: 10, value: 0, type: 2, name: '5. Volume de defeitos dentro das Sprints', itemStyle: {} },
      { id: 11, value: 0, type: 3, name: '1. Producção de Baclogs (SLA >= 2.0)', itemStyle: {} },
      { id: 12, value: 0, type: 3, name: '2. Velocidade da Equipe (SLA >= 1.0)', itemStyle: {} },
      { id: 13, value: 0, type: 3, name: '3. Qualidade da Entrega (SLA <= 5%)', itemStyle: {} },
      { id: 14, value: 0, type: 3, name: '4. Eficácia dos Testes (SLA <= 10%)', itemStyle: {} },
      { id: 15, value: 0, type: 3, name: '5. Índice dos Testes (SLA <= 20%)', itemStyle: {} },
      { id: 16, value: 0, type: 4, name: '1. Ferramentas e Documentação', itemStyle: {} },
      { id: 17, value: 0, type: 4, name: '2. Cerimônias', itemStyle: {} },
      { id: 18, value: 0, type: 4, name: '3. Scrum Master', itemStyle: {} },
      { id: 19, value: 0, type: 4, name: '4. Product Owner', itemStyle: {} },
      { id: 20, value: 0, type: 4, name: '5. Líder Técnic', itemStyle: {} },
    ];

    this.optionsRadar = this.chartsConfiguration.radar(this.series);

    this.controlSquad = new FormControl();
    this.valueChanges();

    this.clients = this.authService.clients;

    if (this.clients.length && this.clients[0].squads.length) {
      const squadId = this.clients[0].squads[0].id;
      this.controlSquad.setValue(squadId);
    }
  }

  ngAfterViewInit(): void {
    this.radarChart = echarts.init(this.radar.nativeElement);
  }

  valueChanges() {
    this.controlSquad.valueChanges.subscribe(squadId => {
      console.log(squadId);
    });
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
