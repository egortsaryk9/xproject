'use strict';
let miniLr = require('mini-lr');
let liveReload = miniLr();
let config = require('./config');

module.exports = function() {
  return function() {
    liveReload.listen(config.liveReload.port);
  }
};

module.exports.notifyChanged = function (files) {
  liveReload.changed({
    body: {
      files: files
    }
  });
};
