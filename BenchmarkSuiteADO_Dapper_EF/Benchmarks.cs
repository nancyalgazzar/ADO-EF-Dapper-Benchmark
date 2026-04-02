using BenchmarkDotNet.Attributes;
using BenchmarkSuiteADO_Dapper_EF.Context;
using BenchmarkSuiteADO_Dapper_EF.Entities;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.VSDiagnostics;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace BenchmarkSuiteADO_Dapper_EF
{
    // For more information on the VS BenchmarkDotNet Diagnosers see https://learn.microsoft.com/visualstudio/profiling/profiling-with-benchmark-dotnet
    [CPUUsageDiagnoser]
    [DatabaseDiagnoser]
    public class Benchmarks
    {
        private byte[] data;

        [GlobalSetup]
        public void Setup()
        {
            data = new byte[10000];
            new Random(42).NextBytes(data);
        }

        [Benchmark]
        public Course getfirstCourseEF()
        {
            testContext testContext = new testContext();
            return testContext.Courses.FirstOrDefault();
        }
        [Benchmark]
        public Course getfirstCourseDapper()
        {
            using IDbConnection db = new SqlConnection("Data Source=.;Initial Catalog=test;Integrated Security=True;Encrypt=False");

            return db.QueryFirstOrDefault<Course>("select top(1) * from course");
        }

        [Benchmark]
        public Course getfirstCourseADO()
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=.;Initial Catalog=test;Integrated Security=True;Encrypt=False");
            SqlCommand sqlCommand = new SqlCommand("select top(1) * from course",sqlConnection);
                sqlConnection.Open(); 

            SqlDataReader reader = sqlCommand.ExecuteReader();
            Course course = new Course();
            if (reader.Read())
            {
                course.Duration = int.Parse(reader["Duration"].ToString());
                course.Cname = reader["Cname"].ToString();
            }
            sqlConnection.Close();
            return course;
        }
    }
    [CPUUsageDiagnoser]
    [DatabaseDiagnoser]
    public class selectallBenchmarks
    {
        private byte[] data;

        [GlobalSetup]
        public void Setup()
        {
            data = new byte[10000];
            new Random(42).NextBytes(data);
        }

        [Benchmark]
        public List<Course> getCoursesEF()
        {
            testContext testContext = new testContext();
            return testContext.Courses.Select(p => p).ToList();
        }
        [Benchmark]
        public List<Course> getCoursesDapper()
        {
            using IDbConnection db = new SqlConnection("Data Source=.;Initial Catalog=test;Integrated Security=True;Encrypt=False");

            return db.Query<Course>("select * from course").ToList();
        }

        [Benchmark]
        public List<Course>getCoursesADO()
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=.;Initial Catalog=test;Integrated Security=True;Encrypt=False");
            SqlCommand sqlCommand = new SqlCommand("select * from course", sqlConnection);
            sqlConnection.Open();

            SqlDataReader reader = sqlCommand.ExecuteReader();
            List<Course> courses = new();
            Course course = new Course();
            while (reader.Read())
            {
                course.Duration = int.Parse(reader["Duration"].ToString());
                course.Cname = reader["Cname"].ToString();
                courses.Add(course);
                course = new Course();
            }
            sqlConnection.Close();
            return courses;
        }
    }
    [CPUUsageDiagnoser]
    [DatabaseDiagnoser]
    public class selectallInstructorBenchmarks
    {
        private byte[] data;

        [GlobalSetup]
        public void Setup()
        {
            data = new byte[10000];
            new Random(42).NextBytes(data);
        }

        [Benchmark]
        public List<Instructor> getCoursesEF()
        {
            testContext testContext = new testContext();
            return testContext.Instructors.Select(p => p).ToList();
        }
        [Benchmark]
        public List<Instructor> getCoursesDapper()
        {
            using IDbConnection db = new SqlConnection("Data Source=.;Initial Catalog=test;Integrated Security=True;Encrypt=False");

            return db.Query<Instructor>("select * from instructor").ToList();
        }
        
        [Benchmark]
        public List<Instructor>getCoursesADO()
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=.;Initial Catalog=test;Integrated Security=True;Encrypt=False");
            SqlCommand sqlCommand = new SqlCommand("select * from instructor", sqlConnection);
            sqlConnection.Open();

            SqlDataReader reader = sqlCommand.ExecuteReader();
            List<Instructor> instructors = new();
            Instructor instructor = new ();
            while (reader.Read())
            {
                instructor.Age= int.Parse(reader["age"].ToString());
                instructor.Address = reader["Address"].ToString();
                instructors.Add(instructor);
                instructor = new();
            }
            sqlConnection.Close();
            return instructors;
        }
    }
    [CPUUsageDiagnoser]
    [DatabaseDiagnoser]
    public class updateBenchmarks
    {
        private byte[] data;

        [GlobalSetup]
        public void Setup()
        {
            data = new byte[10000];
            new Random(42).NextBytes(data);
        }

        [Benchmark]
        public int updateCoursesEF()
        {
            testContext testContext = new testContext();
            Course c = testContext.Courses.Where(p => p.Cid == 1680).FirstOrDefault();
            if (c == null) return 0;
            c.Duration = 42;
            return testContext.SaveChanges();
        }
        [Benchmark]
        public int getCoursesDapper()
        {
            using IDbConnection db = new SqlConnection("Data Source=.;Initial Catalog=test;Integrated Security=True;Encrypt=False");

            return db.Execute("update course set duration =@duration where cid = @cid", new { duration = 42, cid = 1 });
        }

        [Benchmark]
        public int getCoursesADO()
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=.;Initial Catalog=test;Integrated Security=True;Encrypt=False");
            using SqlCommand sqlCommand = new SqlCommand("update course set duration =@duration where cid = @cid", sqlConnection);

            sqlCommand.Parameters.AddWithValue("@duration", 42);
            sqlCommand.Parameters.AddWithValue("@cid", 1);

            sqlConnection.Open();
            int r= sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return r;

        } 
       
    }
    [CPUUsageDiagnoser]
    [DatabaseDiagnoser]
    public class selectallallBenchmarks
    {
        private byte[] data;

        [GlobalSetup]
        public void Setup()
        {
            data = new byte[10000];
            new Random(42).NextBytes(data);
        }

        [Benchmark]
        public List<Instructor> getCoursesEF()
        {
            testContext testContext = new testContext();
            return testContext.Instructors.Include(p => p.CIds).ToList();
        }
        [Benchmark]
        public List<dynamic> getCoursesDapper()
        {
            using IDbConnection db = new SqlConnection("Data Source=.;Initial Catalog=test;Integrated Security=True;Encrypt=False");

            return db.Query("select * from course c, teach t, instructor i where c.cid = t.c_id and i.Id = t.I_id").ToList();
        }

        [Benchmark]
        public DataTable getCoursesADO()
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=.;Initial Catalog=test;Integrated Security=True;Encrypt=False");
            SqlCommand sqlCommand = new SqlCommand("select * from course c, teach t, instructor i where c.cid = t.c_id and i.Id = t.I_id", sqlConnection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            sqlConnection.Open();
            DataTable temp = new();
            sqlDataAdapter.Fill(temp);
            sqlConnection.Close();

            return temp;
        }
    }
}
