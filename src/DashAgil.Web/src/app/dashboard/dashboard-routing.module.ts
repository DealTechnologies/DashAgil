import { FirstSyncComponent } from './first-sync/first-sync.component';
import { RadarAgilComponent } from './radar-agil/radar-agil.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LeadTimeComponent } from './lead-time/lead-time.component';
import { OverviewComponent } from './overview/overview.component';
import { SquadComponent } from './squad/squad.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'squad',
    pathMatch: 'full'
  },
  {
    path: 'overview',
    component: OverviewComponent
  },
  {
    path: 'radar',
    component: RadarAgilComponent
  },
  {
    path: 'sync',
    component: FirstSyncComponent
  },
  {
    path: 'squad',
    component: SquadComponent
  },
  {
    path: 'leadtime',
    component: LeadTimeComponent
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DashboardRoutingModule {}
