'use strict';

module.exports = {
  client: {
    source: ['wwwroot/client/**/*.{html,css,ico}', '!**/app/**'],
    destination: 'wwwroot/dist',
    app: ['wwwroot/client/**/*.js']
  },
  liveReload: {
    port: 35729
  }
};
