namespace ContosoUniversity.Migrations
{
    using ContosoUniversity.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ContosoUniversity.DAL.SchoolContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ContosoUniversity.DAL.SchoolContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            //����ѧ������
            var students = new List<Student> {
                new Student {Name="Ҷ��",EnrollmentDate=DateTime.Parse("2019-1-2")},
                new Student {Name="����",EnrollmentDate=DateTime.Parse("2019-1-3")},
                new Student {Name="����1",EnrollmentDate=DateTime.Parse("2019-1-3")},
                new Student {Name="����2",EnrollmentDate=DateTime.Parse("2019-1-2")},
                new Student {Name="����",EnrollmentDate=DateTime.Parse("2019-1-1")},
                new Student {Name="����4",EnrollmentDate=DateTime.Parse("2019-1-2")},
                new Student {Name="����5",EnrollmentDate=DateTime.Parse("2019-1-3")}
            };
            students.ForEach(s => context.Students.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();


            //�����γ�����
            var courses = new List<Course>
            {
            new Course{CourseID=1050,Title="C#",Credits=3,},
            new Course{CourseID=4022,Title="Web����",Credits=3,},
            new Course{CourseID=4041,Title="Macroeconomics",Credits=3,},
            new Course{CourseID=1045,Title="Calculus",Credits=4,},
            new Course{CourseID=3141,Title="Trigonometry",Credits=4,},
            new Course{CourseID=2021,Title="Composition",Credits=3,},
            new Course{CourseID=2042,Title="Literature",Credits=4,}
            };
            //���γ����ݼ���/����ʵ�弯
            courses.ForEach(s => context.Courses.AddOrUpdate(p => p.Title, s));
            context.SaveChanges();


            //����ע������
            var enrollments = new List<Enrollment>
            {
               new Enrollment{
                    StudentID =students.Single(s=>s.Name=="Ҷ��").ID,
                    CourseID =courses.Single(s=>s.Title=="C#").CourseID,
                    Grade =Grade.A
                },
              new Enrollment{
                    StudentID =students.Single(s=>s.Name=="Ҷ��").ID,
                    CourseID =courses.Single(s=>s.Title=="Web����").CourseID,
                    Grade =Grade.A
              },
            new Enrollment{StudentID=2,CourseID=1045,Grade=Grade.B},
            new Enrollment{StudentID=2,CourseID=3141,Grade=Grade.F},
            new Enrollment{StudentID=2,CourseID=2021,Grade=Grade.F},
            new Enrollment{StudentID=3,CourseID=1050},
            new Enrollment{StudentID=4,CourseID=1050},
            new Enrollment{StudentID=4,CourseID=4022,Grade=Grade.F},
            new Enrollment{StudentID=5,CourseID=4041,Grade=Grade.C},
            new Enrollment{StudentID=6,CourseID=1045},
            new Enrollment{StudentID=7,CourseID=3141,Grade=Grade.A}
            };

            //��ע�����ݼ���/����ʵ�弯
            enrollments.ForEach(s => context.Enrollments.Add(s));
            foreach (Enrollment e in enrollments)
            {
                var enrollmentInDataBase = context.Enrollments.Where(
                    s => s.Student.ID == e.StudentID && s.Course.CourseID == e.CourseID).SingleOrDefault();
                if (enrollmentInDataBase == null)
                {
                    context.Enrollments.Add(e);
                }
            }
            context.SaveChanges();
        }
    }
}
