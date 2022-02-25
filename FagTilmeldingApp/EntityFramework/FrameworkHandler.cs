using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FagTilmeldingApp.EntityFramework
{
    internal class FrameworkHandler
    {
        
        
            public TECContext DB
            {
                get
                {
                    using TECContext db = new TECContext();
                    return db;
                }
            }

            public List<Teacher> GetTeacher()
            {
                using TECContext db = new TECContext();
                return db.Teachers.ToList();
            }

            public List<Student> GetStudent()
            {
                using TECContext db = new TECContext();
                return db.Students.ToList();
            }

            public List<Course> GetCourses()
            {
                using TECContext db = new TECContext();
                return db.Courses.ToList();
            }

            public List<Enrollment> GetEnrollment()
            {
                using TECContext db = new TECContext();
                return db.Enrollments.ToList();
            }

            public void InsertEnrollment(int studentId, int courseId)
            {
                using TECContext db = new TECContext();
                Enrollment enrollment = new() { StudentId = studentId, CourseId = courseId };
                db.Add(enrollment);
                db.SaveChanges();
            }

            public void ClearEnrollment()
            {
                using TECContext db = new TECContext();
                foreach (Enrollment item in db.Enrollments.ToList())
                    db.Remove(item);
                db.SaveChanges();
            }
        
    }
}
