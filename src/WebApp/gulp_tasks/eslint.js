'use strict';
let eslint = require('gulp-eslint');
let gulp = require('gulp');
let config = require('./config');

module.exports = function() {
  return function() {
    return gulp.src(config.client.app)
      .pipe(eslint())
      .pipe(eslint.format())
      .pipe(eslint.failAfterError());
  };
};