'use strict';

module.exports = {
  client: {
    source: ['frontend/**/*.{html,css,ico}', '!**/app/**'],
    destination: 'wwwroot/',
    app: ['frontend/**/*.js']
  },
  liveReload: {
    port: 35729
  }
};
