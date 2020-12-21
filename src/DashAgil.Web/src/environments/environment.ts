// This file can be replaced during build by using the `fileReplacements` array.
// `ng build --prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

export const environment = {
  production: false,
  apiUrl: 'http://localhost:59384',
  // apiUrl: 'http://dashagil-env-1.eba-bq2tak24.sa-east-1.elasticbeanstalk.com',
  apiIntegracao: 'http://localhost:59384',
  apiEmail: 'http://dashagilemail-env.eba-iiqkheny.sa-east-1.elasticbeanstalk.com'
};

/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/dist/zone-error';  // Included with Angular CLI.
