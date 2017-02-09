'use strict';
let gulp = require('gulp');
let less = require('gulp-less');
let cssnano = require('gulp-cssnano');
let config = require('./config');
let path = require('path')

module.exports = function (singleRun) {
  return function () {    
    let gulpStream = gulp.src(path.resolve(__dirname, './../client/boot.less')).pipe(less());

    if (singleRun) {
      gulpStream = gulpStream.pipe(cssnano());
    }

    return gulpStream.pipe(gulp.dest(config.client.destination));
  }
};