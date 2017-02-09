'use strict';

module.exports = {
  client: {
    source: ['client/**/*.{html,css,ico}', '!**/app/**'],
    destination: 'wwwroot/',
    app: ['client/**/*.js']
  },
  liveReload: {
    port: 35729
  }
};
