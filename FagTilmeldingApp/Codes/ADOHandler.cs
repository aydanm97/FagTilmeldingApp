using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace FagTilmeldingApp.Codes
{
    internal class ADOHandler
    {
        public string? ConnectionString
        {
            //connectionstring af vores Database
            // Husk at enable namepipe protokollen inden brug, ellers får man hovedpine :D
            get => "Data Source=DESKTOP-GC15CMR;Initial Catalog=TEC;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }
        public List<TeacherModel> GetTeachers()
        {
            List<TeacherModel> teachers = new List<TeacherModel>();
            using SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Teacher",con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                TeacherModel teacher = new TeacherModel() { TeacherID = reader.GetInt32(0),TeacherFirstName = reader.GetString(1), TeacherLastName = reader.GetString(2) };
                teachers.Add(teacher);
            }
            return teachers;
        }
        public List<StudentModel> GetStudents()
        {
            List<StudentModel> students = new List<StudentModel>();
            using SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Students", con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                StudentModel student = new StudentModel() { StudentID = reader.GetInt32(0), StudentFirstName = reader.GetString(1), StudentLastName = reader.GetString(2) };
                students.Add(student);
            }
            return students;
        }
        public List<FagModel> GetFag()
        {
            List<FagModel> courses = new List<FagModel>();
            using SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Courses", con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                FagModel course = new FagModel() { CourseID = reader.GetInt32(0), CourseName = reader.GetString(1) };
                courses.Add(course);
            }
            return courses;
        }

    }
}
