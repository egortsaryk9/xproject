'use strict';
let del = require('del');
let config = require('./config');

module.exports = function() {
  return function() {
    return del([config.client.destination]);
  };
};
