// The file contents for the current environment will overwrite these during build.
// The build system defaults to the dev environment which uses `environment.ts`, but if you do
// `ng build --env=prod` then `environment.prod.ts` will be used instead.
// The list of which env maps to which file can be found in `.angular-cli.json`.

export const environment = {
  production: false,
  apiUrl: 'http://localhost:4200/devapi',
  apiAuthUrl: 'https://auth-dev.lykkex.net',
  applicationId: 'dbe670d7-0732-4f41-b27a-09de1e7c0ecd',
  redirectUrl: 'http://localhost:4200/',
};
