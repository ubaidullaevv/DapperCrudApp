using Models;
using Interface;
using Service;
using Npgsql;
using Dapper;

Course course=new Course();
CourseServics courseServics=new CourseServics();
courseServics.CreateCourse(course);
courseServics.DisplayCourses();
