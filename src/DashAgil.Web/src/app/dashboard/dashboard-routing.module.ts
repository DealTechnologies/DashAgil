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
