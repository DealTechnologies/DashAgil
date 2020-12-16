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
        path: 'dashboard/overview',
        title: 'Visão Geral',
        moduleName: 'overview',
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
    ]
  },
  {
    path: '',
    title: 'Authentication',
    moduleName: 'authentication',
    icon: 'fas fa-id-card',
    class: 'menu-toggle',
    groupTitle: false,
    submenu: [
      {
        path: '/authentication/signin',
        title: 'Sign In',
        moduleName: 'authentication',
        icon: '',
        class: 'ml-menu',
        groupTitle: false,
        submenu: []
      },
      {
        path: '/authentication/signup',
        title: 'Sign Up',
        moduleName: 'authentication',
        icon: '',
        class: 'ml-menu',
        groupTitle: false,
        submenu: []
      },
      {
        path: '/authentication/forgot-password',
        title: 'Forgot Password',
        moduleName: 'authentication',
        icon: '',
        class: 'ml-menu',
        groupTitle: false,
        submenu: []
      },
      {
        path: '/authentication/locked',
        title: 'Locked',
        moduleName: 'authentication',
        icon: '',
        class: 'ml-menu',
        groupTitle: false,
        submenu: []
      },
      {
        path: '/authentication/page404',
        title: '404 - Not Found',
        moduleName: 'authentication',
        icon: '',
        class: 'ml-menu',
        groupTitle: false,
        submenu: []
      },
      {
        path: '/authentication/page500',
        title: '500 - Server Error',
        moduleName: 'authentication',
        icon: '',
        class: 'ml-menu',
        groupTitle: false,
        submenu: []
      }
    ]
  },
  {
    path: '',
    title: 'Extra Pages',
    moduleName: 'extra-pages',
    icon: 'far fa-file-alt',
    class: 'menu-toggle',
    groupTitle: false,
    submenu: [
      {
        path: '/extra-pages/blank',
        title: 'Blank Page',
        moduleName: 'extra-pages',
        icon: '',
        class: 'ml-menu',
        groupTitle: false,
        submenu: []
      }
    ]
  },
  {
    path: '',
    title: 'Multi level',
    moduleName: 'multilevel',
    icon: 'fas fa-angle-double-down',
    class: 'menu-toggle',
    groupTitle: false,
    submenu: [
      {
        path: '/multilevel/first1',
        title: 'First',
        moduleName: 'multilevel',
        icon: '',
        class: 'ml-menu',
        groupTitle: false,
        submenu: []
      },
      {
        path: '/',
        title: 'Second',
        moduleName: 'secondlevel',
        icon: '',
        class: 'ml-sub-menu',
        groupTitle: false,
        submenu: [
          {
            path: '/multilevel/secondlevel/second1',
            title: 'Second 1',
            moduleName: 'secondlevel',
            icon: '',
            class: 'ml-sub-sub-menu',
            groupTitle: false,
            submenu: []
          },
          {
            path: '/multilevel/secondlevel/second2',
            title: 'Second 2',
            moduleName: 'secondlevel',
            icon: '',
            class: 'ml-sub-sub-menu',
            groupTitle: false,
            submenu: []
          }
        ]
      },
      {
        path: '/multilevel/first3',
        title: 'Third',
        moduleName: 'multilevel',
        icon: '',
        class: 'ml-menu',
        groupTitle: false,
        submenu: []
      }
    ]
  }
];
