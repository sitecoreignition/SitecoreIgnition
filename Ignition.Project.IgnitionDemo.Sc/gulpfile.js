/// <binding AfterBuild='less' />
/*
This file in the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require('gulp');
var less = require('gulp-less');
gulp.task('default', function () {
		

});
gulp.task('less', function() {
	return gulp.src('./Assets/Ignition/less/main.less')
		.pipe(less())
		.pipe(gulp.dest('./Assets/Ignition/css/'));
});