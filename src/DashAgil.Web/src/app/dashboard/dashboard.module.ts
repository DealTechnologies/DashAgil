import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DashboardRoutingModule } from './dashboard-routing.module';
import { OverviewComponent } from './overview/overview.component';
import { ChartsModule as chartjsModule } from 'ng2-charts';
import { NgxEchartsModule } from 'ngx-echarts';
import { GaugeModule } from 'angular-gauge';
import { MatIconModule } from '@angular/material/icon';
import { MatMenuModule } from '@angular/material/menu';
import { MatButtonModule } from '@angular/material/button';
import { PerfectScrollbarModule } from 'ngx-perfect-scrollbar';
import { NgApexchartsModule } from 'ng-apexcharts';
import { ChartsConfigurationService, OverviewService } from '../core/services';
import { SharedModule } from '../shared/shared.module';
import { MaterialModule } from '../shared/material.module';
import { SquadComponent } from './squad/squad.component';
import { LeadTimeComponent } from './lead-time/lead-time.component';

@NgModule({
  declarations: [OverviewComponent, SquadComponent, LeadTimeComponent],
  imports: [
    CommonModule,
    SharedModule,
    MaterialModule,
    DashboardRoutingModule,
    chartjsModule,
    MatMenuModule,
    MatIconModule,
    MatButtonModule,
    PerfectScrollbarModule,
    NgApexchartsModule,
    NgxEchartsModule.forRoot({
      echarts: () => import('echarts')
    }),
    GaugeModule.forRoot()
  ],
  providers: [
    OverviewService,
    ChartsConfigurationService
  ]
})
export class DashboardModule {}
