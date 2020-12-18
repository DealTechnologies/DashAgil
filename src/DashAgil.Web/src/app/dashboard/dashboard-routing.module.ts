import { RadarAgilComponent } from './radar-agil/radar-agil.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LeadTimeComponent } from './lead-time/lead-time.component';
import { OverviewComponent } from './overview/overview.component';
import { SquadComponent } from './squad/squad.component';
import { StoriesComponent } from './stories/stories.component';
import { StoriesSquadComponent } from './stories-squad/stories-squad.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'overview',
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
  {
    path: 'radar',
    component: RadarAgilComponent
  },
  {
    path: 'stories',
    component: StoriesComponent
  },
  {
    path: 'stories-squad',
    component: StoriesSquadComponent
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DashboardRoutingModule {}
