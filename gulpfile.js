const gulp = require('gulp');
const sass = require('gulp-sass');

let sassOptions;
sassOptions = {
    errLogToConsole: true,
    outputStyle: 'compressed',
    includePaths: [
        'node_modules/govuk-frontend/govuk'
    ]
};

gulp.task('app-watch-sass', function () {
    return gulp.watch(paths.src.default, gulp.series('app-compile-sass')).on('change', function (file) {
        console.log(`File ${file} was changed, running tasks...`);
    });

});
gulp.task('app-compile-sass', function () {
    return gulp.src('./src/sass/**/*.scss')
        .pipe(sass(sassOptions))
        .pipe(gulp.dest('./wwwroot/css/'));
});
gulp.task('app-copy-assets', function (done) {
    gulp.src(['./node_modules/govuk-frontend/govuk/assets/**/*']).pipe(gulp.dest('./wwwroot/govuk-assets/'));
    gulp.src(['./node_modules/govuk-frontend/govuk/all.js']).pipe(gulp.dest('./wwwroot/js/'));
    done();
});

gulp.task('default', gulp.series('app-compile-sass'));
