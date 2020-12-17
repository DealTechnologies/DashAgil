import { RadarAgilComponent } from './radar-agil/radar-agil.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';


import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatInputModule } from '@angular/material/input';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatRadioModule } from '@angular/material/radio';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatCardModule } from '@angular/material/card';
import { MatSortModule } from '@angular/material/sort';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MaterialFileInputModule } from 'ngx-material-file-input';
import { DragDropModule } from '@angular/cdk/drag-drop';
import { MatTabsModule } from '@angular/material/tabs';

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
import { ChartsConfigurationService, ClientService, OverviewService, ProviderService } from '../core/services';
import { SharedModule } from '../shared/shared.module';
import { MaterialModule } from '../shared/material.module';
import { SquadComponent } from './squad/squad.component';
import { LeadTimeComponent } from './lead-time/lead-time.component';
import { FilterSeriesPipe } from '../core/pipes/filter.pipe';
import { RadarItemsComponent } from './radar-agil/radar-items/radar-items.component';

@NgModule({
  declarations: [OverviewComponent, SquadComponent, LeadTimeComponent, RadarAgilComponent, FilterSeriesPipe, RadarItemsComponent],
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
    GaugeModule.forRoot(),
    ReactiveFormsModule,
    FormsModule,
    MatSelectModule,
    MatCheckboxModule,
    MatInputModule,
    MatTooltipModule,
    MatDatepickerModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatRadioModule,
    MatMenuModule,
    MatSnackBarModule,
    MatSidenavModule,
    MatTableModule,
    MatPaginatorModule,
    MatCardModule,
    MatSortModule,
    MatToolbarModule,
    DragDropModule,
    MaterialFileInputModule,
    MatTabsModule
  ],
  providers: [
    ClientService,
    OverviewService,
    ProviderService,
    ChartsConfigurationService,
  ]
})
export class DashboardModule {}
