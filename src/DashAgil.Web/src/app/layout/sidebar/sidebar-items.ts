import { RouteInfo } from './sidebar.metadata';

export const ROUTES: RouteInfo[] = [
  {
    path: '',
    title: '',
    moduleName: '',
    icon: '',
    class: '',
    groupTitle: true,
    submenu: []
  },
  {
    path: '',
    title: 'Dashboard',
    moduleName: 'dashboard',
    icon: 'fas fa-chart-line',
    class: 'menu-toggle',
    groupTitle: false,
    submenu: [
      {
        path: 'dashboard/sync',
        title: 'Sincronização de dados',
        moduleName: 'sync',
        icon: '',
        class: '',
        groupTitle: false,
        submenu: []
      },
      {
        path: 'dashboard/overview',
        title: 'Visão Geral',
        moduleName: 'overview',
        icon: '',
        class: '',
        groupTitle: false,
        submenu: []
      },

      {
        path: 'dashboard/squad',
        title: 'Squad',
        moduleName: 'squad',
        icon: '',
        class: '',
        groupTitle: false,
        submenu: []
      },
      {
        path: 'dashboard/leadtime',
        title: 'Lead Time',
        moduleName: 'leadtime',
        icon: '',
        class: '',
        groupTitle: false,
        submenu: []
      },
      {
        path: 'dashboard/radar',
        title: 'Radar Ágil',
        moduleName: 'radar',
        icon: '',
        class: '',
        groupTitle: false,
        submenu: []
      },
      {
        path: 'dashboard/stories',
        title: 'Histórias',
        moduleName: 'stories',
        icon: '',
        class: '',
        groupTitle: false,
        submenu: []
      },
      {
        path: 'dashboard/stories-squad',
        title: 'Histórias por Squad',
        moduleName: 'stories-squad',
        icon: '',
        class: '',
        groupTitle: false,
        submenu: []
      },
    ]
  },
];
