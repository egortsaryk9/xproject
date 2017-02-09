'use strict';
let gulp = require('gulp');
let runSequence = require('run-sequence');

let clientCopyTask = require('./gulp_tasks/client_copy');
let clientBuildTask = require('./gulp_tasks/client_build');
let clientTestTask = require('./gulp_tasks/client_test');
let clientCleanTask = require('./gulp_tasks/client_clean');

let stylesheetTask = require('./gulp_tasks/stylesheet');
let liveReloadTask = require('./gulp_tasks/livereload');
let eslintTask = require('./gulp_tasks/eslint');


gulp.task('livereload', liveReloadTask());

gulp.task('client-copy', clientCopyTask(false, liveReloadTask.notifyChanged));
gulp.task('client-copy-dist', clientCopyTask(true));
gulp.task('client-build', clientBuildTask(false, liveReloadTask.notifyChanged));
gulp.task('client-build-dist', clientBuildTask(true));
gulp.task('client-stylesheet', stylesheetTask(false));
gulp.task('client-stylesheet-dist', stylesheetTask(true));
gulp.task('client-clean', clientCleanTask());
gulp.task('client-test', clientTestTask(true));
gulp.task('client-test-dev', clientTestTask(false));
gulp.task('client-style', eslintTask());


gulp.task('client-stylesheet-watch', function() {
  gulp.watch(['frontend/boot.less', 'frontend/**/*.less'], ['client-stylesheet']);
});

gulp.task('frontend-serve', function(done) {
  runSequence(
    'client-clean',
    ['client-build', 'client-copy', 'client-stylesheet', 'livereload', 'client-stylesheet-watch'],
    done
  )
});

gulp.task('frontend-test', function(done) {
  runSequence(
    'client-test',
    'client-style',
    done
  )
});

gulp.task('frontend-test-dev', function(done) {
  runSequence(
    'client-test-dev',
    done
  )
});

gulp.task('frontend-dist', function(done) {
  runSequence(
    'client-clean',
    ['client-build-dist', 'client-copy-dist', 'client-stylesheet-dist'],
    done
  );
});
